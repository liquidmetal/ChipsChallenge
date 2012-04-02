using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Engine
{
    /// <summary>
    /// This is the main class. Instantiate this and you can do anything.
    /// </summary>
    public class ChipEngine
    {
        AssetManager assetManager = null;
        World currentWorld = null;
        Renderer renderer = null;
        ContentManager content = null;
        GraphicsDevice graphicsDevice = null;

        public ChipEngine(GraphicsDevice device, ContentManager content)
        {
            this.content = content;
            graphicsDevice = device;

            ClearWorld();
            renderer = new Renderer(assetManager, graphicsDevice);
        }

        public void ClearWorld()
        {
            if (assetManager != null)
                assetManager = null;

            if (currentWorld != null)
                currentWorld = null;

            assetManager = new AssetManager(content);
            currentWorld = new World(assetManager);
            LoadEffects();
            
        }

        private void LoadEffects()
        {
            assetManager.LoadEffect("shaders/SimpleSprite");
            assetManager.LoadEffect("shaders/ClearBuffers");
            assetManager.LoadEffect("shaders/DepthSprite");
        }

        /// <summary>
        /// Returns the world object being rendered. This is to allow
        /// for 'realtime' editing of the world
        /// </summary>
        /// <returns>The current world</returns>
        public World GetWorld()
        {
            return currentWorld;
        }

        public Renderer GetRenderer()
        {
            return renderer;
        }

        public void Update()
        {
        }

        public void Render()
        {
            renderer.RenderWorld(currentWorld);
        }
    }
}
