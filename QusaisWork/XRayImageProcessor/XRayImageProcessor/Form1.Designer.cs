namespace XRayImageProcessor
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            tableLayoutPanel = new TableLayoutPanel();
            pictureBox = new PictureBox();
            buttonPanel = new Panel();
            btnUpload = new Button();
            btnSave = new Button();
            btnColor1 = new Button();
            btnColor2 = new Button();
            statusStrip = new StatusStrip();
            toolStripStatusLabel = new ToolStripStatusLabel();
            tableLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox).BeginInit();
            buttonPanel.SuspendLayout();
            statusStrip.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel
            // 
            tableLayoutPanel.ColumnCount = 1;
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel.Controls.Add(pictureBox, 0, 1);
            tableLayoutPanel.Controls.Add(buttonPanel, 0, 0);
            tableLayoutPanel.Controls.Add(statusStrip, 0, 2);
            tableLayoutPanel.Dock = DockStyle.Fill;
            tableLayoutPanel.Location = new Point(0, 0);
            tableLayoutPanel.Margin = new Padding(4, 5, 4, 5);
            tableLayoutPanel.Name = "tableLayoutPanel";
            tableLayoutPanel.RowCount = 3;
            tableLayoutPanel.RowStyles.Add(new RowStyle());
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel.RowStyles.Add(new RowStyle());
            tableLayoutPanel.Size = new Size(1200, 727);
            tableLayoutPanel.TabIndex = 0;
            // 
            // pictureBox
            // 
            pictureBox.Dock = DockStyle.Fill;
            pictureBox.Location = new Point(4, 86);
            pictureBox.Margin = new Padding(4, 5, 4, 5);
            pictureBox.Name = "pictureBox";
            pictureBox.Size = new Size(1192, 609);
            pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox.TabIndex = 0;
            pictureBox.TabStop = false;
            pictureBox.Click += pictureBox_Click;
            pictureBox.Paint += pictureBox_Paint;
            pictureBox.MouseDown += pictureBox_MouseDown;
            pictureBox.MouseMove += pictureBox_MouseMove;
            pictureBox.MouseUp += pictureBox_MouseUp;
            // 
            // buttonPanel
            // 
            buttonPanel.Controls.Add(btnUpload);
            buttonPanel.Controls.Add(btnSave);
            buttonPanel.Controls.Add(btnColor1);
            buttonPanel.Controls.Add(btnColor2);
            buttonPanel.Dock = DockStyle.Fill;
            buttonPanel.Location = new Point(4, 5);
            buttonPanel.Margin = new Padding(4, 5, 4, 5);
            buttonPanel.Name = "buttonPanel";
            buttonPanel.Size = new Size(1192, 71);
            buttonPanel.TabIndex = 1;
            // 
            // btnUpload
            // 
            btnUpload.AutoSize = true;
            btnUpload.Location = new Point(15, 16);
            btnUpload.Margin = new Padding(4, 5, 4, 5);
            btnUpload.Name = "btnUpload";
            btnUpload.Size = new Size(112, 50);
            btnUpload.TabIndex = 0;
            btnUpload.Text = "Upload";
            btnUpload.UseVisualStyleBackColor = true;
            btnUpload.Click += btnUpload_Click;
            // 
            // btnSave
            // 
            btnSave.AutoSize = true;
            btnSave.Location = new Point(135, 16);
            btnSave.Margin = new Padding(4, 5, 4, 5);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(112, 50);
            btnSave.TabIndex = 1;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnColor1
            // 
            btnColor1.AutoSize = true;
            btnColor1.Location = new Point(255, 16);
            btnColor1.Margin = new Padding(4, 5, 4, 5);
            btnColor1.Name = "btnColor1";
            btnColor1.Size = new Size(112, 50);
            btnColor1.TabIndex = 2;
            btnColor1.Text = "Filter 1";
            btnColor1.UseVisualStyleBackColor = true;
            btnColor1.Click += btnColor1_Click;
            // 
            // btnColor2
            // 
            btnColor2.AutoSize = true;
            btnColor2.Location = new Point(375, 16);
            btnColor2.Margin = new Padding(4, 5, 4, 5);
            btnColor2.Name = "btnColor2";
            btnColor2.Size = new Size(112, 50);
            btnColor2.TabIndex = 3;
            btnColor2.Text = "Filter 2";
            btnColor2.UseVisualStyleBackColor = true;
            btnColor2.Click += btnColor2_Click;
            // 
            // statusStrip
            // 
            statusStrip.ImageScalingSize = new Size(20, 20);
            statusStrip.Items.AddRange(new ToolStripItem[] { toolStripStatusLabel });
            statusStrip.Location = new Point(0, 700);
            statusStrip.Name = "statusStrip";
            statusStrip.Padding = new Padding(2, 0, 21, 0);
            statusStrip.Size = new Size(1200, 27);
            statusStrip.TabIndex = 2;
            statusStrip.Text = "statusStrip";
            // 
            // toolStripStatusLabel
            // 
            toolStripStatusLabel.Name = "toolStripStatusLabel";
            toolStripStatusLabel.Size = new Size(53, 21);
            toolStripStatusLabel.Text = "Ready";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1200, 727);
            Controls.Add(tableLayoutPanel);
            Margin = new Padding(4, 5, 4, 5);
            Name = "Form1";
            Text = "X-Ray Image Processor";
            tableLayoutPanel.ResumeLayout(false);
            tableLayoutPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox).EndInit();
            buttonPanel.ResumeLayout(false);
            buttonPanel.PerformLayout();
            statusStrip.ResumeLayout(false);
            statusStrip.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Panel buttonPanel;
        private System.Windows.Forms.Button btnUpload;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnColor1;
        private System.Windows.Forms.Button btnColor2;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
    }

}
