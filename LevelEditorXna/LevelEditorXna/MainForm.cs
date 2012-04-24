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
        private bool snapToIso = false;

        private int m_numEntities = 0;
        private int m_numLights = 0;

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

            //currentWorld.AddEntity(new Engine.Entities.Test.Cuboid());
            //currentWorld.AddEntity(new Engine.Entities.Lights.PointLight());

            UpdateViews();
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
            lstEntitiesList.Top = 2;
            lstEntitiesList.Left = 2;
            lstEntitiesList.Width = sz1.Width-4;
            lstEntitiesList.Height = sz1.Height-4;

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
            UpdateViews();
        }

        private void UpdateEntitiesList()
        {
            lstEntitiesList.Clear();

            List<Entity> lst = formRenderer.CurrentWorld.GetEntities();
            foreach(Entity ent in lst)
            {
                ListViewItem item = new ListViewItem(ent.Name);

                lstEntitiesList.Items.Add(item);
            }

            lstEntitiesList.Refresh();
        }

        private void formRenderer_MouseDown(object sender, MouseEventArgs e)
        {
            // Do stuff based on the current state
            Vector3 worldPos = formRenderer.CurrentRenderer.Unproject(new Vector2(e.X, e.Y));

            m_ptLastMouseClick = new Vector2(worldPos.X, worldPos.Y);

            Entity ent = currentRenderer.GetEntityAtPosition(currentWorld, (int)worldPos.X, (int)worldPos.Y);

            m_selectedEntity = ent;
            gridProperties.SelectedObject = m_selectedEntity;

            if (m_selectedEntity == null)
            {
                foreach (ListViewItem item in lstEntitiesList.Items)
                {
                    item.Selected = false;
                }
            }
            else
            {
                foreach (ListViewItem item in lstEntitiesList.Items)
                {
                    if (item.Text == m_selectedEntity.Name)
                    {
                        item.Selected = true;
                        item.EnsureVisible();
                    }
                    else
                        item.Selected = false;
                }
            }
        }

        private void formRenderer_MouseMove(object sender, MouseEventArgs e)
        {
            // Do stuff based on the current state
            Vector3 worldPos = formRenderer.CurrentRenderer.Unproject(new Vector2(e.X, e.Y));

            // If the middle button is pressed, we're panning the shot
            if(e.Button == System.Windows.Forms.MouseButtons.Middle)
            {
                Vector2 camPos = currentRenderer.CameraPosition;
                camPos.X -= (worldPos.X - m_ptLastMouseClick.X);
                camPos.Y -= (worldPos.Y - m_ptLastMouseClick.Y);

                currentRenderer.CameraPosition = camPos;

                formRenderer.Cursor = Cursors.SizeAll;

                m_ptLastMouseClick = new Vector2(worldPos.X, worldPos.Y);
            }

            // If the left button is pressed && an object is selected
            // we're moving that object
            if (e.Button == System.Windows.Forms.MouseButtons.Left && m_selectedEntity!=null)
            {
                Vector2 pos = m_selectedEntity.Position;

                pos.X += (worldPos.X - m_ptLastMouseClick.X);
                pos.Y += (worldPos.Y - m_ptLastMouseClick.Y);

                m_ptLastMouseClick = new Vector2(worldPos.X, worldPos.Y);

                if (snapToIso)
                {
                    pos -= new Vector2(pos.X % 10, pos.Y % 10);
                    m_ptLastMouseClick -= new Vector2(worldPos.X%10, worldPos.Y%10);
                }

                m_selectedEntity.Position = pos;

                
            }

            lblMousePosition.Text = "(" + e.X + ", " + e.Y + ")";
            lblWorldPosition.Text = "(" + (int)worldPos.X + ", " + (int)worldPos.Y + ", " + (int)worldPos.Z + ")";
        }

        private void formRenderer_MouseUp(object sender, MouseEventArgs e)
        {
            // Do stuff based on the current state
            gridProperties.SelectedObject = m_selectedEntity;
            formRenderer.Cursor = Cursors.Arrow;
        }

        private void cylinderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            currentWorld.AddEntity(new Engine.Entities.Test.Cylinder());
            UpdateViews();
        }

        private void mnuCreateTestTeapot_Click(object sender, EventArgs e)
        {
            currentWorld.AddEntity(new Engine.Entities.Test.Teapot());
            UpdateViews();
        }

        private void mnuCreatePointLight_Click(object sender, EventArgs e)
        {
            currentWorld.AddEntity(new Engine.Entities.Lights.PointLight("Light" + m_numLights));
            m_numLights++;

            UpdateViews();
        }

        private void mnuCreateCuboid_Click(object sender, EventArgs e)
        {
            currentWorld.AddEntity(new Engine.Entities.Test.Cuboid("Entity" + m_numEntities));
            m_numEntities++;

            UpdateViews();
        }

        private void houseAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            currentWorld.AddEntity(new Engine.Entities.Buildings.HouseA());
            UpdateViews();
        }

        private void planeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            currentWorld.AddEntity(new Engine.Entities.Test.Plane());
            UpdateViews();
        }

        private void UpdateViews()
        {
            UpdateEntitiesList();
        }

        public void SetDisplayPass(RenderSceneType rst)
        {
            formRenderer.OutputPass = rst;

            switch (rst)
            {
                case RenderSceneType.Beauty:
                    lblOutputPass.Text = "BTY";
                    break;

                case RenderSceneType.Diffuse:
                    lblOutputPass.Text = "DIF";
                    break;

                case RenderSceneType.Height:
                    lblOutputPass.Text = "HGT";
                    break;

                case RenderSceneType.Lights:
                    lblOutputPass.Text = "LGT";
                    break;

                case RenderSceneType.Normal:
                    lblOutputPass.Text = "NRM";
                    break;
            }
        }

        private void formRenderer_KeyDown(object sender, KeyEventArgs e)
        {
            
            
        }

        private void formRenderer_Click(object sender, EventArgs e)
        {

        }

        private void diffuseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetDisplayPass(RenderSceneType.Diffuse);
        }

        private void heightmapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetDisplayPass(RenderSceneType.Height);
        }

        private void normalsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetDisplayPass(RenderSceneType.Normal);
        }

        private void lightingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetDisplayPass(RenderSceneType.Lights);
        }

        private void beautyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetDisplayPass(RenderSceneType.Beauty);
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case System.Windows.Forms.Keys.A:
                    if (m_selectedEntity != null)
                        m_selectedEntity.Z += 1;
                    e.Handled = true;
                    break;

                case System.Windows.Forms.Keys.Z:
                    if (m_selectedEntity != null && m_selectedEntity.Z>0)
                        m_selectedEntity.Z -= 1;
                    e.Handled = true;
                    break;

                case System.Windows.Forms.Keys.Left:
                    if (m_selectedEntity != null)
                        m_selectedEntity.Position = new Vector2(m_selectedEntity.Position.X-1, m_selectedEntity.Position.Y);
                    e.Handled = true;
                    break;

                case System.Windows.Forms.Keys.Right:
                    if (m_selectedEntity != null)
                        m_selectedEntity.Position = new Vector2(m_selectedEntity.Position.X + 1, m_selectedEntity.Position.Y);
                    e.Handled = true;
                    break;

                case System.Windows.Forms.Keys.Up:
                    if (m_selectedEntity != null)
                        m_selectedEntity.Position = new Vector2(m_selectedEntity.Position.X, m_selectedEntity.Position.Y - 1);
                    e.Handled = true;
                    break;

                case System.Windows.Forms.Keys.Down:
                    if (m_selectedEntity != null)
                        m_selectedEntity.Position = new Vector2(m_selectedEntity.Position.X, m_selectedEntity.Position.Y + 1);
                    e.Handled = true;
                    break;
            }

            if (e.Handled == true)
            {
                gridProperties.SelectedObject = m_selectedEntity;
            }
        }

        private void straightXToolStripMenuItem_Click(object sender, EventArgs e)
        {
            currentWorld.AddEntity(new Engine.Entities.Streets.Modern.StreetStraightX());
        }

        private void mnuSnapToIso_Click(object sender, EventArgs e)
        {
            toggleSnapToIso();
        }

        private void toggleSnapToIso()
        {
            snapToIso = !snapToIso;
            mnuSnapToIso.Checked = snapToIso;
            btnEnableSnap.Checked = snapToIso;
        }

        private void btnEnableSnap_Click(object sender, EventArgs e)
        {
            toggleSnapToIso();
        }

        private void buildingsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void lstEntitiesList_Click(object sender, EventArgs e)
        {
            if (lstEntitiesList.SelectedItems.Count == 0)
                return;

            string name = lstEntitiesList.SelectedItems[0].Text;

            foreach (Entity ent in formRenderer.CurrentWorld.GetEntities())
            {
                if (ent.Name == name)
                {
                    m_selectedEntity = ent;
                    gridProperties.SelectedObject = ent;
                    break;
                }
            }
        }
    }
}
