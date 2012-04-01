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
        TextureManager texMan = null;
        GraphicsDevice graphicsDevice = null;

        Vector2 m_posCamera;

        public Renderer(TextureManager tex, GraphicsDevice device)
        {
            texMan = tex;
            graphicsDevice = device;
            m_posCamera = new Vector2(0, 0);
        }

        public Vector2 CameraPosition
        {
            get { return m_posCamera; }
            set { m_posCamera = value; }
        }

        /// <summary>
        /// Given a world object, the renderer draws it using the
        /// XNA frameworks
        /// </summary>
        /// <param name="world">The world object to render</param>
        /// <returns></returns>
        public bool RenderWorld(World world)
        {
            graphicsDevice.Clear(Color.Black);

            Vector2 viewportTrans = new Vector2(graphicsDevice.Viewport.Width / 2, graphicsDevice.Viewport.Height / 2);

            SpriteBatch spriteBatch = new SpriteBatch(graphicsDevice);
            spriteBatch.Begin();

            List<Entity> lstEntities = world.GetEntities();
            Console.WriteLine(lstEntities);
            foreach (Entity ent in lstEntities)
            {
                Texture2D tex = texMan.GetTexture(ent.Sprite);
                Vector2 pos = ent.Position;
                pos = pos + m_posCamera + viewportTrans;

                spriteBatch.Draw(tex, pos, Color.White);
            }

            spriteBatch.End();

            return true;
        }
    }
}
