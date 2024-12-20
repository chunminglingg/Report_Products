namespace registerForm
{
    partial class LandingPage
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
            System.Windows.Forms.Button Sales;
            this.lbLanding = new System.Windows.Forms.Label();
            this.btnViewPeople = new System.Windows.Forms.Button();
            this.btnProducts = new System.Windows.Forms.Button();
            this.lbViewPeople = new System.Windows.Forms.Label();
            this.lbProducts = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            Sales = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbLanding
            // 
            this.lbLanding.AutoSize = true;
            this.lbLanding.Font = new System.Drawing.Font("Microsoft YaHei", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbLanding.Location = new System.Drawing.Point(321, 53);
            this.lbLanding.Name = "lbLanding";
            this.lbLanding.Size = new System.Drawing.Size(377, 37);
            this.lbLanding.TabIndex = 0;
            this.lbLanding.Text = "Welcome to landing page";
            // 
            // btnViewPeople
            // 
            this.btnViewPeople.Location = new System.Drawing.Point(450, 142);
            this.btnViewPeople.Name = "btnViewPeople";
            this.btnViewPeople.Size = new System.Drawing.Size(118, 43);
            this.btnViewPeople.TabIndex = 1;
            this.btnViewPeople.Text = "Students";
            this.btnViewPeople.UseVisualStyleBackColor = true;
            this.btnViewPeople.Click += new System.EventHandler(this.btnViewPeople_Click);
            // 
            // btnProducts
            // 
            this.btnProducts.Location = new System.Drawing.Point(450, 246);
            this.btnProducts.Name = "btnProducts";
            this.btnProducts.Size = new System.Drawing.Size(118, 43);
            this.btnProducts.TabIndex = 1;
            this.btnProducts.Text = "Products";
            this.btnProducts.UseVisualStyleBackColor = true;
            this.btnProducts.Click += new System.EventHandler(this.btnProducts_Click);
            // 
            // lbViewPeople
            // 
            this.lbViewPeople.AutoSize = true;
            this.lbViewPeople.Font = new System.Drawing.Font("Maiandra GD", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbViewPeople.Location = new System.Drawing.Point(475, 123);
            this.lbViewPeople.Name = "lbViewPeople";
            this.lbViewPeople.Size = new System.Drawing.Size(56, 16);
            this.lbViewPeople.TabIndex = 2;
            this.lbViewPeople.Text = "Student";
            // 
            // lbProducts
            // 
            this.lbProducts.AutoSize = true;
            this.lbProducts.Font = new System.Drawing.Font("Maiandra GD", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbProducts.Location = new System.Drawing.Point(475, 227);
            this.lbProducts.Name = "lbProducts";
            this.lbProducts.Size = new System.Drawing.Size(64, 16);
            this.lbProducts.TabIndex = 2;
            this.lbProducts.Text = "Products";
            // 
            // Sales
            // 
            Sales.Location = new System.Drawing.Point(450, 346);
            Sales.Name = "Sales";
            Sales.Size = new System.Drawing.Size(118, 44);
            Sales.TabIndex = 3;
            Sales.Text = "Sales";
            Sales.UseVisualStyleBackColor = true;
            Sales.Click += new System.EventHandler(this.Sales_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Maiandra GD", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(475, 327);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Products";
            // 
            // LandingPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1007, 565);
            this.Controls.Add(Sales);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbProducts);
            this.Controls.Add(this.lbViewPeople);
            this.Controls.Add(this.btnProducts);
            this.Controls.Add(this.btnViewPeople);
            this.Controls.Add(this.lbLanding);
            this.Name = "LandingPage";
            this.Text = "LandingPage";
            this.Load += new System.EventHandler(this.LandingPage_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbLanding;
        private System.Windows.Forms.Button btnViewPeople;
        private System.Windows.Forms.Button btnProducts;
        private System.Windows.Forms.Label lbViewPeople;
        private System.Windows.Forms.Label lbProducts;
        private System.Windows.Forms.Label label1;
    }
}