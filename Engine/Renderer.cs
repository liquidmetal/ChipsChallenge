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
        private RenderTarget2D m_rtDepth;
        private RenderTarget2D m_rtNormal;

        public Renderer(AssetManager tex, GraphicsDevice device)
        {
            assetManager = tex;
            graphicsDevice = device;
            m_posCamera = new Vector2(0, 0);
        }

        private void SetupRenderTargets()
        {
            //graphicsDevice.SetRenderTargets(m_rtDif, m_rtDepthStencil);
        }

        private void ResolveRenderTargets()
        {
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
            ClearScreen();

            Effect shader = assetManager.GetEffect("shaders/SimpleSprite");
            Effect depthSpriteShader = assetManager.GetEffect("shaders/DepthSprite");
            Vector2 viewportTrans = new Vector2(graphicsDevice.Viewport.Width / 2, graphicsDevice.Viewport.Height / 2);

            SpriteBatch spriteBatch = new SpriteBatch(graphicsDevice);

            // Step 1: Generate a stencil of which pixels to render


            // Draw the actual sprites
            Color[] t = { Color.White, Color.Yellow, Color.Purple, Color.Blue };
            int i = 0;

            m_rtDif = new RenderTarget2D(graphicsDevice, graphicsDevice.PresentationParameters.BackBufferWidth, graphicsDevice.PresentationParameters.BackBufferHeight, false, SurfaceFormat.Color, DepthFormat.None, 1, RenderTargetUsage.PreserveContents);
            m_rtDepth = new RenderTarget2D(graphicsDevice, graphicsDevice.PresentationParameters.BackBufferWidth, graphicsDevice.PresentationParameters.BackBufferHeight, false, SurfaceFormat.Color, DepthFormat.None, 1, RenderTargetUsage.PreserveContents);

            RenderTarget2D finalResult = new RenderTarget2D(graphicsDevice, graphicsDevice.PresentationParameters.BackBufferWidth, graphicsDevice.PresentationParameters.BackBufferHeight, false, SurfaceFormat.Color, DepthFormat.None, 1, RenderTargetUsage.PreserveContents);
            RenderTarget2D temp = new RenderTarget2D(graphicsDevice, graphicsDevice.PresentationParameters.BackBufferWidth, graphicsDevice.PresentationParameters.BackBufferHeight, false, SurfaceFormat.Color, DepthFormat.None, 1, RenderTargetUsage.DiscardContents);

            List<Entity> lstEntities = world.GetEntities();
            foreach (Entity ent in lstEntities)
            {
                // Gather information
                Texture2D tex = assetManager.GetTexture(ent.Sprite);
                Texture2D texHeightmap = assetManager.GetHeightmap(ent.Sprite);

                Vector2 pos = ent.Position;
                pos = pos + m_posCamera + viewportTrans;

                SpriteEffects spriteEffects;
                spriteEffects = ent.MirrorHorizontal ? SpriteEffects.FlipHorizontally : SpriteEffects.None;

                if (ent.MirrorVertical)
                    spriteEffects = spriteEffects | SpriteEffects.FlipVertically;

                // Pass 1: Generate a good height map
                //         No stencil as of now
                graphicsDevice.SetRenderTarget(temp);
                spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend);
                spriteBatch.Draw(texHeightmap, pos, t[i]);
                spriteBatch.End();

                graphicsDevice.SetRenderTarget(finalResult);
                spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend);
                spriteBatch.Draw(temp, Vector2.Zero, Color.White);
                spriteBatch.End();

                i++;
            }

            graphicsDevice.SetRenderTarget(null);
            spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend);
            spriteBatch.Draw(finalResult, Vector2.Zero, Color.White);
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
                Texture2D tex = assetManager.GetTexture(ent.Sprite);
                Vector2 pos = ent.Position;

                Rectangle rect = new Rectangle((int)pos.X, (int)pos.Y, tex.Width, tex.Height);
                if (rect.Contains((int)clickPos.X, (int)clickPos.Y))
                    return ent;
            }

            return null;
        }
    }
}
