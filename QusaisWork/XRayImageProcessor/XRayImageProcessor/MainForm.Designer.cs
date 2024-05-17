namespace XRayImageProcessor
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

        private System.Windows.Forms.Button btnLoadImage;
        private System.Windows.Forms.PictureBox pbXrayImage;
        private System.Windows.Forms.ComboBox cbFilters;
        private System.Windows.Forms.Button btnApplyFilter;
        private System.Windows.Forms.Button btnSaveImage;

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnLoadImage = new Button();
            pbXrayImage = new PictureBox();
            cbFilters = new ComboBox();
            btnApplyFilter = new Button();
            btnSaveImage = new Button();
            ((System.ComponentModel.ISupportInitialize)pbXrayImage).BeginInit();
            SuspendLayout();
            // 
            // btnLoadImage
            // 
            btnLoadImage.Location = new Point(14, 16);
            btnLoadImage.Margin = new Padding(3, 4, 3, 4);
            btnLoadImage.Name = "btnLoadImage";
            btnLoadImage.Size = new Size(169, 39);
            btnLoadImage.TabIndex = 0;
            btnLoadImage.Text = "Load X-ray Image";
            btnLoadImage.UseVisualStyleBackColor = true;
            btnLoadImage.Click += BtnLoadImage_Click;
            // 
            // pbXrayImage
            // 
            pbXrayImage.Location = new Point(14, 66);
            pbXrayImage.Margin = new Padding(3, 4, 3, 4);
            pbXrayImage.Name = "pbXrayImage";
            pbXrayImage.Size = new Size(649, 600);
            pbXrayImage.SizeMode = PictureBoxSizeMode.Zoom;
            pbXrayImage.TabIndex = 1;
            pbXrayImage.TabStop = false;
            pbXrayImage.Paint += PbXrayImage_Paint;
            pbXrayImage.MouseDown += PbXrayImage_MouseDown;
            pbXrayImage.MouseMove += PbXrayImage_MouseMove;
            pbXrayImage.MouseUp += PbXrayImage_MouseUp;
            // 
            // cbFilters
            // 
            cbFilters.DropDownStyle = ComboBoxStyle.DropDownList;
            cbFilters.FormattingEnabled = true;
            cbFilters.Location = new Point(14, 735);
            cbFilters.Margin = new Padding(3, 4, 3, 4);
            cbFilters.Name = "cbFilters";
            cbFilters.Size = new Size(168, 29);
            cbFilters.TabIndex = 2;
            // 
            // btnApplyFilter
            // 
            btnApplyFilter.Location = new Point(191, 735);
            btnApplyFilter.Margin = new Padding(3, 4, 3, 4);
            btnApplyFilter.Name = "btnApplyFilter";
            btnApplyFilter.Size = new Size(112, 39);
            btnApplyFilter.TabIndex = 3;
            btnApplyFilter.Text = "Apply Filter";
            btnApplyFilter.UseVisualStyleBackColor = true;
            btnApplyFilter.Click += BtnApplyFilter_Click;
            // 
            // btnSaveImage
            // 
            btnSaveImage.Location = new Point(315, 735);
            btnSaveImage.Margin = new Padding(3, 4, 3, 4);
            btnSaveImage.Name = "btnSaveImage";
            btnSaveImage.Size = new Size(112, 39);
            btnSaveImage.TabIndex = 4;
            btnSaveImage.Text = "Save Image";
            btnSaveImage.UseVisualStyleBackColor = true;
            btnSaveImage.Click += BtnSaveImage_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(675, 788);
            Controls.Add(btnSaveImage);
            Controls.Add(btnApplyFilter);
            Controls.Add(cbFilters);
            Controls.Add(pbXrayImage);
            Controls.Add(btnLoadImage);
            Margin = new Padding(3, 4, 3, 4);
            Name = "MainForm";
            Text = "X-ray Image App";
            ((System.ComponentModel.ISupportInitialize)pbXrayImage).EndInit();
            ResumeLayout(false);
        }
        #endregion
    }
}