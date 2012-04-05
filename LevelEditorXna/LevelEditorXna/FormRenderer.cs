#region Using Statements
using System.Diagnostics;
using System.Windows.Forms;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Design;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

using Engine;
using Engine.Entities;
#endregion

namespace LevelEditor
{
    public partial class FormRenderer : GraphicsDeviceControl
    {
        BasicEffect effect;
        Stopwatch timer;

        ChipEngine engine = null;

        public World CurrentWorld
        {
            get { return engine.GetWorld(); }
        }

        public Renderer CurrentRenderer
        {
            get { return engine.GetRenderer(); }
        }

        /// <summary>
        /// Initializes the control.
        /// </summary>
        protected override void Initialize()
        {
            engine = new ChipEngine(GraphicsDevice, new ContentManager(this.Services, "Content"));
            engine.DrawLights(true);
            this.OnResize(null);

            // Start the animation timer.
            timer = Stopwatch.StartNew();
            
            // Hook the idle event to constantly redraw our animation.
            Application.Idle += delegate { Invalidate(); };
        }

        protected override void OnResize(System.EventArgs e)
        {
            base.OnResize(e);

            if(this.Width>0 && this.Height>0 && engine!=null)
                engine.ResizeViewport(this.Width, this.Height);
        }

        /// <summary>
        /// Draws the control.
        /// </summary>
        protected override void Draw()
        {
            engine.Update();
            engine.Render();
        }
    }
}
