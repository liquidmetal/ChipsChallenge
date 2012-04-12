using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

using Engine;
using Engine.Entities;
using Engine.Entities.Test;

namespace LevelEditor
{
    enum CurrentState { NothingSelected, Selected, Moving };

    public partial class MainForm : Form
    {
        World currentWorld = null;
        Renderer currentRenderer = null;


        Entity m_selectedEntity = null;
        private Vector2 m_ptLastMouseClick;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            splitContainer.SplitterDistance = 100;
            splitContainer.Invalidate();
            ResizeViews();

            currentWorld = formRenderer.CurrentWorld;
            currentRenderer = formRenderer.CurrentRenderer;
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            ResizeViews();
        }

        private void ResizeViews()
        {
            // Setup the main container's size
            splitContainer.Height = this.ClientSize.Height - statusStrip.Height - toolCommon.Height - menuMain.Height - 10;
            splitContainer.Width = this.ClientSize.Width - 10;

            // Setup the side splitter
            splitSide.Height = splitContainer.ClientSize.Height;
            splitSide.Width = splitContainer.Panel1.ClientSize.Width;

            // Setup the upper left window
            Size sz1 = splitSide.Panel1.ClientSize;

            // Setup the lower left window
            Size sz2 = splitSide.Panel2.ClientSize;
            gridProperties.Size = sz2;

            // Setup the render area's size
            Size sz = splitContainer.Panel2.ClientSize;
            formRenderer.Height = sz.Height;
            formRenderer.Width = sz.Width;
        }

        private void splitContainer1_Panel2_Resize(object sender, EventArgs e)
        {
            ResizeViews();
        }

        private void splitContainer_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }

        private void splitContainer1_Panel1_Resize(object sender, EventArgs e)
        {
            ResizeViews();
        }

        private void splitContainer1_Panel2_Resize_1(object sender, EventArgs e)
        {
            ResizeViews();
        }

        private void splitContainer1_Panel1_Resize_1(object sender, EventArgs e)
        {
            ResizeViews();
        }

        private void mnuCreateTestFloor_Click(object sender, EventArgs e)
        {
            currentWorld.AddEntity(new FloorTile());
        }

        private void formRenderer_MouseDown(object sender, MouseEventArgs e)
        {
            // Do stuff based on the current state

            m_ptLastMouseClick = new Vector2(e.X, e.Y);

            Entity ent = currentRenderer.GetEntityAtPosition(currentWorld, e.X, e.Y);

            m_selectedEntity = ent;
            gridProperties.SelectedObject = m_selectedEntity;
        }

        private void formRenderer_MouseMove(object sender, MouseEventArgs e)
        {
            // Do stuff based on the current state

            // If the middle button is pressed, we're panning the shot
            if(e.Button == System.Windows.Forms.MouseButtons.Middle)
            {
                Vector2 camPos = currentRenderer.CameraPosition;
                camPos.X += (e.X - m_ptLastMouseClick.X);
                camPos.Y += (e.Y - m_ptLastMouseClick.Y);

                currentRenderer.CameraPosition = camPos;

                m_ptLastMouseClick = new Vector2(e.X, e.Y);
            }

            // If the left button is pressed && an object is selected
            // we're moving that object
            if (e.Button == System.Windows.Forms.MouseButtons.Left && m_selectedEntity!=null)
            {
                Vector2 pos = m_selectedEntity.Position;

                pos.X += (e.X - m_ptLastMouseClick.X);
                pos.Y += (e.Y - m_ptLastMouseClick.Y);

                m_selectedEntity.Position = pos;

                m_ptLastMouseClick = new Vector2(e.X, e.Y);
            }
        }

        private void formRenderer_MouseUp(object sender, MouseEventArgs e)
        {
            // Do stuff based on the current state
            gridProperties.SelectedObject = m_selectedEntity;
        }

        private void cylinderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            currentWorld.AddEntity(new Engine.Entities.Test.Cylinder());
        }

        private void mnuCreateTestTeapot_Click(object sender, EventArgs e)
        {
            currentWorld.AddEntity(new Engine.Entities.Test.Teapot());
        }

        private void mnuCreatePointLight_Click(object sender, EventArgs e)
        {
            currentWorld.AddEntity(new Engine.Entities.Lights.PointLight());
        }

        private void mnuCreateCuboid_Click(object sender, EventArgs e)
        {
            currentWorld.AddEntity(new Engine.Entities.Test.Cuboid());
        }

        private void houseAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            currentWorld.AddEntity(new Engine.Entities.Buildings.HouseA());
        }

        private void planeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            currentWorld.AddEntity(new Engine.Entities.Test.Plane());
        }

        private void formRenderer_KeyDown(object sender, KeyEventArgs e)
        {
            switch(e.KeyCode)
            {
                case System.Windows.Forms.Keys.D1:
                    formRenderer.OutputPass = RenderSceneType.Diffuse;
                    break;

                case System.Windows.Forms.Keys.D2:
                    formRenderer.OutputPass = RenderSceneType.Height;
                    break;

                case System.Windows.Forms.Keys.D3:
                    formRenderer.OutputPass = RenderSceneType.Normal;
                    break;

                case System.Windows.Forms.Keys.D4:
                    formRenderer.OutputPass = RenderSceneType.Lights;
                    break;
            }
            
        }

        private void formRenderer_Click(object sender, EventArgs e)
        {

        }

        private void diffuseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formRenderer.OutputPass = RenderSceneType.Diffuse;
        }

        private void heightmapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formRenderer.OutputPass = RenderSceneType.Height;
        }

        private void normalsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formRenderer.OutputPass = RenderSceneType.Normal;
        }

        private void lightingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formRenderer.OutputPass = RenderSceneType.Lights;
        }

        private void beautyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formRenderer.OutputPass = RenderSceneType.Beauty;
        }
    }
}
