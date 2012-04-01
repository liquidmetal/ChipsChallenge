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
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolCommon = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.splitSide = new System.Windows.Forms.SplitContainer();
            this.gridProperties = new System.Windows.Forms.PropertyGrid();
            this.formRenderer = new LevelEditor.FormRenderer();
            this.menuMain.SuspendLayout();
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
            this.createToolStripMenuItem});
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
            this.floorToolStripMenuItem});
            this.createToolStripMenuItem.Name = "createToolStripMenuItem";
            this.createToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.createToolStripMenuItem.Text = "Create";
            // 
            // floorToolStripMenuItem
            // 
            this.floorToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuCreateTestFloor});
            this.floorToolStripMenuItem.Name = "floorToolStripMenuItem";
            this.floorToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.floorToolStripMenuItem.Text = "Floor >";
            // 
            // mnuCreateTestFloor
            // 
            this.mnuCreateTestFloor.Name = "mnuCreateTestFloor";
            this.mnuCreateTestFloor.Size = new System.Drawing.Size(126, 22);
            this.mnuCreateTestFloor.Text = "Test Floor";
            this.mnuCreateTestFloor.Click += new System.EventHandler(this.mnuCreateTestFloor_Click);
            // 
            // statusStrip
            // 
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
            // formRenderer
            // 
            this.formRenderer.Location = new System.Drawing.Point(0, 0);
            this.formRenderer.Name = "formRenderer";
            this.formRenderer.Size = new System.Drawing.Size(251, 220);
            this.formRenderer.TabIndex = 0;
            this.formRenderer.Text = "formRenderer2";
            this.formRenderer.MouseDown += new System.Windows.Forms.MouseEventHandler(this.formRenderer_MouseDown);
            this.formRenderer.MouseMove += new System.Windows.Forms.MouseEventHandler(this.formRenderer_MouseMove);
            this.formRenderer.MouseUp += new System.Windows.Forms.MouseEventHandler(this.formRenderer_MouseUp);
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
            this.MainMenuStrip = this.menuMain;
            this.Name = "MainForm";
            this.Text = "Chip\'s Challenge - Level Editor";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            this.menuMain.ResumeLayout(false);
            this.menuMain.PerformLayout();
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
    }
}

