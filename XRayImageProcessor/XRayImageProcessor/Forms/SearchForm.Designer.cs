namespace XRayImageProcessor.Forms
{
    partial class SearchForm
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
            nudMinSize = new NumericUpDown();
            nudMaxSize = new NumericUpDown();
            dtpMinUpdateDate = new DateTimePicker();
            dtpMaxUpdateDate = new DateTimePicker();
            btnSearch = new Button();
            lvResults = new ListView();
            lblMinSize = new Label();
            lblMaxSize = new Label();
            lblMinDate = new Label();
            lblMaxDate = new Label();
            ((System.ComponentModel.ISupportInitialize)nudMinSize).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudMaxSize).BeginInit();
            SuspendLayout();
            // 
            // nudMinSize
            // 
            nudMinSize.Location = new Point(25, 56);
            nudMinSize.Maximum = new decimal(new int[] { 1048576, 0, 0, 0 });
            nudMinSize.Name = "nudMinSize";
            nudMinSize.Size = new Size(120, 29);
            nudMinSize.TabIndex = 0;
            // 
            // nudMaxSize
            // 
            nudMaxSize.Location = new Point(25, 148);
            nudMaxSize.Maximum = new decimal(new int[] { 1048576, 0, 0, 0 });
            nudMaxSize.Name = "nudMaxSize";
            nudMaxSize.Size = new Size(120, 29);
            nudMaxSize.TabIndex = 1;
            nudMaxSize.Value = new decimal(new int[] { 10000, 0, 0, 0 });
            // 
            // dtpMinUpdateDate
            // 
            dtpMinUpdateDate.Location = new Point(261, 56);
            dtpMinUpdateDate.Name = "dtpMinUpdateDate";
            dtpMinUpdateDate.Size = new Size(260, 29);
            dtpMinUpdateDate.TabIndex = 2;
            dtpMinUpdateDate.Value = new DateTime(2024, 6, 1, 1, 34, 0, 0);
            // 
            // dtpMaxUpdateDate
            // 
            dtpMaxUpdateDate.Location = new Point(261, 148);
            dtpMaxUpdateDate.Name = "dtpMaxUpdateDate";
            dtpMaxUpdateDate.Size = new Size(260, 29);
            dtpMaxUpdateDate.TabIndex = 3;
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(606, 227);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(260, 35);
            btnSearch.TabIndex = 4;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += BtnSearch_Click;
            // 
            // lvResults
            // 
            lvResults.Location = new Point(21, 268);
            lvResults.Name = "lvResults";
            lvResults.Size = new Size(845, 355);
            lvResults.TabIndex = 5;
            lvResults.UseCompatibleStateImageBehavior = false;
            lvResults.View = View.Details;
            // 
            // lblMinSize
            // 
            lblMinSize.Location = new Point(25, 23);
            lblMinSize.Name = "lblMinSize";
            lblMinSize.Size = new Size(120, 30);
            lblMinSize.TabIndex = 6;
            lblMinSize.Text = "Min Size (KB)";
            // 
            // lblMaxSize
            // 
            lblMaxSize.Location = new Point(25, 111);
            lblMaxSize.Name = "lblMaxSize";
            lblMaxSize.Size = new Size(120, 30);
            lblMaxSize.TabIndex = 7;
            lblMaxSize.Text = "Max Size (KB)";
            // 
            // lblMinDate
            // 
            lblMinDate.Location = new Point(261, 27);
            lblMinDate.Name = "lblMinDate";
            lblMinDate.Size = new Size(161, 26);
            lblMinDate.TabIndex = 8;
            lblMinDate.Text = "Min Update Date";
            // 
            // lblMaxDate
            // 
            lblMaxDate.Location = new Point(261, 119);
            lblMaxDate.Name = "lblMaxDate";
            lblMaxDate.Size = new Size(161, 26);
            lblMaxDate.TabIndex = 9;
            lblMaxDate.Text = "Max Update Date";
            // 
            // SearchForm
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(878, 635);
            Controls.Add(lblMaxDate);
            Controls.Add(lblMinDate);
            Controls.Add(lblMaxSize);
            Controls.Add(lblMinSize);
            Controls.Add(lvResults);
            Controls.Add(btnSearch);
            Controls.Add(dtpMaxUpdateDate);
            Controls.Add(dtpMinUpdateDate);
            Controls.Add(nudMaxSize);
            Controls.Add(nudMinSize);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "SearchForm";
            Text = "Search Images";
            Load += SearchForm_Load;
            ((System.ComponentModel.ISupportInitialize)nudMinSize).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudMaxSize).EndInit();
            ResumeLayout(false);
        }

        private System.Windows.Forms.NumericUpDown nudMinSize;
        private System.Windows.Forms.NumericUpDown nudMaxSize;
        private System.Windows.Forms.DateTimePicker dtpMinUpdateDate;
        private System.Windows.Forms.DateTimePicker dtpMaxUpdateDate;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.ListView lvResults;
        private System.Windows.Forms.Label lblMinSize;
        private System.Windows.Forms.Label lblMaxSize;
        private System.Windows.Forms.Label lblMinDate;
        private System.Windows.Forms.Label lblMaxDate;
        #endregion
    }
}