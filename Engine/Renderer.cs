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
    public class Renderer
    {
        AssetManager assetManager = null;
        GraphicsDevice graphicsDevice = null;

        Vector2 m_posCamera;

        private RenderTarget2D m_rtDif;
        private RenderTarget2D m_rtDif2;            // Used to quick swapping
        private RenderTarget2D m_rtDepthStencil;
        private RenderTarget2D m_rtNormal;

        private RenderTarget2D finalResult;
        private RenderTarget2D temp;

        private bool m_bDrawLights;

        public Renderer(AssetManager tex, GraphicsDevice device)
        {
            assetManager = tex;
            graphicsDevice = device;
            m_posCamera = new Vector2(0, 0);
            m_bDrawLights = false;

            ResizeViewport(graphicsDevice.Viewport.Width, graphicsDevice.Viewport.Height);
        }

        public void DrawLights(bool state)
        {
            m_bDrawLights = state;
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

            finalResult = new RenderTarget2D(graphicsDevice, graphicsDevice.PresentationParameters.BackBufferWidth, graphicsDevice.PresentationParameters.BackBufferHeight, false, SurfaceFormat.Color, DepthFormat.None, 1, RenderTargetUsage.PreserveContents);
            temp = new RenderTarget2D(graphicsDevice, graphicsDevice.PresentationParameters.BackBufferWidth, graphicsDevice.PresentationParameters.BackBufferHeight, false, SurfaceFormat.Color, DepthFormat.None, 1, RenderTargetUsage.DiscardContents);
        }

        public Vector2 CameraPosition
        {
            get { return m_posCamera; }
            set { m_posCamera = value; }
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

            Effect shader = assetManager.GetEffect("shaders/SimpleSprite");
            Effect channel = assetManager.GetEffect("shaders/ChannelRender");
            Effect depthSpriteShader = assetManager.GetEffect("shaders/DepthSprite");
            Vector2 viewportTrans = new Vector2(graphicsDevice.Viewport.Width / 2, graphicsDevice.Viewport.Height / 2);

            SpriteBatch spriteBatch = new SpriteBatch(graphicsDevice);

            // Step 1: Generate a stencil of which pixels to render


            // Draw the actual sprites
            Color[] t = { Color.White, Color.Yellow, Color.Purple, Color.Blue };
            int i = 0;



            graphicsDevice.SetRenderTarget(m_rtNormal);
            graphicsDevice.Clear(Color.Transparent);

            graphicsDevice.SetRenderTarget(m_rtDepthStencil);
            graphicsDevice.Clear(Color.Transparent);

            graphicsDevice.SetRenderTarget(m_rtDif);
            graphicsDevice.Clear(Color.Black);

            graphicsDevice.SetRenderTarget(finalResult);
            graphicsDevice.Clear(Color.Black);

            List<Entity> lstEntities = world.GetEntities();
            foreach (Entity ent in lstEntities)
            {
                if(ent.Type!=EntityType.Sprite)
                    continue;

                // Gather information
                Texture2D tex = assetManager.GetTexture(ent.Sprite);
                Texture2D texHeightmap = assetManager.GetHeightmap(ent.Sprite);
                Texture2D texNormal = assetManager.GetNormalmap(ent.Sprite);

                RenderTarget2D mask = new RenderTarget2D(graphicsDevice, tex.Width, tex.Height);

                Vector2 pos = ent.Position;
                pos = pos + m_posCamera + viewportTrans;

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
                graphicsDevice.Textures[1] = m_rtDepthStencil;
                depthSpriteShader.Techniques[0].Passes[0].Apply();

                // Draw the sprite
                spriteBatch.Draw(texHeightmap, pos, Color.White);
                spriteBatch.End();


                // Comp it all together onto the depth buffer
                graphicsDevice.SetRenderTarget(m_rtDepthStencil);
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
                graphicsDevice.SetRenderTarget(m_rtNormal);
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
                graphicsDevice.SetRenderTarget(finalResult);
                spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend);
                spriteBatch.Draw(temp, Vector2.Zero, Color.White);
                spriteBatch.End();

                i++;
            }


            // Render the lights!
            
            
            Texture2D lightPos = assetManager.GetTexture("sprites/test/lightpos");
            Texture2D lightBulb = assetManager.GetTexture("sprites/test/lightbulb");
            Effect pointLight = assetManager.GetEffect("shaders/PointLight");
            graphicsDevice.SetRenderTarget(null);
            graphicsDevice.SetRenderTarget(m_rtDif2);
            graphicsDevice.Clear(Color.Transparent);
            foreach (Entity ent in lstEntities)
            {
                if (ent.Type != EntityType.Light)
                    continue;

                Entities.Lights.Light light = (Entities.Lights.Light)ent;
                Vector2 pos = light.Position + m_posCamera + viewportTrans;

                spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend, SamplerState.LinearClamp, DepthStencilState.Default, RasterizerState.CullCounterClockwise, pointLight);
                graphicsDevice.Textures[1] = m_rtDepthStencil;
                graphicsDevice.Textures[2] = m_rtNormal;
                pointLight.Parameters["intensity"].SetValue(light.Intensity);
                pointLight.Parameters["range"].SetValue(light.Range);
                pointLight.Parameters["color"].SetValue(new Vector4(light.Color.R / 255.0f, light.Color.G / 255.0f, light.Color.B / 255.0f, light.Color.A / 255.0f));
                pointLight.Parameters["pos"].SetValue(new Vector3(pos.X, pos.Y, light.Z));
                pointLight.Parameters["size"].SetValue(new Vector2(m_rtDif2.Width, m_rtDif2.Height));
                
                Console.WriteLine("Applying the point light shader");
                pointLight.Techniques[0].Passes[0].Apply();
                spriteBatch.Draw(finalResult, Vector2.Zero, Color.White);
                spriteBatch.End();

                if (m_bDrawLights)
                {
                    
                    spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend);
                    spriteBatch.Draw(lightPos, pos, light.Color);
                    spriteBatch.Draw(lightBulb, new Vector2(pos.X, pos.Y - light.Z), light.Color);
                    spriteBatch.End();
                }
            }

            graphicsDevice.SetRenderTarget(null);
            graphicsDevice.Clear(Color.Transparent);
            spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend);
            //channel.Parameters["channel"].SetValue(3);
            //channel.Techniques[0].Passes[0].Apply();
            spriteBatch.Draw(m_rtDif2, Vector2.Zero, Color.White);
            spriteBatch.End();

            return true;
        }

        public Entity GetEntityAtPosition(World world, int x, int y)
        {
            Vector2 viewportTrans = new Vector2(graphicsDevice.Viewport.Width / 2, graphicsDevice.Viewport.Height / 2);
            Vector2 clickPos = new Vector2(x - m_posCamera.X - viewportTrans.X, y - m_posCamera.Y - viewportTrans.Y);
            Console.WriteLine(clickPos);
            foreach (Entity ent in world.GetEntities())
            {
                Vector2 pos = ent.Position;
                Rectangle rect = new Rectangle((int)pos.X, (int)pos.Y, 10, 10);;
                if(ent.Type==EntityType.Sprite)
                {
                    Texture2D tex = assetManager.GetTexture(ent.Sprite);
                    rect = new Rectangle((int)pos.X, (int)pos.Y, tex.Width, tex.Height);
                }
                
                if (rect.Contains((int)clickPos.X, (int)clickPos.Y))
                    return ent;
            }

            return null;
        }
    }
}
