namespace EmployeeInterface
{
    partial class EmployeeInterface2
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
            this.searchGroupBox = new System.Windows.Forms.GroupBox();
            this.orLabel = new System.Windows.Forms.Label();
            this.quoteSearchButton = new System.Windows.Forms.Button();
            this.quoteSearchBox = new System.Windows.Forms.TextBox();
            this.selectQuoteButton = new System.Windows.Forms.Button();
            this.quoteSearchLabel = new System.Windows.Forms.Label();
            this.customerSearchLabel = new System.Windows.Forms.Label();
            this.customerSearchButton = new System.Windows.Forms.Button();
            this.selectQuoteBox = new System.Windows.Forms.ListBox();
            this.customerSearchBox = new System.Windows.Forms.TextBox();
            this.submitGroupBox = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.discountLabel = new System.Windows.Forms.Label();
            this.discountBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.totalPriceBox = new System.Windows.Forms.TextBox();
            this.totalPriceLabel = new System.Windows.Forms.Label();
            this.submitButton = new System.Windows.Forms.Button();
            this.searchGroupBox.SuspendLayout();
            this.submitGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // searchGroupBox
            // 
            this.searchGroupBox.Controls.Add(this.orLabel);
            this.searchGroupBox.Controls.Add(this.quoteSearchButton);
            this.searchGroupBox.Controls.Add(this.quoteSearchBox);
            this.searchGroupBox.Controls.Add(this.selectQuoteButton);
            this.searchGroupBox.Controls.Add(this.quoteSearchLabel);
            this.searchGroupBox.Controls.Add(this.customerSearchLabel);
            this.searchGroupBox.Controls.Add(this.customerSearchButton);
            this.searchGroupBox.Controls.Add(this.selectQuoteBox);
            this.searchGroupBox.Controls.Add(this.customerSearchBox);
            this.searchGroupBox.Location = new System.Drawing.Point(12, 12);
            this.searchGroupBox.Name = "searchGroupBox";
            this.searchGroupBox.Size = new System.Drawing.Size(379, 373);
            this.searchGroupBox.TabIndex = 14;
            this.searchGroupBox.TabStop = false;
            this.searchGroupBox.Text = "Search for a sanctioned Quote";
            // 
            // orLabel
            // 
            this.orLabel.AutoSize = true;
            this.orLabel.Location = new System.Drawing.Point(172, 72);
            this.orLabel.Name = "orLabel";
            this.orLabel.Size = new System.Drawing.Size(35, 13);
            this.orLabel.TabIndex = 10;
            this.orLabel.Text = "- OR -";
            // 
            // quoteSearchButton
            // 
            this.quoteSearchButton.Location = new System.Drawing.Point(285, 100);
            this.quoteSearchButton.Name = "quoteSearchButton";
            this.quoteSearchButton.Size = new System.Drawing.Size(75, 23);
            this.quoteSearchButton.TabIndex = 9;
            this.quoteSearchButton.Text = "Search";
            this.quoteSearchButton.UseVisualStyleBackColor = true;
            this.quoteSearchButton.Click += new System.EventHandler(this.quoteSearchButton_Click);
            // 
            // quoteSearchBox
            // 
            this.quoteSearchBox.Location = new System.Drawing.Point(19, 100);
            this.quoteSearchBox.Name = "quoteSearchBox";
            this.quoteSearchBox.Size = new System.Drawing.Size(260, 20);
            this.quoteSearchBox.TabIndex = 8;
            // 
            // selectQuoteButton
            // 
            this.selectQuoteButton.Cursor = System.Windows.Forms.Cursors.Default;
            this.selectQuoteButton.Location = new System.Drawing.Point(285, 334);
            this.selectQuoteButton.Name = "selectQuoteButton";
            this.selectQuoteButton.Size = new System.Drawing.Size(75, 23);
            this.selectQuoteButton.TabIndex = 5;
            this.selectQuoteButton.Text = "Select";
            this.selectQuoteButton.UseVisualStyleBackColor = true;
            this.selectQuoteButton.Click += new System.EventHandler(this.selectQuoteButton_Click);
            // 
            // quoteSearchLabel
            // 
            this.quoteSearchLabel.AutoSize = true;
            this.quoteSearchLabel.Location = new System.Drawing.Point(16, 84);
            this.quoteSearchLabel.Name = "quoteSearchLabel";
            this.quoteSearchLabel.Size = new System.Drawing.Size(67, 13);
            this.quoteSearchLabel.TabIndex = 7;
            this.quoteSearchLabel.Text = "Quote Name";
            // 
            // customerSearchLabel
            // 
            this.customerSearchLabel.AutoSize = true;
            this.customerSearchLabel.Location = new System.Drawing.Point(16, 24);
            this.customerSearchLabel.Name = "customerSearchLabel";
            this.customerSearchLabel.Size = new System.Drawing.Size(82, 13);
            this.customerSearchLabel.TabIndex = 6;
            this.customerSearchLabel.Text = "Customer Name";
            // 
            // customerSearchButton
            // 
            this.customerSearchButton.Cursor = System.Windows.Forms.Cursors.Default;
            this.customerSearchButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.customerSearchButton.Location = new System.Drawing.Point(285, 38);
            this.customerSearchButton.Name = "customerSearchButton";
            this.customerSearchButton.Size = new System.Drawing.Size(75, 22);
            this.customerSearchButton.TabIndex = 0;
            this.customerSearchButton.Text = "Search";
            this.customerSearchButton.UseVisualStyleBackColor = true;
            this.customerSearchButton.Click += new System.EventHandler(this.customerSearchButton_Click);
            // 
            // selectQuoteBox
            // 
            this.selectQuoteBox.BackColor = System.Drawing.SystemColors.Window;
            this.selectQuoteBox.FormattingEnabled = true;
            this.selectQuoteBox.Location = new System.Drawing.Point(19, 155);
            this.selectQuoteBox.Name = "selectQuoteBox";
            this.selectQuoteBox.Size = new System.Drawing.Size(341, 173);
            this.selectQuoteBox.TabIndex = 3;
            // 
            // customerSearchBox
            // 
            this.customerSearchBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.customerSearchBox.Location = new System.Drawing.Point(19, 40);
            this.customerSearchBox.Name = "customerSearchBox";
            this.customerSearchBox.Size = new System.Drawing.Size(260, 20);
            this.customerSearchBox.TabIndex = 2;
            // 
            // submitGroupBox
            // 
            this.submitGroupBox.Controls.Add(this.label2);
            this.submitGroupBox.Controls.Add(this.discountLabel);
            this.submitGroupBox.Controls.Add(this.discountBox);
            this.submitGroupBox.Controls.Add(this.label1);
            this.submitGroupBox.Controls.Add(this.totalPriceBox);
            this.submitGroupBox.Controls.Add(this.totalPriceLabel);
            this.submitGroupBox.Controls.Add(this.submitButton);
            this.submitGroupBox.Location = new System.Drawing.Point(397, 12);
            this.submitGroupBox.Name = "submitGroupBox";
            this.submitGroupBox.Size = new System.Drawing.Size(375, 373);
            this.submitGroupBox.TabIndex = 15;
            this.submitGroupBox.TabStop = false;
            this.submitGroupBox.Text = "Submit a Purchase Order";
            this.submitGroupBox.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label2.Location = new System.Drawing.Point(125, 181);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(16, 17);
            this.label2.TabIndex = 51;
            this.label2.Text = "$";
            // 
            // discountLabel
            // 
            this.discountLabel.AutoSize = true;
            this.discountLabel.Location = new System.Drawing.Point(140, 165);
            this.discountLabel.Name = "discountLabel";
            this.discountLabel.Size = new System.Drawing.Size(74, 13);
            this.discountLabel.TabIndex = 50;
            this.discountLabel.Text = "Final Discount";
            // 
            // discountBox
            // 
            this.discountBox.Location = new System.Drawing.Point(143, 181);
            this.discountBox.Name = "discountBox";
            this.discountBox.Size = new System.Drawing.Size(107, 20);
            this.discountBox.TabIndex = 49;
            this.discountBox.TextChanged += new System.EventHandler(this.discountBox_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label1.Location = new System.Drawing.Point(125, 128);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(16, 17);
            this.label1.TabIndex = 48;
            this.label1.Text = "$";
            // 
            // totalPriceBox
            // 
            this.totalPriceBox.BackColor = System.Drawing.SystemColors.Control;
            this.totalPriceBox.Location = new System.Drawing.Point(143, 127);
            this.totalPriceBox.Name = "totalPriceBox";
            this.totalPriceBox.ReadOnly = true;
            this.totalPriceBox.Size = new System.Drawing.Size(107, 20);
            this.totalPriceBox.TabIndex = 47;
            // 
            // totalPriceLabel
            // 
            this.totalPriceLabel.AutoSize = true;
            this.totalPriceLabel.Location = new System.Drawing.Point(140, 111);
            this.totalPriceLabel.Name = "totalPriceLabel";
            this.totalPriceLabel.Size = new System.Drawing.Size(58, 13);
            this.totalPriceLabel.TabIndex = 46;
            this.totalPriceLabel.Text = "Total Price";
            // 
            // submitButton
            // 
            this.submitButton.Cursor = System.Windows.Forms.Cursors.Default;
            this.submitButton.Location = new System.Drawing.Point(150, 238);
            this.submitButton.Name = "submitButton";
            this.submitButton.Size = new System.Drawing.Size(75, 23);
            this.submitButton.TabIndex = 5;
            this.submitButton.Text = "Submit";
            this.submitButton.UseVisualStyleBackColor = true;
            this.submitButton.Click += new System.EventHandler(this.submitButton_Click);
            // 
            // EmployeeInterface2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 402);
            this.Controls.Add(this.submitGroupBox);
            this.Controls.Add(this.searchGroupBox);
            this.Name = "EmployeeInterface2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EmployeeInterface2";
            this.searchGroupBox.ResumeLayout(false);
            this.searchGroupBox.PerformLayout();
            this.submitGroupBox.ResumeLayout(false);
            this.submitGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox searchGroupBox;
        private System.Windows.Forms.Label orLabel;
        private System.Windows.Forms.Button quoteSearchButton;
        private System.Windows.Forms.TextBox quoteSearchBox;
        private System.Windows.Forms.Button selectQuoteButton;
        private System.Windows.Forms.Label quoteSearchLabel;
        private System.Windows.Forms.Label customerSearchLabel;
        private System.Windows.Forms.Button customerSearchButton;
        private System.Windows.Forms.ListBox selectQuoteBox;
        private System.Windows.Forms.TextBox customerSearchBox;
        private System.Windows.Forms.GroupBox submitGroupBox;
        private System.Windows.Forms.Button submitButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox totalPriceBox;
        private System.Windows.Forms.Label totalPriceLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label discountLabel;
        private System.Windows.Forms.TextBox discountBox;
    }
}