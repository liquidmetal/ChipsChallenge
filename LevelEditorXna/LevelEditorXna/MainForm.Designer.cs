namespace LevelEditor
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuMain = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.floorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCreateTestFloor = new System.Windows.Forms.ToolStripMenuItem();
            this.testToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.planeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCreateCuboid = new System.Windows.Forms.ToolStripMenuItem();
            this.cylinderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCreateTestTeapot = new System.Windows.Forms.ToolStripMenuItem();
            this.lightsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCreatePointLight = new System.Windows.Forms.ToolStripMenuItem();
            this.buildingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.houseAToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.renderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.beautyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.diffuseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.heightmapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.normalsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lightingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolCommon = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.splitSide = new System.Windows.Forms.SplitContainer();
            this.gridProperties = new System.Windows.Forms.PropertyGrid();
            this.streetsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modernToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.straightXToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.undoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.redoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.snapToIsoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblMousePosition = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblWorldPosition = new System.Windows.Forms.ToolStripStatusLabel();
            this.formRenderer = new LevelEditor.FormRenderer();
            this.lblOutputPass = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuMain.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.toolCommon.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitSide)).BeginInit();
            this.splitSide.Panel2.SuspendLayout();
            this.splitSide.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuMain
            // 
            this.menuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.createToolStripMenuItem,
            this.renderToolStripMenuItem});
            this.menuMain.Location = new System.Drawing.Point(0, 0);
            this.menuMain.Name = "menuMain";
            this.menuMain.Size = new System.Drawing.Size(592, 24);
            this.menuMain.TabIndex = 1;
            this.menuMain.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(92, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            // 
            // createToolStripMenuItem
            // 
            this.createToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.floorToolStripMenuItem,
            this.testToolStripMenuItem,
            this.lightsToolStripMenuItem,
            this.buildingsToolStripMenuItem,
            this.streetsToolStripMenuItem});
            this.createToolStripMenuItem.Name = "createToolStripMenuItem";
            this.createToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.createToolStripMenuItem.Text = "Create";
            // 
            // floorToolStripMenuItem
            // 
            this.floorToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuCreateTestFloor});
            this.floorToolStripMenuItem.Name = "floorToolStripMenuItem";
            this.floorToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.floorToolStripMenuItem.Text = "Floor >";
            // 
            // mnuCreateTestFloor
            // 
            this.mnuCreateTestFloor.Name = "mnuCreateTestFloor";
            this.mnuCreateTestFloor.Size = new System.Drawing.Size(126, 22);
            this.mnuCreateTestFloor.Text = "Test Floor";
            this.mnuCreateTestFloor.Click += new System.EventHandler(this.mnuCreateTestFloor_Click);
            // 
            // testToolStripMenuItem
            // 
            this.testToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.planeToolStripMenuItem,
            this.mnuCreateCuboid,
            this.cylinderToolStripMenuItem,
            this.mnuCreateTestTeapot});
            this.testToolStripMenuItem.Name = "testToolStripMenuItem";
            this.testToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.testToolStripMenuItem.Text = "Test";
            // 
            // planeToolStripMenuItem
            // 
            this.planeToolStripMenuItem.Name = "planeToolStripMenuItem";
            this.planeToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.planeToolStripMenuItem.Text = "Plane";
            this.planeToolStripMenuItem.Click += new System.EventHandler(this.planeToolStripMenuItem_Click);
            // 
            // mnuCreateCuboid
            // 
            this.mnuCreateCuboid.Name = "mnuCreateCuboid";
            this.mnuCreateCuboid.Size = new System.Drawing.Size(118, 22);
            this.mnuCreateCuboid.Text = "Cuboid";
            this.mnuCreateCuboid.Click += new System.EventHandler(this.mnuCreateCuboid_Click);
            // 
            // cylinderToolStripMenuItem
            // 
            this.cylinderToolStripMenuItem.Name = "cylinderToolStripMenuItem";
            this.cylinderToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.cylinderToolStripMenuItem.Text = "Cylinder";
            this.cylinderToolStripMenuItem.Click += new System.EventHandler(this.cylinderToolStripMenuItem_Click);
            // 
            // mnuCreateTestTeapot
            // 
            this.mnuCreateTestTeapot.Name = "mnuCreateTestTeapot";
            this.mnuCreateTestTeapot.Size = new System.Drawing.Size(118, 22);
            this.mnuCreateTestTeapot.Text = "Teapot";
            this.mnuCreateTestTeapot.Click += new System.EventHandler(this.mnuCreateTestTeapot_Click);
            // 
            // lightsToolStripMenuItem
            // 
            this.lightsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuCreatePointLight});
            this.lightsToolStripMenuItem.Name = "lightsToolStripMenuItem";
            this.lightsToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.lightsToolStripMenuItem.Text = "Lights";
            // 
            // mnuCreatePointLight
            // 
            this.mnuCreatePointLight.Name = "mnuCreatePointLight";
            this.mnuCreatePointLight.Size = new System.Drawing.Size(129, 22);
            this.mnuCreatePointLight.Text = "Point light";
            this.mnuCreatePointLight.Click += new System.EventHandler(this.mnuCreatePointLight_Click);
            // 
            // buildingsToolStripMenuItem
            // 
            this.buildingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.houseAToolStripMenuItem});
            this.buildingsToolStripMenuItem.Name = "buildingsToolStripMenuItem";
            this.buildingsToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.buildingsToolStripMenuItem.Text = "Buildings";
            // 
            // houseAToolStripMenuItem
            // 
            this.houseAToolStripMenuItem.Name = "houseAToolStripMenuItem";
            this.houseAToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
            this.houseAToolStripMenuItem.Text = "House A";
            this.houseAToolStripMenuItem.Click += new System.EventHandler(this.houseAToolStripMenuItem_Click);
            // 
            // renderToolStripMenuItem
            // 
            this.renderToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.beautyToolStripMenuItem,
            this.diffuseToolStripMenuItem,
            this.heightmapToolStripMenuItem,
            this.normalsToolStripMenuItem,
            this.lightingToolStripMenuItem});
            this.renderToolStripMenuItem.Name = "renderToolStripMenuItem";
            this.renderToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
            this.renderToolStripMenuItem.Text = "Render";
            // 
            // beautyToolStripMenuItem
            // 
            this.beautyToolStripMenuItem.Name = "beautyToolStripMenuItem";
            this.beautyToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D1)));
            this.beautyToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.beautyToolStripMenuItem.Text = "Beauty";
            this.beautyToolStripMenuItem.Click += new System.EventHandler(this.beautyToolStripMenuItem_Click);
            // 
            // diffuseToolStripMenuItem
            // 
            this.diffuseToolStripMenuItem.Name = "diffuseToolStripMenuItem";
            this.diffuseToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D2)));
            this.diffuseToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.diffuseToolStripMenuItem.Text = "Diffuse";
            this.diffuseToolStripMenuItem.Click += new System.EventHandler(this.diffuseToolStripMenuItem_Click);
            // 
            // heightmapToolStripMenuItem
            // 
            this.heightmapToolStripMenuItem.Name = "heightmapToolStripMenuItem";
            this.heightmapToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D3)));
            this.heightmapToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.heightmapToolStripMenuItem.Text = "Heightmap";
            this.heightmapToolStripMenuItem.Click += new System.EventHandler(this.heightmapToolStripMenuItem_Click);
            // 
            // normalsToolStripMenuItem
            // 
            this.normalsToolStripMenuItem.Name = "normalsToolStripMenuItem";
            this.normalsToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D4)));
            this.normalsToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.normalsToolStripMenuItem.Text = "Normals";
            this.normalsToolStripMenuItem.Click += new System.EventHandler(this.normalsToolStripMenuItem_Click);
            // 
            // lightingToolStripMenuItem
            // 
            this.lightingToolStripMenuItem.Name = "lightingToolStripMenuItem";
            this.lightingToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D5)));
            this.lightingToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.lightingToolStripMenuItem.Text = "Lighting";
            this.lightingToolStripMenuItem.Click += new System.EventHandler(this.lightingToolStripMenuItem_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.lblOutputPass,
            this.lblMousePosition,
            this.lblWorldPosition});
            this.statusStrip.Location = new System.Drawing.Point(0, 427);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(592, 22);
            this.statusStrip.TabIndex = 2;
            this.statusStrip.Text = "statusStrip1";
            // 
            // toolCommon
            // 
            this.toolCommon.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1});
            this.toolCommon.Location = new System.Drawing.Point(0, 24);
            this.toolCommon.Name = "toolCommon";
            this.toolCommon.Size = new System.Drawing.Size(592, 25);
            this.toolCommon.TabIndex = 3;
            this.toolCommon.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton1.Text = "toolStripButton1";
            // 
            // splitContainer
            // 
            this.splitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer.Location = new System.Drawing.Point(0, 52);
            this.splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.splitSide);
            this.splitContainer.Panel1.Resize += new System.EventHandler(this.splitContainer1_Panel1_Resize);
            this.splitContainer.Panel1MinSize = 200;
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.formRenderer);
            this.splitContainer.Panel2.Resize += new System.EventHandler(this.splitContainer1_Panel2_Resize);
            this.splitContainer.Size = new System.Drawing.Size(580, 355);
            this.splitContainer.SplitterDistance = 200;
            this.splitContainer.TabIndex = 4;
            this.splitContainer.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.splitContainer_SplitterMoved);
            // 
            // splitSide
            // 
            this.splitSide.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitSide.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitSide.Location = new System.Drawing.Point(0, 0);
            this.splitSide.Name = "splitSide";
            this.splitSide.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitSide.Panel1
            // 
            this.splitSide.Panel1.Resize += new System.EventHandler(this.splitContainer1_Panel1_Resize_1);
            // 
            // splitSide.Panel2
            // 
            this.splitSide.Panel2.Controls.Add(this.gridProperties);
            this.splitSide.Panel2.Resize += new System.EventHandler(this.splitContainer1_Panel2_Resize_1);
            this.splitSide.Panel2MinSize = 150;
            this.splitSide.Size = new System.Drawing.Size(200, 355);
            this.splitSide.SplitterDistance = 66;
            this.splitSide.TabIndex = 0;
            // 
            // gridProperties
            // 
            this.gridProperties.Location = new System.Drawing.Point(0, 0);
            this.gridProperties.Name = "gridProperties";
            this.gridProperties.Size = new System.Drawing.Size(130, 130);
            this.gridProperties.TabIndex = 0;
            // 
            // streetsToolStripMenuItem
            // 
            this.streetsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.modernToolStripMenuItem});
            this.streetsToolStripMenuItem.Name = "streetsToolStripMenuItem";
            this.streetsToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.streetsToolStripMenuItem.Text = "Streets";
            // 
            // modernToolStripMenuItem
            // 
            this.modernToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.straightXToolStripMenuItem});
            this.modernToolStripMenuItem.Name = "modernToolStripMenuItem";
            this.modernToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.modernToolStripMenuItem.Text = "Modern";
            // 
            // straightXToolStripMenuItem
            // 
            this.straightXToolStripMenuItem.Name = "straightXToolStripMenuItem";
            this.straightXToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
            this.straightXToolStripMenuItem.Text = "Straight-X";
            this.straightXToolStripMenuItem.Click += new System.EventHandler(this.straightXToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.undoToolStripMenuItem,
            this.redoToolStripMenuItem,
            this.toolStripMenuItem1,
            this.snapToIsoToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // undoToolStripMenuItem
            // 
            this.undoToolStripMenuItem.Name = "undoToolStripMenuItem";
            this.undoToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.undoToolStripMenuItem.Text = "Undo";
            // 
            // redoToolStripMenuItem
            // 
            this.redoToolStripMenuItem.Name = "redoToolStripMenuItem";
            this.redoToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.redoToolStripMenuItem.Text = "Redo";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(129, 6);
            // 
            // snapToIsoToolStripMenuItem
            // 
            this.snapToIsoToolStripMenuItem.Name = "snapToIsoToolStripMenuItem";
            this.snapToIsoToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.snapToIsoToolStripMenuItem.Text = "Snap to iso";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(321, 17);
            this.toolStripStatusLabel1.Spring = true;
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // lblMousePosition
            // 
            this.lblMousePosition.AutoSize = false;
            this.lblMousePosition.Name = "lblMousePosition";
            this.lblMousePosition.Size = new System.Drawing.Size(100, 17);
            // 
            // lblWorldPosition
            // 
            this.lblWorldPosition.AutoSize = false;
            this.lblWorldPosition.Name = "lblWorldPosition";
            this.lblWorldPosition.Size = new System.Drawing.Size(100, 17);
            // 
            // formRenderer
            // 
            this.formRenderer.Location = new System.Drawing.Point(0, 0);
            this.formRenderer.Name = "formRenderer";
            this.formRenderer.OutputPass = Engine.RenderSceneType.Beauty;
            this.formRenderer.Size = new System.Drawing.Size(251, 220);
            this.formRenderer.TabIndex = 0;
            this.formRenderer.Text = "formRenderer2";
            this.formRenderer.Click += new System.EventHandler(this.formRenderer_Click);
            this.formRenderer.KeyDown += new System.Windows.Forms.KeyEventHandler(this.formRenderer_KeyDown);
            this.formRenderer.MouseDown += new System.Windows.Forms.MouseEventHandler(this.formRenderer_MouseDown);
            this.formRenderer.MouseMove += new System.Windows.Forms.MouseEventHandler(this.formRenderer_MouseMove);
            this.formRenderer.MouseUp += new System.Windows.Forms.MouseEventHandler(this.formRenderer_MouseUp);
            // 
            // lblOutputPass
            // 
            this.lblOutputPass.AutoSize = false;
            this.lblOutputPass.Name = "lblOutputPass";
            this.lblOutputPass.Size = new System.Drawing.Size(25, 17);
            this.lblOutputPass.Tag = "";
            this.lblOutputPass.Text = "DIF";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(592, 449);
            this.Controls.Add(this.splitContainer);
            this.Controls.Add(this.toolCommon);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuMain);
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuMain;
            this.Name = "MainForm";
            this.Text = "Chip\'s Challenge - Level Editor";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            this.menuMain.ResumeLayout(false);
            this.menuMain.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.toolCommon.ResumeLayout(false);
            this.toolCommon.PerformLayout();
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.splitSide.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitSide)).EndInit();
            this.splitSide.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private FormRenderer formRenderer1;
        private FormRenderer formRenderer;
        private System.Windows.Forms.MenuStrip menuMain;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStrip toolCommon;
        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.SplitContainer splitSide;
        private System.Windows.Forms.PropertyGrid gridProperties;
        private System.Windows.Forms.ToolStripMenuItem createToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem floorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuCreateTestFloor;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripMenuItem testToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cylinderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuCreateTestTeapot;
        private System.Windows.Forms.ToolStripMenuItem lightsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuCreatePointLight;
        private System.Windows.Forms.ToolStripMenuItem mnuCreateCuboid;
        private System.Windows.Forms.ToolStripMenuItem buildingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem houseAToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem planeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem renderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem diffuseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem heightmapToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem normalsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lightingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem beautyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem streetsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modernToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem straightXToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem undoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem redoToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem snapToIsoToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel lblMousePosition;
        private System.Windows.Forms.ToolStripStatusLabel lblWorldPosition;
        private System.Windows.Forms.ToolStripStatusLabel lblOutputPass;
    }
}

