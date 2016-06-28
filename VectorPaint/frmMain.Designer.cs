namespace VectorPaint
{
    partial class frmMain
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.tsMain = new System.Windows.Forms.ToolStrip();
            this.tsbOpen = new System.Windows.Forms.ToolStripButton();
            this.tsbNew = new System.Windows.Forms.ToolStripButton();
            this.tsbSave = new System.Windows.Forms.ToolStripButton();
            this.tsbClose = new System.Windows.Forms.ToolStripButton();
            this.tsSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbUndo = new System.Windows.Forms.ToolStripButton();
            this.tsbRedo = new System.Windows.Forms.ToolStripButton();
            this.tsSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbZoomIn = new System.Windows.Forms.ToolStripButton();
            this.tsbZoomOut = new System.Windows.Forms.ToolStripButton();
            this.tsbExit = new System.Windows.Forms.ToolStripButton();
            this.tsbGrid = new System.Windows.Forms.ToolStripButton();
            this.tsbAbout = new System.Windows.Forms.ToolStripButton();
            this.ssStatus = new System.Windows.Forms.StatusStrip();
            this.tsslblZoom = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslblCoords = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslblDims = new System.Windows.Forms.ToolStripStatusLabel();
            this.pbCanvas = new System.Windows.Forms.PictureBox();
            this.dlgSave = new System.Windows.Forms.SaveFileDialog();
            this.dlgOpen = new System.Windows.Forms.OpenFileDialog();
            this.panelContainer = new System.Windows.Forms.Panel();
            this.tsMain.SuspendLayout();
            this.ssStatus.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbCanvas)).BeginInit();
            this.panelContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // tsMain
            // 
            this.tsMain.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tsMain.AutoSize = false;
            this.tsMain.Dock = System.Windows.Forms.DockStyle.None;
            this.tsMain.GripMargin = new System.Windows.Forms.Padding(0);
            this.tsMain.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.tsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbOpen,
            this.tsbNew,
            this.tsbSave,
            this.tsbClose,
            this.tsSeparator2,
            this.tsbUndo,
            this.tsbRedo,
            this.tsSeparator1,
            this.tsbZoomIn,
            this.tsbZoomOut,
            this.tsbExit,
            this.tsbGrid,
            this.tsbAbout});
            this.tsMain.Location = new System.Drawing.Point(0, 0);
            this.tsMain.Name = "tsMain";
            this.tsMain.Size = new System.Drawing.Size(661, 32);
            this.tsMain.TabIndex = 0;
            // 
            // tsbOpen
            // 
            this.tsbOpen.AutoSize = false;
            this.tsbOpen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbOpen.Image = global::VectorPaint.Properties.Resources.icon_open;
            this.tsbOpen.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbOpen.ImageTransparentColor = System.Drawing.Color.Red;
            this.tsbOpen.Margin = new System.Windows.Forms.Padding(0);
            this.tsbOpen.Name = "tsbOpen";
            this.tsbOpen.Size = new System.Drawing.Size(32, 32);
            this.tsbOpen.Text = "Open";
            this.tsbOpen.Click += new System.EventHandler(this.tsbOpenClick);
            // 
            // tsbNew
            // 
            this.tsbNew.AutoSize = false;
            this.tsbNew.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbNew.Image = global::VectorPaint.Properties.Resources.icon_new;
            this.tsbNew.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbNew.ImageTransparentColor = System.Drawing.Color.Red;
            this.tsbNew.Margin = new System.Windows.Forms.Padding(0);
            this.tsbNew.Name = "tsbNew";
            this.tsbNew.Size = new System.Drawing.Size(32, 32);
            this.tsbNew.Text = "New";
            this.tsbNew.Click += new System.EventHandler(this.tsbNewClick);
            // 
            // tsbSave
            // 
            this.tsbSave.AutoSize = false;
            this.tsbSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbSave.Enabled = false;
            this.tsbSave.Image = global::VectorPaint.Properties.Resources.icon_save;
            this.tsbSave.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbSave.ImageTransparentColor = System.Drawing.Color.Red;
            this.tsbSave.Margin = new System.Windows.Forms.Padding(0);
            this.tsbSave.Name = "tsbSave";
            this.tsbSave.Size = new System.Drawing.Size(32, 32);
            this.tsbSave.Text = "Save";
            this.tsbSave.Click += new System.EventHandler(this.tsbSaveClick);
            // 
            // tsbClose
            // 
            this.tsbClose.AutoSize = false;
            this.tsbClose.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbClose.Enabled = false;
            this.tsbClose.Image = global::VectorPaint.Properties.Resources.icon_close2;
            this.tsbClose.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbClose.ImageTransparentColor = System.Drawing.Color.Red;
            this.tsbClose.Margin = new System.Windows.Forms.Padding(0);
            this.tsbClose.Name = "tsbClose";
            this.tsbClose.Size = new System.Drawing.Size(32, 32);
            this.tsbClose.Text = "Close";
            this.tsbClose.Click += new System.EventHandler(this.tsbCloseClick);
            // 
            // tsSeparator2
            // 
            this.tsSeparator2.Name = "tsSeparator2";
            this.tsSeparator2.Size = new System.Drawing.Size(6, 32);
            // 
            // tsbUndo
            // 
            this.tsbUndo.AutoSize = false;
            this.tsbUndo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbUndo.Enabled = false;
            this.tsbUndo.Image = global::VectorPaint.Properties.Resources.icon_undo;
            this.tsbUndo.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbUndo.ImageTransparentColor = System.Drawing.Color.Red;
            this.tsbUndo.Margin = new System.Windows.Forms.Padding(0);
            this.tsbUndo.Name = "tsbUndo";
            this.tsbUndo.Size = new System.Drawing.Size(32, 32);
            this.tsbUndo.Text = "Undo";
            this.tsbUndo.Click += new System.EventHandler(this.tsbUndoClick);
            // 
            // tsbRedo
            // 
            this.tsbRedo.AutoSize = false;
            this.tsbRedo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbRedo.Enabled = false;
            this.tsbRedo.Image = global::VectorPaint.Properties.Resources.icon_redo;
            this.tsbRedo.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbRedo.ImageTransparentColor = System.Drawing.Color.Red;
            this.tsbRedo.Margin = new System.Windows.Forms.Padding(0);
            this.tsbRedo.Name = "tsbRedo";
            this.tsbRedo.Size = new System.Drawing.Size(32, 32);
            this.tsbRedo.Text = "Redo";
            this.tsbRedo.Click += new System.EventHandler(this.tsbRedoClick);
            // 
            // tsSeparator1
            // 
            this.tsSeparator1.Name = "tsSeparator1";
            this.tsSeparator1.Size = new System.Drawing.Size(6, 32);
            // 
            // tsbZoomIn
            // 
            this.tsbZoomIn.AutoSize = false;
            this.tsbZoomIn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbZoomIn.Enabled = false;
            this.tsbZoomIn.Image = global::VectorPaint.Properties.Resources.icon_zoom_in;
            this.tsbZoomIn.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbZoomIn.ImageTransparentColor = System.Drawing.Color.Red;
            this.tsbZoomIn.Margin = new System.Windows.Forms.Padding(0);
            this.tsbZoomIn.Name = "tsbZoomIn";
            this.tsbZoomIn.Size = new System.Drawing.Size(32, 32);
            this.tsbZoomIn.Text = "Zoom In";
            this.tsbZoomIn.Click += new System.EventHandler(this.tsbZoomInClick);
            // 
            // tsbZoomOut
            // 
            this.tsbZoomOut.AutoSize = false;
            this.tsbZoomOut.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbZoomOut.Enabled = false;
            this.tsbZoomOut.Image = global::VectorPaint.Properties.Resources.icon_zoom_out;
            this.tsbZoomOut.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbZoomOut.ImageTransparentColor = System.Drawing.Color.Red;
            this.tsbZoomOut.Margin = new System.Windows.Forms.Padding(0);
            this.tsbZoomOut.Name = "tsbZoomOut";
            this.tsbZoomOut.Size = new System.Drawing.Size(32, 32);
            this.tsbZoomOut.Text = "Zoom Out";
            this.tsbZoomOut.Click += new System.EventHandler(this.tsbZoomOutClick);
            // 
            // tsbExit
            // 
            this.tsbExit.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsbExit.AutoSize = false;
            this.tsbExit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbExit.Image = global::VectorPaint.Properties.Resources.icon_exit;
            this.tsbExit.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbExit.ImageTransparentColor = System.Drawing.Color.Red;
            this.tsbExit.Margin = new System.Windows.Forms.Padding(0);
            this.tsbExit.Name = "tsbExit";
            this.tsbExit.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tsbExit.Size = new System.Drawing.Size(32, 32);
            this.tsbExit.Text = "Exit";
            this.tsbExit.Click += new System.EventHandler(this.tsbExitClick);
            // 
            // tsbGrid
            // 
            this.tsbGrid.AutoSize = false;
            this.tsbGrid.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbGrid.Enabled = false;
            this.tsbGrid.Image = global::VectorPaint.Properties.Resources.icon_grid_on;
            this.tsbGrid.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbGrid.ImageTransparentColor = System.Drawing.Color.Red;
            this.tsbGrid.Margin = new System.Windows.Forms.Padding(0);
            this.tsbGrid.Name = "tsbGrid";
            this.tsbGrid.Size = new System.Drawing.Size(32, 32);
            this.tsbGrid.Tag = "on";
            this.tsbGrid.Text = "Enable Grid";
            this.tsbGrid.Click += new System.EventHandler(this.tsbGridClick);
            // 
            // tsbAbout
            // 
            this.tsbAbout.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsbAbout.AutoSize = false;
            this.tsbAbout.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbAbout.Image = global::VectorPaint.Properties.Resources.icon_about;
            this.tsbAbout.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbAbout.ImageTransparentColor = System.Drawing.Color.Red;
            this.tsbAbout.Margin = new System.Windows.Forms.Padding(0);
            this.tsbAbout.Name = "tsbAbout";
            this.tsbAbout.Size = new System.Drawing.Size(32, 32);
            this.tsbAbout.Text = "About";
            this.tsbAbout.Click += new System.EventHandler(this.tsbAboutClick);
            // 
            // ssStatus
            // 
            this.ssStatus.AutoSize = false;
            this.ssStatus.GripMargin = new System.Windows.Forms.Padding(0);
            this.ssStatus.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.ssStatus.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsslblZoom,
            this.tsslblCoords,
            this.tsslblDims});
            this.ssStatus.Location = new System.Drawing.Point(0, 357);
            this.ssStatus.Name = "ssStatus";
            this.ssStatus.Size = new System.Drawing.Size(661, 19);
            this.ssStatus.TabIndex = 2;
            this.ssStatus.Text = "statusStrip1";
            // 
            // tsslblZoom
            // 
            this.tsslblZoom.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsslblZoom.Name = "tsslblZoom";
            this.tsslblZoom.Size = new System.Drawing.Size(35, 14);
            this.tsslblZoom.Text = "100%";
            // 
            // tsslblCoords
            // 
            this.tsslblCoords.AutoSize = false;
            this.tsslblCoords.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsslblCoords.Name = "tsslblCoords";
            this.tsslblCoords.Size = new System.Drawing.Size(100, 14);
            this.tsslblCoords.Text = "1024 x 1024";
            this.tsslblCoords.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay;
            // 
            // tsslblDims
            // 
            this.tsslblDims.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsslblDims.Name = "tsslblDims";
            this.tsslblDims.Size = new System.Drawing.Size(66, 14);
            this.tsslblDims.Text = "1024 x 1024";
            // 
            // pbCanvas
            // 
            this.pbCanvas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pbCanvas.BackColor = System.Drawing.SystemColors.Control;
            this.pbCanvas.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pbCanvas.ErrorImage = null;
            this.pbCanvas.InitialImage = null;
            this.pbCanvas.Location = new System.Drawing.Point(0, 0);
            this.pbCanvas.Name = "pbCanvas";
            this.pbCanvas.Size = new System.Drawing.Size(661, 322);
            this.pbCanvas.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbCanvas.TabIndex = 1;
            this.pbCanvas.TabStop = false;
            this.pbCanvas.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pbCanvasMouseDown);
            this.pbCanvas.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pbCanvasMouseMove);
            this.pbCanvas.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pbCanvasMouseUp);
            // 
            // dlgSave
            // 
            this.dlgSave.Filter = "PNG Files (*.png)|*.png";
            this.dlgSave.Title = "Select file to save image...";
            // 
            // dlgOpen
            // 
            this.dlgOpen.Filter = "PNG Files (*.png)|*.png|All Files (*.*)|*.*";
            this.dlgOpen.ShowReadOnly = true;
            // 
            // panelContainer
            // 
            this.panelContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelContainer.AutoScroll = true;
            this.panelContainer.BackColor = System.Drawing.Color.White;
            this.panelContainer.Controls.Add(this.pbCanvas);
            this.panelContainer.Location = new System.Drawing.Point(0, 32);
            this.panelContainer.Name = "panelContainer";
            this.panelContainer.Size = new System.Drawing.Size(661, 322);
            this.panelContainer.TabIndex = 3;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(661, 376);
            this.Controls.Add(this.ssStatus);
            this.Controls.Add(this.tsMain);
            this.Controls.Add(this.panelContainer);
            this.DoubleBuffered = true;
            this.MinimumSize = new System.Drawing.Size(395, 284);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Vector Paint Test";
            this.tsMain.ResumeLayout(false);
            this.tsMain.PerformLayout();
            this.ssStatus.ResumeLayout(false);
            this.ssStatus.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbCanvas)).EndInit();
            this.panelContainer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStrip tsMain;
        private System.Windows.Forms.PictureBox pbCanvas;
        private System.Windows.Forms.ToolStripButton tsbZoomIn;
        private System.Windows.Forms.ToolStripButton tsbZoomOut;
        private System.Windows.Forms.ToolStripButton tsbExit;
        private System.Windows.Forms.ToolStripButton tsbGrid;
        private System.Windows.Forms.StatusStrip ssStatus;
        private System.Windows.Forms.ToolStripStatusLabel tsslblCoords;
        private System.Windows.Forms.ToolStripStatusLabel tsslblZoom;
        private System.Windows.Forms.ToolStripStatusLabel tsslblDims;
        private System.Windows.Forms.ToolStripButton tsbOpen;
        private System.Windows.Forms.ToolStripButton tsbNew;
        private System.Windows.Forms.ToolStripButton tsbClose;
        private System.Windows.Forms.ToolStripSeparator tsSeparator2;
        private System.Windows.Forms.ToolStripButton tsbUndo;
        private System.Windows.Forms.ToolStripButton tsbRedo;
        private System.Windows.Forms.ToolStripSeparator tsSeparator1;
        private System.Windows.Forms.ToolStripButton tsbSave;
        private System.Windows.Forms.ToolStripButton tsbAbout;
        private System.Windows.Forms.SaveFileDialog dlgSave;
        private System.Windows.Forms.OpenFileDialog dlgOpen;
        private System.Windows.Forms.Panel panelContainer;
    }
}

