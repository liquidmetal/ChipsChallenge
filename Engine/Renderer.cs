using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

using Engine;
using Engine.Entities;

namespace Engine
{
    public enum RenderSceneType { Beauty, Diffuse, Height, Normal, Lights };

    public class Renderer
    {
        AssetManager assetManager = null;
        GraphicsDevice graphicsDevice = null;

        Color m_colAmbient;
        float m_fAmbientIntensity = 0.1f;

        Vector2 m_posCamera;

        private RenderTarget2D m_rtDif;
        private RenderTarget2D m_rtDif2;            // Used to quick swapping
        private RenderTarget2D m_rtDepthStencil;
        private RenderTarget2D m_rtNormal;
        private RenderTarget2D m_rtLights;          // The lighting pass (multiplier for each pixel)
        private RenderTarget2D m_rtOverlay;         // stuff that's on top of everything else
        private RenderTarget2D m_rtSpc;

        private RenderTarget2D finalResult;
        private RenderTarget2D temp;

        private bool m_bDrawLights;
        private RenderSceneType m_rstType;          // Which pass to render out

        private Matrix world, view, projection;     // Holds the important matrices for simulation
        private Matrix forward, inverse;            // Holds the combined matrices

        public Renderer(AssetManager tex, GraphicsDevice device)
        {
            assetManager = tex;
            graphicsDevice = device;
            m_posCamera = new Vector2(0, 0);
            m_bDrawLights = false;
            m_rstType = RenderSceneType.Beauty;

            m_colAmbient = new Color(1f, 1f, 1f, 1.0f);

            ResizeViewport(graphicsDevice.Viewport.Width, graphicsDevice.Viewport.Height);
        }

        public void DrawLights(bool state)
        {
            m_bDrawLights = state;
        }

        public void SetRenderSceneType(RenderSceneType rst)
        {
            m_rstType = rst;
        }

        private void SetupRenderTargets()
        {
            //graphicsDevice.SetRenderTargets(m_rtDif, m_rtDepthStencil);
        }

        private void ResolveRenderTargets()
        {
        }

        public void ResizeViewport(int width, int height)
        {
            m_rtDif = new RenderTarget2D(graphicsDevice, graphicsDevice.PresentationParameters.BackBufferWidth, graphicsDevice.PresentationParameters.BackBufferHeight, false, SurfaceFormat.Color, DepthFormat.None, 1, RenderTargetUsage.PreserveContents);
            m_rtDif2 = new RenderTarget2D(graphicsDevice, graphicsDevice.PresentationParameters.BackBufferWidth, graphicsDevice.PresentationParameters.BackBufferHeight, false, SurfaceFormat.Color, DepthFormat.None, 1, RenderTargetUsage.PreserveContents);
            m_rtDepthStencil = new RenderTarget2D(graphicsDevice, graphicsDevice.PresentationParameters.BackBufferWidth, graphicsDevice.PresentationParameters.BackBufferHeight, false, SurfaceFormat.Color, DepthFormat.None, 1, RenderTargetUsage.PreserveContents);
            m_rtNormal = new RenderTarget2D(graphicsDevice, graphicsDevice.PresentationParameters.BackBufferWidth, graphicsDevice.PresentationParameters.BackBufferHeight, false, SurfaceFormat.Color, DepthFormat.None, 1, RenderTargetUsage.PreserveContents);
            m_rtLights = new RenderTarget2D(graphicsDevice, graphicsDevice.PresentationParameters.BackBufferWidth, graphicsDevice.PresentationParameters.BackBufferHeight, false, SurfaceFormat.Color, DepthFormat.None, 1, RenderTargetUsage.PreserveContents);
            m_rtOverlay = new RenderTarget2D(graphicsDevice, graphicsDevice.PresentationParameters.BackBufferWidth, graphicsDevice.PresentationParameters.BackBufferHeight, false, SurfaceFormat.Color, DepthFormat.None, 1, RenderTargetUsage.PreserveContents);
            m_rtSpc = new RenderTarget2D(graphicsDevice, graphicsDevice.PresentationParameters.BackBufferWidth, graphicsDevice.PresentationParameters.BackBufferHeight, false, SurfaceFormat.Color, DepthFormat.None, 1, RenderTargetUsage.PreserveContents);

            finalResult = new RenderTarget2D(graphicsDevice, graphicsDevice.PresentationParameters.BackBufferWidth, graphicsDevice.PresentationParameters.BackBufferHeight, false, SurfaceFormat.Color, DepthFormat.None, 1, RenderTargetUsage.PreserveContents);

            temp = new RenderTarget2D(graphicsDevice, graphicsDevice.PresentationParameters.BackBufferWidth, graphicsDevice.PresentationParameters.BackBufferHeight, false, SurfaceFormat.Color, DepthFormat.None, 1, RenderTargetUsage.DiscardContents);
            //tempA = new RenderTarget2D(graphicsDevice, graphicsDevice.PresentationParameters.BackBufferWidth, graphicsDevice.PresentationParameters.BackBufferHeight, false, SurfaceFormat.Color, DepthFormat.None, 1, RenderTargetUsage.DiscardContents);

            UpdateMatrices();
        }

