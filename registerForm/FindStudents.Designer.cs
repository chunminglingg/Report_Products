namespace registerForm
{
    partial class FindStudents
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FindStudents));
            this.ImagesBox = new System.Windows.Forms.PictureBox();
            this.idLabel = new System.Windows.Forms.Label();
            this.tbIdForSearch = new System.Windows.Forms.TextBox();
            this.Search = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ImagesBox)).BeginInit();
            this.SuspendLayout();
            // 
            // ImagesBox
            // 
            this.ImagesBox.Image = ((System.Drawing.Image)(resources.GetObject("ImagesBox.Image")));
            this.ImagesBox.Location = new System.Drawing.Point(302, 53);
            this.ImagesBox.Name = "ImagesBox";
            this.ImagesBox.Size = new System.Drawing.Size(265, 254);
            this.ImagesBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ImagesBox.TabIndex = 0;
            this.ImagesBox.TabStop = false;
            // 
            // idLabel
            // 
            this.idLabel.AutoSize = true;
            this.idLabel.Location = new System.Drawing.Point(32, 31);
            this.idLabel.Name = "idLabel";
            this.idLabel.Size = new System.Drawing.Size(18, 16);
            this.idLabel.TabIndex = 8;
            this.idLabel.Text = "Id";
            // 
            // tbIdForSearch
            // 
            this.tbIdForSearch.Location = new System.Drawing.Point(32, 53);
            this.tbIdForSearch.Multiline = true;
            this.tbIdForSearch.Name = "tbIdForSearch";
            this.tbIdForSearch.Size = new System.Drawing.Size(246, 30);
            this.tbIdForSearch.TabIndex = 7;
            // 
            // Search
            // 
            this.Search.Location = new System.Drawing.Point(172, 89);
            this.Search.Name = "Search";
            this.Search.Size = new System.Drawing.Size(106, 37);
            this.Search.TabIndex = 9;
            this.Search.Text = "Search";
            this.Search.UseVisualStyleBackColor = true;
            this.Search.Click += new System.EventHandler(this.Search_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(471, 313);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(96, 38);
            this.btnExit.TabIndex = 10;
            this.btnExit.Text = "exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // FindStudents
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(691, 575);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.Search);
            this.Controls.Add(this.idLabel);
            this.Controls.Add(this.tbIdForSearch);
            this.Controls.Add(this.ImagesBox);
            this.Name = "FindStudents";
            this.Text = "FindStudents";
            this.Load += new System.EventHandler(this.FindStudents_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ImagesBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox ImagesBox;
        private System.Windows.Forms.Label idLabel;
        private System.Windows.Forms.TextBox tbIdForSearch;
        private System.Windows.Forms.Button Search;
        private System.Windows.Forms.Button btnExit;
    }
}