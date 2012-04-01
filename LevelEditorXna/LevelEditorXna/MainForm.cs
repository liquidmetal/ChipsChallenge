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

namespace LevelEditor
{
    public partial class MainForm : Form
    {
        World currentWorld = null;
        Renderer currentRenderer = null;

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
    }
}