        private void UpdateMatrices()
        {
            // Update the important matrices
            world = Matrix.Identity;
            view = Matrix.CreateLookAt(new Vector3(20 + m_posCamera.X, m_posCamera.Y + 20, 20), new Vector3(m_posCamera.X, m_posCamera.Y, 0), new Vector3(0, 0, 1));
            projection = Matrix.CreateOrthographic(graphicsDevice.Viewport.Width, graphicsDevice.Viewport.Height, 0, 1);

            // TODO confirm if this is the right order
            forward = Matrix.Multiply(Matrix.Multiply(world, view), projection);
            inverse = Matrix.Invert(forward);
        }

        public Vector2 Project(Vector3 vec)
        {
            Vector3 toRet = graphicsDevice.Viewport.Project(vec, projection, view, world);
            Vector2 ret = new Vector2(toRet.X, toRet.Y);

            return ret;
        }

        public Vector3 Unproject(Vector2 vec)
        {
            Vector3 posA = graphicsDevice.Viewport.Unproject(new Vector3(vec.X, vec.Y, 1), projection, view, world);
            Vector3 posB = graphicsDevice.Viewport.Unproject(new Vector3(vec.X, vec.Y, 0), projection, view, world);

            // Now, we need to bring this to the z=0 plane
            Vector3 direction = Vector3.Normalize(posB - posA);
            Ray r = new Ray(posA, direction);

            // The Z plane
            Vector3 n = new Vector3(0, 0, 1);
            Plane p = new Plane(n, 0);

            float? d = r.Intersects(p);

            // calcuate distance of plane intersection point from ray origin
            double denominator = Vector3.Dot(p.Normal, r.Direction);
            double numerator = Vector3.Dot(p.Normal, r.Position) + p.D;
            double t = -(numerator / denominator);
            
            return posA + direction*(float)t;
        }

        public Vector2 CameraPosition
        {
            get { return m_posCamera; }
            set { m_posCamera = value; UpdateMatrices();  }
        }

        private void ClearScreen()
        {
            Effect clearer = assetManager.GetEffect("shaders/ClearBuffers");
            clearer.Techniques[0].Passes[0].Apply();

            Vector2 view = new Vector2(graphicsDevice.Viewport.X / 2, graphicsDevice.Viewport.Y / 2);
            Vector2 vec1 = new Vector2(m_posCamera.X - view.X, m_posCamera.Y-view.Y);
            Vector2 vec2 = new Vector2(m_posCamera.X + view.X, m_posCamera.Y + view.Y);

            VertexPositionColor[] vertices = {new VertexPositionColor(new Vector3(vec2.X, vec1.Y, 0), Color.Black),
                                    new VertexPositionColor(new Vector3(vec1.X, vec1.Y, 0), Color.Black),
                                    new VertexPositionColor(new Vector3(vec1.X, vec2.Y, 0), Color.Black),
                                    new VertexPositionColor(new Vector3(vec2.X, vec2.Y, 0), Color.Black)};

            graphicsDevice.DrawUserPrimitives<VertexPositionColor>(PrimitiveType.TriangleList, vertices, 0, 1);
            
        }

