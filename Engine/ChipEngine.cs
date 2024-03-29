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

        bool drawLight = false;

        public ChipEngine(GraphicsDevice device, ContentManager content)
        {
            this.content = content;
            graphicsDevice = device;

            ClearWorld();
            renderer = new Renderer(assetManager, graphicsDevice);
        }

        public void ResizeViewport(int width, int height)
        {
            renderer.ResizeViewport(width, height);
        }

        public void DrawLights(bool state)
        {
            drawLight = state;
            renderer.DrawLights(state);
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
            assetManager.LoadEffect("shaders/ClearBuffers");
            assetManager.LoadEffect("shaders/sprite/SimpleSprite");
            assetManager.LoadEffect("shaders/sprite/DepthSprite");
            assetManager.LoadEffect("shaders/sprite/HeightSprite");
            assetManager.LoadEffect("shaders/ChannelRender");
            assetManager.LoadEffect("shaders/light/PointLight");
            assetManager.LoadEffect("shaders/Combine");
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

        public void SetRenderSceneType(RenderSceneType rst)
        {
            renderer.SetRenderSceneType(rst);
        }

        public Vector3 Unproject(Vector2 pos)
        {
            return renderer.Unproject(pos);
        }
    }
}
