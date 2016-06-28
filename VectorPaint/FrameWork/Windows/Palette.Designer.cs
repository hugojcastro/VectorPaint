namespace VectorPaint.FrameWork.Windows
{
    partial class Palette
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
            this.dlgColor = new System.Windows.Forms.ColorDialog();
            this.btColor = new System.Windows.Forms.Button();
            this.nudSize = new System.Windows.Forms.NumericUpDown();
            this.btDropper = new System.Windows.Forms.Button();
            this.btCircle = new System.Windows.Forms.Button();
            this.btRectangle = new System.Windows.Forms.Button();
            this.btLine = new System.Windows.Forms.Button();
            this.btCursor = new System.Windows.Forms.Button();
            this.btFilledRectangle = new System.Windows.Forms.Button();
            this.btFilledCircle = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nudSize)).BeginInit();
            this.SuspendLayout();
            // 
            // dlgColor
            // 
            this.dlgColor.AnyColor = true;
            this.dlgColor.FullOpen = true;
            // 
            // btColor
            // 
            this.btColor.AutoSize = true;
            this.btColor.BackColor = System.Drawing.Color.Black;
            this.btColor.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btColor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btColor.Location = new System.Drawing.Point(1, 256);
            this.btColor.Margin = new System.Windows.Forms.Padding(0);
            this.btColor.Name = "btColor";
            this.btColor.Size = new System.Drawing.Size(36, 30);
            this.btColor.TabIndex = 7;
            this.btColor.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btColor.UseVisualStyleBackColor = false;
            this.btColor.Click += new System.EventHandler(this.btColorClick);
            // 
            // nudSize
            // 
            this.nudSize.Location = new System.Drawing.Point(1, 289);
            this.nudSize.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.nudSize.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudSize.Name = "nudSize";
            this.nudSize.Size = new System.Drawing.Size(36, 20);
            this.nudSize.TabIndex = 8;
            this.nudSize.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // btDropper
            // 
            this.btDropper.BackgroundImage = global::VectorPaint.Properties.Resources.icon_dropper;
            this.btDropper.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btDropper.FlatAppearance.BorderSize = 0;
            this.btDropper.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btDropper.Location = new System.Drawing.Point(1, 217);
            this.btDropper.Margin = new System.Windows.Forms.Padding(0);
            this.btDropper.Name = "btDropper";
            this.btDropper.Size = new System.Drawing.Size(36, 36);
            this.btDropper.TabIndex = 6;
            this.btDropper.Tag = "8";
            this.btDropper.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btDropper.UseVisualStyleBackColor = false;
            this.btDropper.Click += new System.EventHandler(this.toolButtonClick);
            // 
            // btCircle
            // 
            this.btCircle.BackgroundImage = global::VectorPaint.Properties.Resources.icon_circle;
            this.btCircle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btCircle.FlatAppearance.BorderSize = 0;
            this.btCircle.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btCircle.Location = new System.Drawing.Point(1, 109);
            this.btCircle.Margin = new System.Windows.Forms.Padding(0);
            this.btCircle.Name = "btCircle";
            this.btCircle.Size = new System.Drawing.Size(36, 36);
            this.btCircle.TabIndex = 5;
            this.btCircle.Tag = "7";
            this.btCircle.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btCircle.UseVisualStyleBackColor = false;
            this.btCircle.Click += new System.EventHandler(this.toolButtonClick);
            // 
            // btRectangle
            // 
            this.btRectangle.BackgroundImage = global::VectorPaint.Properties.Resources.icon_rectangle;
            this.btRectangle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btRectangle.FlatAppearance.BorderSize = 0;
            this.btRectangle.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btRectangle.Location = new System.Drawing.Point(1, 73);
            this.btRectangle.Margin = new System.Windows.Forms.Padding(0);
            this.btRectangle.Name = "btRectangle";
            this.btRectangle.Size = new System.Drawing.Size(36, 36);
            this.btRectangle.TabIndex = 4;
            this.btRectangle.Tag = "6";
            this.btRectangle.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btRectangle.UseVisualStyleBackColor = false;
            this.btRectangle.Click += new System.EventHandler(this.toolButtonClick);
            // 
            // btLine
            // 
            this.btLine.BackgroundImage = global::VectorPaint.Properties.Resources.icon_line;
            this.btLine.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btLine.FlatAppearance.BorderSize = 0;
            this.btLine.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btLine.Location = new System.Drawing.Point(1, 37);
            this.btLine.Margin = new System.Windows.Forms.Padding(0);
            this.btLine.Name = "btLine";
            this.btLine.Size = new System.Drawing.Size(36, 36);
            this.btLine.TabIndex = 3;
            this.btLine.Tag = "5";
            this.btLine.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btLine.UseVisualStyleBackColor = false;
            this.btLine.Click += new System.EventHandler(this.toolButtonClick);
            // 
            // btCursor
            // 
            this.btCursor.BackgroundImage = global::VectorPaint.Properties.Resources.icon_arrow;
            this.btCursor.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btCursor.FlatAppearance.BorderSize = 0;
            this.btCursor.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btCursor.Location = new System.Drawing.Point(1, 1);
            this.btCursor.Margin = new System.Windows.Forms.Padding(0);
            this.btCursor.Name = "btCursor";
            this.btCursor.Size = new System.Drawing.Size(36, 36);
            this.btCursor.TabIndex = 2;
            this.btCursor.Tag = "4";
            this.btCursor.UseVisualStyleBackColor = false;
            this.btCursor.Click += new System.EventHandler(this.toolButtonClick);
            // 
            // btFilledRectangle
            // 
            this.btFilledRectangle.BackgroundImage = global::VectorPaint.Properties.Resources.icon_filled_rectangle;
            this.btFilledRectangle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btFilledRectangle.FlatAppearance.BorderSize = 0;
            this.btFilledRectangle.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btFilledRectangle.Location = new System.Drawing.Point(1, 145);
            this.btFilledRectangle.Margin = new System.Windows.Forms.Padding(0);
            this.btFilledRectangle.Name = "btFilledRectangle";
            this.btFilledRectangle.Size = new System.Drawing.Size(36, 36);
            this.btFilledRectangle.TabIndex = 9;
            this.btFilledRectangle.Tag = "15";
            this.btFilledRectangle.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btFilledRectangle.UseVisualStyleBackColor = false;
            this.btFilledRectangle.Click += new System.EventHandler(this.toolButtonClick);
            // 
            // btFilledCircle
            // 
            this.btFilledCircle.BackgroundImage = global::VectorPaint.Properties.Resources.icon_filled_circle;
            this.btFilledCircle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btFilledCircle.FlatAppearance.BorderSize = 0;
            this.btFilledCircle.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btFilledCircle.Location = new System.Drawing.Point(1, 181);
            this.btFilledCircle.Margin = new System.Windows.Forms.Padding(0);
            this.btFilledCircle.Name = "btFilledCircle";
            this.btFilledCircle.Size = new System.Drawing.Size(36, 36);
            this.btFilledCircle.TabIndex = 10;
            this.btFilledCircle.Tag = "16";
            this.btFilledCircle.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btFilledCircle.UseVisualStyleBackColor = false;
            this.btFilledCircle.Click += new System.EventHandler(this.toolButtonClick);
            // 
            // Palette
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(38, 311);
            this.ControlBox = false;
            this.Controls.Add(this.btFilledCircle);
            this.Controls.Add(this.btFilledRectangle);
            this.Controls.Add(this.nudSize);
            this.Controls.Add(this.btColor);
            this.Controls.Add(this.btDropper);
            this.Controls.Add(this.btCircle);
            this.Controls.Add(this.btRectangle);
            this.Controls.Add(this.btLine);
            this.Controls.Add(this.btCursor);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(54, 350);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(54, 350);
            this.Name = "Palette";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Tools";
            ((System.ComponentModel.ISupportInitialize)(this.nudSize)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ColorDialog dlgColor;
        private System.Windows.Forms.Button btCursor;
        private System.Windows.Forms.Button btLine;
        private System.Windows.Forms.Button btRectangle;
        private System.Windows.Forms.Button btCircle;
        private System.Windows.Forms.Button btDropper;
        private System.Windows.Forms.Button btColor;
        private System.Windows.Forms.NumericUpDown nudSize;
        private System.Windows.Forms.Button btFilledRectangle;
        private System.Windows.Forms.Button btFilledCircle;
    }
}