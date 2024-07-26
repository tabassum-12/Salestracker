namespace EmployeeInterface
{
    partial class AppPicker
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
            this.editQuoteButton = new System.Windows.Forms.Button();
            this.createPOButton = new System.Windows.Forms.Button();
            this.manageSAButton = new System.Windows.Forms.Button();
            this.selectLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // editQuoteButton
            // 
            this.editQuoteButton.Location = new System.Drawing.Point(26, 70);
            this.editQuoteButton.Name = "editQuoteButton";
            this.editQuoteButton.Size = new System.Drawing.Size(140, 60);
            this.editQuoteButton.TabIndex = 0;
            this.editQuoteButton.Text = "Edit a Quote";
            this.editQuoteButton.UseVisualStyleBackColor = true;
            this.editQuoteButton.Click += new System.EventHandler(this.editQuoteButton_Click);
            // 
            // createPOButton
            // 
            this.createPOButton.Location = new System.Drawing.Point(172, 70);
            this.createPOButton.Name = "createPOButton";
            this.createPOButton.Size = new System.Drawing.Size(140, 60);
            this.createPOButton.TabIndex = 1;
            this.createPOButton.Text = "Create a Purchase Order";
            this.createPOButton.UseVisualStyleBackColor = true;
            this.createPOButton.Click += new System.EventHandler(this.createPOButton_Click);
            // 
            // manageSAButton
            // 
            this.manageSAButton.Location = new System.Drawing.Point(318, 70);
            this.manageSAButton.Name = "manageSAButton";
            this.manageSAButton.Size = new System.Drawing.Size(140, 60);
            this.manageSAButton.TabIndex = 2;
            this.manageSAButton.Text = "Manage Sales Associates";
            this.manageSAButton.UseVisualStyleBackColor = true;
            this.manageSAButton.Click += new System.EventHandler(this.manageSAButton_Click);
            // 
            // selectLabel
            // 
            this.selectLabel.AutoSize = true;
            this.selectLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.selectLabel.Location = new System.Drawing.Point(198, 30);
            this.selectLabel.Name = "selectLabel";
            this.selectLabel.Size = new System.Drawing.Size(89, 13);
            this.selectLabel.TabIndex = 3;
            this.selectLabel.Text = "Select an Activity";
            // 
            // AppPicker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 162);
            this.Controls.Add(this.selectLabel);
            this.Controls.Add(this.manageSAButton);
            this.Controls.Add(this.createPOButton);
            this.Controls.Add(this.editQuoteButton);
            this.Name = "AppPicker";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AppPicker";
            this.Load += new System.EventHandler(this.AppPicker_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button editQuoteButton;
        private System.Windows.Forms.Button createPOButton;
        private System.Windows.Forms.Button manageSAButton;
        private System.Windows.Forms.Label selectLabel;
    }
}