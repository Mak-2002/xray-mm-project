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
        private System.Windows.Forms.Button btnSelectColor;
        private System.Windows.Forms.Button btnUndo;
        private System.Windows.Forms.Button btnClassifyCondition;
        private System.Windows.Forms.Label lblClassificationResult;

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
            btnSelectColor = new Button();
            btnUndo = new Button();
            btnClassifyCondition = new Button();
            lblClassificationResult = new Label();
            gbFilters = new GroupBox();
            gbConditionClassification = new GroupBox();
            msFeatures = new MenuStrip();
            featuresToolStripMenuItem = new ToolStripMenuItem();
            searchImagesToolStripMenuItem = new ToolStripMenuItem();
            fourierTransformationToolStripMenuItem = new ToolStripMenuItem();
            lowPassToolStripMenuItem = new ToolStripMenuItem();
            highPassToolStripMenuItem = new ToolStripMenuItem();
            compare2ImagesForDiseaseProgressionToolStripMenuItem = new ToolStripMenuItem();
            generatePDFReportToolStripMenuItem = new ToolStripMenuItem();
            exportAsZIPFileToolStripMenuItem = new ToolStripMenuItem();
            shareToTelegramBotToolStripMenuItem = new ToolStripMenuItem();
            btnCropImage = new Button();
            gbDrawing = new GroupBox();
            cbShape = new ComboBox();
            lbShape = new Label();
            btnAddTextNote = new Button();
            btnAddVoiceNote = new Button();
            btnPlayVoiceNote = new Button();
            ((System.ComponentModel.ISupportInitialize)pbXrayImage).BeginInit();
            gbFilters.SuspendLayout();
            gbConditionClassification.SuspendLayout();
            msFeatures.SuspendLayout();
            gbDrawing.SuspendLayout();
            SuspendLayout();
            // 
            // btnLoadImage
            // 
            btnLoadImage.Location = new Point(14, 39);
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
            pbXrayImage.BorderStyle = BorderStyle.FixedSingle;
            pbXrayImage.Location = new Point(14, 85);
            pbXrayImage.Margin = new Padding(3, 4, 3, 4);
            pbXrayImage.Name = "pbXrayImage";
            pbXrayImage.Size = new Size(649, 482);
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
            cbFilters.Location = new Point(6, 39);
            cbFilters.Margin = new Padding(3, 4, 3, 4);
            cbFilters.Name = "cbFilters";
            cbFilters.Size = new Size(258, 29);
            cbFilters.TabIndex = 2;
            cbFilters.SelectedIndexChanged += cbFilters_SelectedIndexChanged;
            // 
            // btnApplyFilter
            // 
            btnApplyFilter.Location = new Point(531, 33);
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
            btnSaveImage.Location = new Point(554, 866);
            btnSaveImage.Margin = new Padding(3, 4, 3, 4);
            btnSaveImage.Name = "btnSaveImage";
            btnSaveImage.Size = new Size(112, 39);
            btnSaveImage.TabIndex = 4;
            btnSaveImage.Text = "Save Image";
            btnSaveImage.UseVisualStyleBackColor = true;
            btnSaveImage.Click += BtnSaveImage_Click;
            // 
            // btnSelectColor
            // 
            btnSelectColor.Location = new Point(270, 33);
            btnSelectColor.Name = "btnSelectColor";
            btnSelectColor.Size = new Size(112, 39);
            btnSelectColor.TabIndex = 5;
            btnSelectColor.Text = "Select Color";
            btnSelectColor.UseVisualStyleBackColor = true;
            btnSelectColor.Visible = false;
            btnSelectColor.Click += BtnSelectColor_Click;
            // 
            // btnUndo
            // 
            btnUndo.Location = new Point(552, 39);
            btnUndo.Margin = new Padding(3, 4, 3, 4);
            btnUndo.Name = "btnUndo";
            btnUndo.Size = new Size(112, 39);
            btnUndo.TabIndex = 6;
            btnUndo.Text = "Undo";
            btnUndo.UseVisualStyleBackColor = true;
            btnUndo.Click += BtnUndo_Click;
            // 
            // btnClassifyCondition
            // 
            btnClassifyCondition.Location = new Point(6, 28);
            btnClassifyCondition.Name = "btnClassifyCondition";
            btnClassifyCondition.Size = new Size(150, 40);
            btnClassifyCondition.TabIndex = 7;
            btnClassifyCondition.Text = "Classify Condition";
            btnClassifyCondition.UseVisualStyleBackColor = true;
            btnClassifyCondition.Click += BtnClassifyCondition_Click;
            // 
            // lblClassificationResult
            // 
            lblClassificationResult.Location = new Point(191, 28);
            lblClassificationResult.Name = "lblClassificationResult";
            lblClassificationResult.Size = new Size(452, 43);
            lblClassificationResult.TabIndex = 8;
            lblClassificationResult.Text = "Classification result will be displayed here.";
            lblClassificationResult.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // gbFilters
            // 
            gbFilters.Controls.Add(cbFilters);
            gbFilters.Controls.Add(btnSelectColor);
            gbFilters.Controls.Add(btnApplyFilter);
            gbFilters.Location = new Point(17, 669);
            gbFilters.Name = "gbFilters";
            gbFilters.Size = new Size(649, 89);
            gbFilters.TabIndex = 9;
            gbFilters.TabStop = false;
            gbFilters.Text = "Filters";
            // 
            // gbConditionClassification
            // 
            gbConditionClassification.Controls.Add(btnClassifyCondition);
            gbConditionClassification.Controls.Add(lblClassificationResult);
            gbConditionClassification.Location = new Point(17, 764);
            gbConditionClassification.Name = "gbConditionClassification";
            gbConditionClassification.Size = new Size(649, 89);
            gbConditionClassification.TabIndex = 10;
            gbConditionClassification.TabStop = false;
            gbConditionClassification.Text = "Condition Classification";
            // 
            // msFeatures
            // 
            msFeatures.ImageScalingSize = new Size(20, 20);
            msFeatures.Items.AddRange(new ToolStripItem[] { featuresToolStripMenuItem });
            msFeatures.Location = new Point(0, 0);
            msFeatures.Name = "msFeatures";
            msFeatures.Size = new Size(678, 29);
            msFeatures.TabIndex = 11;
            msFeatures.Text = "menuStrip1";
            // 
            // featuresToolStripMenuItem
            // 
            featuresToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { searchImagesToolStripMenuItem, fourierTransformationToolStripMenuItem, compare2ImagesForDiseaseProgressionToolStripMenuItem, generatePDFReportToolStripMenuItem, exportAsZIPFileToolStripMenuItem, shareToTelegramBotToolStripMenuItem });
            featuresToolStripMenuItem.Name = "featuresToolStripMenuItem";
            featuresToolStripMenuItem.Size = new Size(83, 25);
            featuresToolStripMenuItem.Text = "Features";
            // 
            // searchImagesToolStripMenuItem
            // 
            searchImagesToolStripMenuItem.Name = "searchImagesToolStripMenuItem";
            searchImagesToolStripMenuItem.Size = new Size(393, 26);
            searchImagesToolStripMenuItem.Text = "Search Images";
            searchImagesToolStripMenuItem.Click += searchImagesToolStripMenuItem_Click;
            // 
            // fourierTransformationToolStripMenuItem
            // 
            fourierTransformationToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { lowPassToolStripMenuItem, highPassToolStripMenuItem });
            fourierTransformationToolStripMenuItem.Name = "fourierTransformationToolStripMenuItem";
            fourierTransformationToolStripMenuItem.Size = new Size(393, 26);
            fourierTransformationToolStripMenuItem.Text = "Fourier Transformation";
            // 
            // lowPassToolStripMenuItem
            // 
            lowPassToolStripMenuItem.Name = "lowPassToolStripMenuItem";
            lowPassToolStripMenuItem.Size = new Size(161, 26);
            lowPassToolStripMenuItem.Text = "Low Pass";
            lowPassToolStripMenuItem.Click += lowPassToolStripMenuItem_Click;
            // 
            // highPassToolStripMenuItem
            // 
            highPassToolStripMenuItem.Name = "highPassToolStripMenuItem";
            highPassToolStripMenuItem.Size = new Size(161, 26);
            highPassToolStripMenuItem.Text = "High Pass";
            highPassToolStripMenuItem.Click += highPassToolStripMenuItem_Click;
            // 
            // compare2ImagesForDiseaseProgressionToolStripMenuItem
            // 
            compare2ImagesForDiseaseProgressionToolStripMenuItem.Name = "compare2ImagesForDiseaseProgressionToolStripMenuItem";
            compare2ImagesForDiseaseProgressionToolStripMenuItem.Size = new Size(393, 26);
            compare2ImagesForDiseaseProgressionToolStripMenuItem.Text = "Compare 2 Images for Disease Progression";
            compare2ImagesForDiseaseProgressionToolStripMenuItem.Click += compare2ImagesForDiseaseProgressionToolStripMenuItem_Click;
            // 
            // generatePDFReportToolStripMenuItem
            // 
            generatePDFReportToolStripMenuItem.Name = "generatePDFReportToolStripMenuItem";
            generatePDFReportToolStripMenuItem.Size = new Size(393, 26);
            generatePDFReportToolStripMenuItem.Text = "Generate PDF Report";
            generatePDFReportToolStripMenuItem.Click += generatePDFReportToolStripMenuItem_Click;
            // 
            // exportAsZIPFileToolStripMenuItem
            // 
            exportAsZIPFileToolStripMenuItem.Name = "exportAsZIPFileToolStripMenuItem";
            exportAsZIPFileToolStripMenuItem.Size = new Size(393, 26);
            exportAsZIPFileToolStripMenuItem.Text = "Export as ZIP File";
            exportAsZIPFileToolStripMenuItem.Click += exportAsZIPFileToolStripMenuItem_Click;
            // 
            // shareToTelegramBotToolStripMenuItem
            // 
            shareToTelegramBotToolStripMenuItem.Name = "shareToTelegramBotToolStripMenuItem";
            shareToTelegramBotToolStripMenuItem.Size = new Size(393, 26);
            shareToTelegramBotToolStripMenuItem.Text = "Share to Telegram Bot";
            shareToTelegramBotToolStripMenuItem.Click += shareToTelegramBotToolStripMenuItem_Click;
            // 
            // btnCropImage
            // 
            btnCropImage.Location = new Point(396, 38);
            btnCropImage.Name = "btnCropImage";
            btnCropImage.Size = new Size(150, 40);
            btnCropImage.TabIndex = 9;
            btnCropImage.Text = "Crop to Region";
            btnCropImage.UseVisualStyleBackColor = true;
            btnCropImage.Click += BtnCropImage_Click;
            // 
            // gbDrawing
            // 
            gbDrawing.Controls.Add(cbShape);
            gbDrawing.Controls.Add(lbShape);
            gbDrawing.Location = new Point(14, 574);
            gbDrawing.Name = "gbDrawing";
            gbDrawing.Size = new Size(649, 89);
            gbDrawing.TabIndex = 13;
            gbDrawing.TabStop = false;
            gbDrawing.Text = "Drawing";
            // 
            // cbShape
            // 
            cbShape.DropDownStyle = ComboBoxStyle.DropDownList;
            cbShape.FormattingEnabled = true;
            cbShape.Items.AddRange(new object[] { "Rectangle", "Triangle", "Curve", "Arrow" });
            cbShape.Location = new Point(68, 43);
            cbShape.Margin = new Padding(3, 4, 3, 4);
            cbShape.Name = "cbShape";
            cbShape.Size = new Size(258, 29);
            cbShape.TabIndex = 6;
            cbShape.SelectedIndexChanged += cbShape_SelectedIndexChanged;
            // 
            // lbShape
            // 
            lbShape.AutoSize = true;
            lbShape.Location = new Point(9, 46);
            lbShape.Name = "lbShape";
            lbShape.Size = new Size(53, 21);
            lbShape.TabIndex = 0;
            lbShape.Text = "Shape";
            // 
            // btnAddTextNote
            // 
            btnAddTextNote.Location = new Point(23, 866);
            btnAddTextNote.Name = "btnAddTextNote";
            btnAddTextNote.Size = new Size(150, 40);
            btnAddTextNote.TabIndex = 15;
            btnAddTextNote.Text = "Add Text Note";
            btnAddTextNote.UseVisualStyleBackColor = true;
            btnAddTextNote.Click += BtnAddTextNote_Click;
            // 
            // btnAddVoiceNote
            // 
            btnAddVoiceNote.Location = new Point(218, 866);
            btnAddVoiceNote.Name = "btnAddVoiceNote";
            btnAddVoiceNote.Size = new Size(150, 40);
            btnAddVoiceNote.TabIndex = 16;
            btnAddVoiceNote.Text = "Add Voice Note";
            btnAddVoiceNote.UseVisualStyleBackColor = true;
            btnAddVoiceNote.Click += btnAddVoiceNote_Click;
            // 
            // btnPlayVoiceNote
            // 
            btnPlayVoiceNote.Location = new Point(374, 865);
            btnPlayVoiceNote.Name = "btnPlayVoiceNote";
            btnPlayVoiceNote.Size = new Size(150, 40);
            btnPlayVoiceNote.TabIndex = 17;
            btnPlayVoiceNote.Text = "Play Voice Note";
            btnPlayVoiceNote.UseVisualStyleBackColor = true;
            btnPlayVoiceNote.Click += btnPlayVoiceNote_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(678, 918);
            Controls.Add(btnPlayVoiceNote);
            Controls.Add(btnAddVoiceNote);
            Controls.Add(gbDrawing);
            Controls.Add(gbConditionClassification);
            Controls.Add(btnAddTextNote);
            Controls.Add(gbFilters);
            Controls.Add(btnUndo);
            Controls.Add(btnSaveImage);
            Controls.Add(pbXrayImage);
            Controls.Add(btnLoadImage);
            Controls.Add(msFeatures);
            Controls.Add(btnCropImage);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MainMenuStrip = msFeatures;
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            Name = "MainForm";
            Text = "X-ray Image App";
            Load += MainForm_Load;
            ((System.ComponentModel.ISupportInitialize)pbXrayImage).EndInit();
            gbFilters.ResumeLayout(false);
            gbConditionClassification.ResumeLayout(false);
            msFeatures.ResumeLayout(false);
            msFeatures.PerformLayout();
            gbDrawing.ResumeLayout(false);
            gbDrawing.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        private GroupBox gbFilters;
        private GroupBox gbConditionClassification;
        private MenuStrip msFeatures;
        private System.Windows.Forms.Button btnCropImage;
        private ToolStripMenuItem featuresToolStripMenuItem;
        private ToolStripMenuItem searchImagesToolStripMenuItem;
        private ToolStripMenuItem fourierTransformationToolStripMenuItem;
        private ToolStripMenuItem lowPassToolStripMenuItem;
        private ToolStripMenuItem highPassToolStripMenuItem;
        private ToolStripMenuItem compare2ImagesForDiseaseProgressionToolStripMenuItem;
        private Button btnAddTextNote;
        private GroupBox gbDrawing;
        private ComboBox cbShape;
        private Label lbShape;

        #endregion

        private Button btnAddVoiceNote;
        private ToolStripMenuItem generatePDFReportToolStripMenuItem;
        private ToolStripMenuItem exportAsZIPFileToolStripMenuItem;
        private ToolStripMenuItem shareToTelegramBotToolStripMenuItem;
        private Button btnPlayVoiceNote;
    }
}