        private void ClearRenderTargets()
        {
            // The normal pass
            graphicsDevice.SetRenderTarget(m_rtNormal);
            graphicsDevice.Clear(Color.Transparent);

            // The depth pass
            graphicsDevice.SetRenderTarget(m_rtDepthStencil);
            graphicsDevice.Clear(Color.Transparent);

            // The diffuse pass
            graphicsDevice.SetRenderTarget(m_rtDif);
            graphicsDevice.Clear(Color.Black);

            // The final result temporarily stored
            graphicsDevice.SetRenderTarget(finalResult);
            graphicsDevice.Clear(Color.Black);

            // The lighting pass
            graphicsDevice.SetRenderTarget(m_rtLights);
            graphicsDevice.Clear(Color.Transparent);

            // The specular pass
            graphicsDevice.SetRenderTarget(m_rtSpc);
            graphicsDevice.Clear(Color.Transparent);

            // The overlay pass
            graphicsDevice.SetRenderTarget(m_rtOverlay);
            graphicsDevice.Clear(Color.Transparent);
        }

        private void RenderEntities(List<Entity> lstEntities, SpriteBatch spriteBatch, RenderTarget2D difTarget, RenderTarget2D hgtTarget, RenderTarget2D nrmTarget, RenderTarget2D temp)
        {
            Effect shader = assetManager.GetEffect("shaders/sprite/SimpleSprite");
            Effect heightSpriteShader = assetManager.GetEffect("shaders/sprite/HeightSprite");
            Effect depthSpriteShader = assetManager.GetEffect("shaders/sprite/DepthSprite");
            Vector2 viewportTrans = new Vector2(graphicsDevice.Viewport.Width / 2, graphicsDevice.Viewport.Height / 2);

            foreach (Entity ent in lstEntities)
            {
                if (ent.Type != EntityType.Sprite)
                    continue;

                // Gather information
                Texture2D tex = assetManager.GetTexture(ent.Sprite);
                Texture2D texHeightmap = assetManager.GetHeightmap(ent.Sprite);
                Texture2D texNormal = assetManager.GetNormalmap(ent.Sprite);

                // This render target has to be made for every asset
                RenderTarget2D mask = new RenderTarget2D(graphicsDevice, tex.Width, tex.Height);

                // Gather information about the sprite
                Vector2 pos = Project(new Vector3(ent.Position.X, ent.Position.Y, ent.Z));// +m_posCamera + viewportTrans;
                //pos.Y -= (float)Math.Sqrt(ent.Z);

                SpriteEffects spriteEffects;
                spriteEffects = ent.MirrorHorizontal ? SpriteEffects.FlipHorizontally : SpriteEffects.None;

                if (ent.MirrorVertical)
                    spriteEffects = spriteEffects | SpriteEffects.FlipVertically;

                // Pass 1: Generate a good height map
                //         No stencil as of now

                ////////////////////////////////////////////////
                // Draw the current sprite's heightmap
                graphicsDevice.SetRenderTarget(temp);
                graphicsDevice.Clear(Color.Transparent);

                spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend);

                // Setup shader parameters
                depthSpriteShader.Parameters["position"].SetValue(pos);
                depthSpriteShader.Parameters["bufferSize"].SetValue(new Vector2(graphicsDevice.Viewport.Width, graphicsDevice.Viewport.Height));
                depthSpriteShader.Parameters["texSize"].SetValue(new Vector2(texHeightmap.Width, texHeightmap.Height));
                depthSpriteShader.Parameters["unproject"].SetValue(inverse);
                heightSpriteShader.Parameters["z"].SetValue(ent.Z);
                graphicsDevice.Textures[1] = hgtTarget;
                depthSpriteShader.Techniques[0].Passes[0].Apply();

                // Draw the sprite
                
                //heightSpriteShader.Techniques[0].Passes[0].Apply();
                spriteBatch.Draw(texHeightmap, pos, Color.White);
                spriteBatch.End();


                // Comp it all together onto the depth buffer
                graphicsDevice.SetRenderTarget(hgtTarget);
                spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend);
                spriteBatch.Draw(temp, Vector2.Zero, Color.White);
                spriteBatch.End();

                graphicsDevice.SetRenderTarget(mask);
                graphicsDevice.Clear(Color.Transparent);
                spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend);
                spriteBatch.Draw(temp, new Vector2(-pos.X, -pos.Y), Color.White);
                spriteBatch.End();

                ////////////////////////////////////////////
                // Draw the sprite's normal map
                graphicsDevice.SetRenderTarget(temp);
                graphicsDevice.Clear(Color.Transparent);

                spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend);

                // Setup shader parameters
                graphicsDevice.Textures[1] = mask;
                shader.Techniques[0].Passes[0].Apply();

                // Draw it
                spriteBatch.Draw(texNormal, pos, Color.White);
                spriteBatch.End();

                // Comp it al onto the normal buffer
                graphicsDevice.SetRenderTarget(nrmTarget);
                spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend);
                spriteBatch.Draw(temp, Vector2.Zero, Color.White);
                spriteBatch.End();

                //////////////////////////////////////////////
                // Draw the sprite's dif map
                graphicsDevice.SetRenderTarget(temp);
                graphicsDevice.Clear(Color.Transparent);

                spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend);

                // Setup shader parameters
                graphicsDevice.Textures[1] = mask;
                shader.Techniques[0].Passes[0].Apply();

                // Draw it
                spriteBatch.Draw(tex, pos, ent.Tint);
                spriteBatch.End();

                // Comp it all onto the dif buffer
                graphicsDevice.SetRenderTarget(difTarget);
                spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend);
                spriteBatch.Draw(temp, Vector2.Zero, Color.White);
                spriteBatch.End();
            }
        }

        private void RenderLights(List<Entity> lstEntities, SpriteBatch spriteBatch, RenderTarget2D difTarget, RenderTarget2D hgtTarget, RenderTarget2D nrmTarget, RenderTarget2D lgtTarget, RenderTarget2D spcTarget, RenderTarget2D temp)
        {
            Effect pointLight = assetManager.GetEffect("shaders/light/PointLight");

            Vector2 viewportTrans = new Vector2(graphicsDevice.Viewport.Width / 2, graphicsDevice.Viewport.Height / 2);
            Vector2 trans = viewportTrans + m_posCamera;

            // First, we need to generate a proper unproject matrix so we can 
            // convert each point into an appropriate 3D point inside the 
            // shader

            graphicsDevice.SetRenderTarget(null);
            foreach (Entity ent in lstEntities)
            {
                if (ent.Type != EntityType.Light)
                    continue;

                graphicsDevice.SetRenderTargets(temp);
                

                graphicsDevice.SetRenderTargets(temp, spcTarget);
                graphicsDevice.Clear(Color.Transparent);

                Entities.Lights.Light light = (Entities.Lights.Light)ent;
                Vector2 pos = Project(new Vector3(ent.Position.X, ent.Position.Y, ent.Z));

                spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend, SamplerState.LinearClamp, DepthStencilState.Default, RasterizerState.CullCounterClockwise, pointLight);
                graphicsDevice.Textures[1] = hgtTarget;
                graphicsDevice.Textures[2] = nrmTarget;
                pointLight.Parameters["intensity"].SetValue(light.Intensity);
                pointLight.Parameters["range"].SetValue(light.Range);
                pointLight.Parameters["color"].SetValue(new Vector4(light.Color.R / 255.0f, light.Color.G / 255.0f, light.Color.B / 255.0f, light.Color.A / 255.0f));

                // The position needs to be in screen space for this to work
                // So - we do that here
                pointLight.Parameters["pos"].SetValue(pos);
                pointLight.Parameters["z"].SetValue(ent.Z);


                pointLight.Parameters["size"].SetValue(new Vector2(m_rtDif2.Width, m_rtDif2.Height));
                pointLight.Parameters["unproject"].SetValue(inverse);

                pointLight.Techniques[0].Passes[0].Apply();
                spriteBatch.Draw(difTarget, Vector2.Zero, Color.White);
                spriteBatch.End();

                graphicsDevice.SetRenderTarget(lgtTarget);
                spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.Additive);
                spriteBatch.Draw(temp, Vector2.Zero, Color.White);
                spriteBatch.End();
                
            }
        }

        /// <summary>
        /// Given a world object, the renderer draws it using the
        /// XNA frameworks
        /// </summary>
        /// <param name="world">The world object to render</param>
        /// <returns></returns>
        public bool RenderWorld(World world)
        {
            world.SortEntities();
            ClearScreen();

            Effect shader = assetManager.GetEffect("shaders/sprite/SimpleSprite");
            Effect channel = assetManager.GetEffect("shaders/ChannelRender");
            
            Vector2 viewportTrans = new Vector2(graphicsDevice.Viewport.Width / 2, graphicsDevice.Viewport.Height / 2);

            SpriteBatch spriteBatch = new SpriteBatch(graphicsDevice);

            // Step 1: Generate a stencil of which pixels to render


            // Draw the actual sprites
            Color[] t = { Color.White, Color.Yellow, Color.Purple, Color.Blue };
            int i = 0;

            ClearRenderTargets();

            List<Entity> lstEntities = world.GetEntities();

            // First pass: Draw the entities
            // This pass generates the dif, nrm and hgt textures
            // Objects intersect as if in 3D
            RenderEntities(lstEntities, spriteBatch, m_rtDif, m_rtDepthStencil, m_rtNormal, temp);

            // Render the lights!
            RenderLights(lstEntities, spriteBatch, m_rtDif, m_rtDepthStencil, m_rtNormal, m_rtLights, m_rtSpc, temp);

            // Render the overlays!
            Texture2D lightPos = assetManager.GetTexture("sprites/test/lightpos");
            Texture2D lightBulb = assetManager.GetTexture("sprites/test/lightbulb");
            graphicsDevice.SetRenderTarget(m_rtOverlay);
            if (m_bDrawLights)
            {
                spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend);
                foreach (Entity ent in lstEntities)
                {
                    if (ent.Type != EntityType.Light)
                        continue;

                    Entities.Lights.Light light = (Entities.Lights.Light)ent;
                    Vector2 posBase = Project(new Vector3(light.Position.X, light.Position.Y, 0));
                    Vector2 posBulb = Project(new Vector3(light.Position.X, light.Position.Y, light.Z));

                    spriteBatch.Draw(lightPos, posBase, light.Color);
                    spriteBatch.Draw(lightBulb, posBulb, light.Color);
                }
                spriteBatch.End();
            }

            ////////////////////////////////////////////////////////////////////
            // finalResult stores the final beauty pass
            // That is, a combination of the dif and the lighting outputs
            graphicsDevice.SetRenderTarget(finalResult);
            graphicsDevice.Textures[1] = m_rtLights;
            graphicsDevice.Textures[2] = m_rtSpc;

            Effect combine = assetManager.GetEffect("shaders/Combine");

            spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend);
            combine.Parameters["scalarAdd"].SetValue(m_colAmbient.ToVector4() * m_fAmbientIntensity);
            combine.Techniques[0].Passes[0].Apply();
            spriteBatch.Draw(m_rtDif, Vector2.Zero, Color.White);
            spriteBatch.End();

            //////////////////////////////////////////////////////////////////
            graphicsDevice.SetRenderTarget(null);
            graphicsDevice.Clear(Color.Transparent);
            spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend);

            switch(m_rstType)
            {
                case RenderSceneType.Diffuse:
                    spriteBatch.Draw(m_rtDif, Vector2.Zero, Color.White);
                    break;

                case RenderSceneType.Height:
                    spriteBatch.Draw(m_rtDepthStencil, Vector2.Zero, Color.White);
                    break;

                case RenderSceneType.Normal:
                    spriteBatch.Draw(m_rtNormal, Vector2.Zero, Color.White);
                    break;

                case RenderSceneType.Lights:
                    spriteBatch.Draw(m_rtLights, Vector2.Zero, Color.White);
                    break;

                case RenderSceneType.Beauty:
                    spriteBatch.Draw(finalResult, Vector2.Zero, Color.White);
                    break;
            }
            spriteBatch.Draw(m_rtOverlay, Vector2.Zero, Color.White);
            spriteBatch.End();

            return true;
        }

        public Entity GetEntityAtPosition(World world, int x, int y)
        {
            //Vector2 viewportTrans = new Vector2(graphicsDevice.Viewport.Width / 2, graphicsDevice.Viewport.Height / 2);
            //Vector2 clickPos = new Vector2(x - m_posCamera.X - viewportTrans.X, y - m_posCamera.Y - viewportTrans.Y);
            //Console.WriteLine(clickPos);
            foreach (Entity ent in world.GetEntities())
            {
                Vector2 pos = ent.Position;
                Rectangle rect = new Rectangle((int)pos.X, (int)pos.Y, 10, 10);;
                if(ent.Type==EntityType.Sprite)
                {
                    Texture2D tex = assetManager.GetTexture(ent.Sprite);
                    rect = new Rectangle((int)pos.X, (int)pos.Y, tex.Width, tex.Height);
                }
                
                if (rect.Contains((int)x, (int)y))
                    return ent;
            }

            return null;
        }
    }
}
