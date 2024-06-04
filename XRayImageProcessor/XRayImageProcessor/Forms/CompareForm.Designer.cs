namespace XRayImageProcessor
{
    partial class CompareForm
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
            btnLoadImageA = new Button();
            btnLoadImageB = new Button();
            btnCompare = new Button();
            lblComparisonResult = new Label();
            pbXrayImageB = new PictureBox();
            pbXrayImageA = new PictureBox();
            tableLayoutPanel1 = new TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)pbXrayImageB).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbXrayImageA).BeginInit();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // btnLoadImageA
            // 
            btnLoadImageA.Location = new Point(12, 12);
            btnLoadImageA.Name = "btnLoadImageA";
            btnLoadImageA.Size = new Size(184, 40);
            btnLoadImageA.TabIndex = 0;
            btnLoadImageA.Text = "Load Old X-ray Image";
            btnLoadImageA.UseVisualStyleBackColor = true;
            btnLoadImageA.Click += BtnLoadImageA_Click;
            // 
            // btnLoadImageB
            // 
            btnLoadImageB.Location = new Point(394, 12);
            btnLoadImageB.Name = "btnLoadImageB";
            btnLoadImageB.Size = new Size(184, 40);
            btnLoadImageB.TabIndex = 1;
            btnLoadImageB.Text = "Load New X-ray Image";
            btnLoadImageB.UseVisualStyleBackColor = true;
            btnLoadImageB.Click += BtnLoadImageB_Click;
            // 
            // btnCompare
            // 
            btnCompare.Location = new Point(12, 504);
            btnCompare.Name = "btnCompare";
            btnCompare.Size = new Size(150, 40);
            btnCompare.TabIndex = 4;
            btnCompare.Text = "Compare";
            btnCompare.UseVisualStyleBackColor = true;
            btnCompare.Click += BtnCompare_Click;
            // 
            // lblComparisonResult
            // 
            lblComparisonResult.Location = new Point(168, 504);
            lblComparisonResult.Name = "lblComparisonResult";
            lblComparisonResult.Size = new Size(602, 40);
            lblComparisonResult.TabIndex = 5;
            lblComparisonResult.Text = "Comparison result will be displayed here.";
            lblComparisonResult.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pbXrayImageB
            // 
            pbXrayImageB.BorderStyle = BorderStyle.FixedSingle;
            pbXrayImageB.Dock = DockStyle.Fill;
            pbXrayImageB.Location = new Point(382, 3);
            pbXrayImageB.Name = "pbXrayImageB";
            pbXrayImageB.Size = new Size(373, 434);
            pbXrayImageB.SizeMode = PictureBoxSizeMode.Zoom;
            pbXrayImageB.TabIndex = 3;
            pbXrayImageB.TabStop = false;
            // 
            // pbXrayImageA
            // 
            pbXrayImageA.BorderStyle = BorderStyle.FixedSingle;
            pbXrayImageA.Dock = DockStyle.Fill;
            pbXrayImageA.Location = new Point(3, 3);
            pbXrayImageA.Name = "pbXrayImageA";
            pbXrayImageA.Size = new Size(373, 434);
            pbXrayImageA.SizeMode = PictureBoxSizeMode.Zoom;
            pbXrayImageA.TabIndex = 2;
            pbXrayImageA.TabStop = false;
            pbXrayImageA.Click += pbXrayImageA_Click;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(pbXrayImageA, 0, 0);
            tableLayoutPanel1.Controls.Add(pbXrayImageB, 1, 0);
            tableLayoutPanel1.Location = new Point(12, 58);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Size = new Size(758, 440);
            tableLayoutPanel1.TabIndex = 6;
            // 
            // CompareForm
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(782, 553);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(lblComparisonResult);
            Controls.Add(btnCompare);
            Controls.Add(btnLoadImageB);
            Controls.Add(btnLoadImageA);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "CompareForm";
            Text = "Compare X-ray Images";
            ((System.ComponentModel.ISupportInitialize)pbXrayImageB).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbXrayImageA).EndInit();
            tableLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        private System.Windows.Forms.Button btnLoadImageA;
        private System.Windows.Forms.Button btnLoadImageB;
        private System.Windows.Forms.Button btnCompare;
        private System.Windows.Forms.Label lblComparisonResult;

        private PictureBox pbXrayImageB;
        private PictureBox pbXrayImageA;
        private TableLayoutPanel tableLayoutPanel1;

        #endregion

    }
}