using XRayImageProcessor;

namespace XRayImageProcessor
{
    partial class IntroductionForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IntroductionForm));
            lblIntroduction = new Label();
            btnOpenMainForm = new Button();
            btnOpenCompareForm = new Button();
            SuspendLayout();
            // 
            // lblIntroduction
            // 
            lblIntroduction.AutoSize = true;
            lblIntroduction.Location = new Point(12, 9);
            lblIntroduction.Name = "lblIntroduction";
            lblIntroduction.Size = new Size(642, 399);
            lblIntroduction.TabIndex = 0;
            lblIntroduction.Text = resources.GetString("lblIntroduction.Text");
            // 
            // btnOpenMainForm
            // 
            btnOpenMainForm.Location = new Point(55, 438);
            btnOpenMainForm.Name = "btnOpenMainForm";
            btnOpenMainForm.Size = new Size(200, 40);
            btnOpenMainForm.TabIndex = 1;
            btnOpenMainForm.Text = "Analyze Single Image";
            btnOpenMainForm.UseVisualStyleBackColor = true;
            btnOpenMainForm.Click += BtnOpenMainForm_Click;
            // 
            // btnOpenCompareForm
            // 
            btnOpenCompareForm.Location = new Point(418, 438);
            btnOpenCompareForm.Name = "btnOpenCompareForm";
            btnOpenCompareForm.Size = new Size(200, 40);
            btnOpenCompareForm.TabIndex = 2;
            btnOpenCompareForm.Text = "Compare Images";
            btnOpenCompareForm.UseVisualStyleBackColor = true;
            btnOpenCompareForm.Click += BtnOpenCompareForm_Click;
            // 
            // IntroductionForm
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(668, 490);
            Controls.Add(btnOpenCompareForm);
            Controls.Add(btnOpenMainForm);
            Controls.Add(lblIntroduction);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "IntroductionForm";
            Text = "Introduction";
            ResumeLayout(false);
            PerformLayout();
        }

        private System.Windows.Forms.Label lblIntroduction;
        private System.Windows.Forms.Button btnOpenMainForm;
        private System.Windows.Forms.Button btnOpenCompareForm;

        #endregion
    }


}