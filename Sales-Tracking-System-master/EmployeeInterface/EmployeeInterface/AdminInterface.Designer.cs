namespace EmployeeInterface
{
    partial class AdminInterface
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
            this.addButton = new System.Windows.Forms.Button();
            this.orLabel = new System.Windows.Forms.Label();
            this.nameSearchButton = new System.Windows.Forms.Button();
            this.nameSearchBox = new System.Windows.Forms.TextBox();
            this.selectButton = new System.Windows.Forms.Button();
            this.nameSearchLabel = new System.Windows.Forms.Label();
            this.idSearchLabel = new System.Windows.Forms.Label();
            this.idSearchButton = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            this.selectBox = new System.Windows.Forms.ListBox();
            this.idSearchBox = new System.Windows.Forms.TextBox();
            this.editGroupBox = new System.Windows.Forms.GroupBox();
            this.commissionLabel = new System.Windows.Forms.Label();
            this.commissionBox = new System.Windows.Forms.TextBox();
            this.passwordBox = new System.Windows.Forms.TextBox();
            this.passwordLabel = new System.Windows.Forms.Label();
            this.idLabel = new System.Windows.Forms.Label();
            this.idBox = new System.Windows.Forms.TextBox();
            this.addressLabel = new System.Windows.Forms.Label();
            this.addressBox = new System.Windows.Forms.TextBox();
            this.submitButton = new System.Windows.Forms.Button();
            this.nameLabel = new System.Windows.Forms.Label();
            this.nameBox = new System.Windows.Forms.TextBox();
            this.searchGroupBox.SuspendLayout();
            this.editGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // searchGroupBox
            // 
            this.searchGroupBox.Controls.Add(this.addButton);
            this.searchGroupBox.Controls.Add(this.orLabel);
            this.searchGroupBox.Controls.Add(this.nameSearchButton);
            this.searchGroupBox.Controls.Add(this.nameSearchBox);
            this.searchGroupBox.Controls.Add(this.selectButton);
            this.searchGroupBox.Controls.Add(this.nameSearchLabel);
            this.searchGroupBox.Controls.Add(this.idSearchLabel);
            this.searchGroupBox.Controls.Add(this.idSearchButton);
            this.searchGroupBox.Controls.Add(this.deleteButton);
            this.searchGroupBox.Controls.Add(this.selectBox);
            this.searchGroupBox.Controls.Add(this.idSearchBox);
            this.searchGroupBox.Location = new System.Drawing.Point(12, 12);
            this.searchGroupBox.Name = "searchGroupBox";
            this.searchGroupBox.Size = new System.Drawing.Size(379, 373);
            this.searchGroupBox.TabIndex = 14;
            this.searchGroupBox.TabStop = false;
            this.searchGroupBox.Text = "Search for Sales Associate";
            // 
            // addButton
            // 
            this.addButton.Cursor = System.Windows.Forms.Cursors.Default;
            this.addButton.Location = new System.Drawing.Point(100, 334);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(75, 23);
            this.addButton.TabIndex = 11;
            this.addButton.Text = "Add new";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
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
            // nameSearchButton
            // 
            this.nameSearchButton.Location = new System.Drawing.Point(285, 100);
            this.nameSearchButton.Name = "nameSearchButton";
            this.nameSearchButton.Size = new System.Drawing.Size(75, 23);
            this.nameSearchButton.TabIndex = 9;
            this.nameSearchButton.Text = "Search";
            this.nameSearchButton.UseVisualStyleBackColor = true;
            this.nameSearchButton.Click += new System.EventHandler(this.nameSearchButton_Click);
            // 
            // nameSearchBox
            // 
            this.nameSearchBox.Location = new System.Drawing.Point(19, 100);
            this.nameSearchBox.Name = "nameSearchBox";
            this.nameSearchBox.Size = new System.Drawing.Size(260, 20);
            this.nameSearchBox.TabIndex = 8;
            // 
            // selectButton
            // 
            this.selectButton.Cursor = System.Windows.Forms.Cursors.Default;
            this.selectButton.Location = new System.Drawing.Point(285, 334);
            this.selectButton.Name = "selectButton";
            this.selectButton.Size = new System.Drawing.Size(75, 23);
            this.selectButton.TabIndex = 5;
            this.selectButton.Text = "Select";
            this.selectButton.UseVisualStyleBackColor = true;
            this.selectButton.Click += new System.EventHandler(this.selectButton_Click);
            // 
            // nameSearchLabel
            // 
            this.nameSearchLabel.AutoSize = true;
            this.nameSearchLabel.Location = new System.Drawing.Point(16, 84);
            this.nameSearchLabel.Name = "nameSearchLabel";
            this.nameSearchLabel.Size = new System.Drawing.Size(35, 13);
            this.nameSearchLabel.TabIndex = 7;
            this.nameSearchLabel.Text = "Name";
            // 
            // idSearchLabel
            // 
            this.idSearchLabel.AutoSize = true;
            this.idSearchLabel.Location = new System.Drawing.Point(16, 24);
            this.idSearchLabel.Name = "idSearchLabel";
            this.idSearchLabel.Size = new System.Drawing.Size(18, 13);
            this.idSearchLabel.TabIndex = 6;
            this.idSearchLabel.Text = "ID";
            // 
            // idSearchButton
            // 
            this.idSearchButton.Cursor = System.Windows.Forms.Cursors.Default;
            this.idSearchButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.idSearchButton.Location = new System.Drawing.Point(285, 38);
            this.idSearchButton.Name = "idSearchButton";
            this.idSearchButton.Size = new System.Drawing.Size(75, 22);
            this.idSearchButton.TabIndex = 0;
            this.idSearchButton.Text = "Search";
            this.idSearchButton.UseVisualStyleBackColor = true;
            this.idSearchButton.Click += new System.EventHandler(this.idSearchButton_Click);
            // 
            // deleteButton
            // 
            this.deleteButton.Cursor = System.Windows.Forms.Cursors.Default;
            this.deleteButton.Location = new System.Drawing.Point(19, 334);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(75, 23);
            this.deleteButton.TabIndex = 20;
            this.deleteButton.Text = "Delete";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // selectBox
            // 
            this.selectBox.BackColor = System.Drawing.SystemColors.Window;
            this.selectBox.FormattingEnabled = true;
            this.selectBox.Location = new System.Drawing.Point(19, 155);
            this.selectBox.Name = "selectBox";
            this.selectBox.Size = new System.Drawing.Size(341, 173);
            this.selectBox.TabIndex = 3;
            // 
            // idSearchBox
            // 
            this.idSearchBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.idSearchBox.Location = new System.Drawing.Point(19, 40);
            this.idSearchBox.Name = "idSearchBox";
            this.idSearchBox.Size = new System.Drawing.Size(260, 20);
            this.idSearchBox.TabIndex = 2;
            // 
            // editGroupBox
            // 
            this.editGroupBox.Controls.Add(this.commissionLabel);
            this.editGroupBox.Controls.Add(this.commissionBox);
            this.editGroupBox.Controls.Add(this.passwordBox);
            this.editGroupBox.Controls.Add(this.passwordLabel);
            this.editGroupBox.Controls.Add(this.idLabel);
            this.editGroupBox.Controls.Add(this.idBox);
            this.editGroupBox.Controls.Add(this.addressLabel);
            this.editGroupBox.Controls.Add(this.addressBox);
            this.editGroupBox.Controls.Add(this.submitButton);
            this.editGroupBox.Controls.Add(this.nameLabel);
            this.editGroupBox.Controls.Add(this.nameBox);
            this.editGroupBox.Location = new System.Drawing.Point(399, 12);
            this.editGroupBox.Name = "editGroupBox";
            this.editGroupBox.Size = new System.Drawing.Size(361, 373);
            this.editGroupBox.TabIndex = 15;
            this.editGroupBox.TabStop = false;
            this.editGroupBox.Text = "Edit Sales Associate";
            this.editGroupBox.Visible = false;
            // 
            // commissionLabel
            // 
            this.commissionLabel.AutoSize = true;
            this.commissionLabel.Location = new System.Drawing.Point(30, 264);
            this.commissionLabel.Name = "commissionLabel";
            this.commissionLabel.Size = new System.Drawing.Size(89, 13);
            this.commissionLabel.TabIndex = 45;
            this.commissionLabel.Text = "Total Commission";
            // 
            // commissionBox
            // 
            this.commissionBox.Location = new System.Drawing.Point(30, 280);
            this.commissionBox.Name = "commissionBox";
            this.commissionBox.Size = new System.Drawing.Size(301, 20);
            this.commissionBox.TabIndex = 44;
            // 
            // passwordBox
            // 
            this.passwordBox.Location = new System.Drawing.Point(30, 220);
            this.passwordBox.Name = "passwordBox";
            this.passwordBox.Size = new System.Drawing.Size(301, 20);
            this.passwordBox.TabIndex = 43;
            // 
            // passwordLabel
            // 
            this.passwordLabel.AutoSize = true;
            this.passwordLabel.Location = new System.Drawing.Point(30, 204);
            this.passwordLabel.Name = "passwordLabel";
            this.passwordLabel.Size = new System.Drawing.Size(53, 13);
            this.passwordLabel.TabIndex = 42;
            this.passwordLabel.Text = "Password";
            // 
            // idLabel
            // 
            this.idLabel.AutoSize = true;
            this.idLabel.Location = new System.Drawing.Point(30, 144);
            this.idLabel.Name = "idLabel";
            this.idLabel.Size = new System.Drawing.Size(43, 13);
            this.idLabel.TabIndex = 39;
            this.idLabel.Text = "User ID";
            // 
            // idBox
            // 
            this.idBox.Location = new System.Drawing.Point(30, 160);
            this.idBox.Name = "idBox";
            this.idBox.Size = new System.Drawing.Size(301, 20);
            this.idBox.TabIndex = 38;
            // 
            // addressLabel
            // 
            this.addressLabel.AutoSize = true;
            this.addressLabel.Location = new System.Drawing.Point(30, 84);
            this.addressLabel.Name = "addressLabel";
            this.addressLabel.Size = new System.Drawing.Size(45, 13);
            this.addressLabel.TabIndex = 28;
            this.addressLabel.Text = "Address";
            // 
            // addressBox
            // 
            this.addressBox.Location = new System.Drawing.Point(30, 100);
            this.addressBox.Name = "addressBox";
            this.addressBox.Size = new System.Drawing.Size(301, 20);
            this.addressBox.TabIndex = 27;
            // 
            // submitButton
            // 
            this.submitButton.Cursor = System.Windows.Forms.Cursors.Default;
            this.submitButton.Location = new System.Drawing.Point(256, 334);
            this.submitButton.Name = "submitButton";
            this.submitButton.Size = new System.Drawing.Size(75, 23);
            this.submitButton.TabIndex = 19;
            this.submitButton.Text = "Submit";
            this.submitButton.UseVisualStyleBackColor = true;
            this.submitButton.Click += new System.EventHandler(this.submitButton_Click);
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Location = new System.Drawing.Point(30, 24);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(35, 13);
            this.nameLabel.TabIndex = 6;
            this.nameLabel.Text = "Name";
            // 
            // nameBox
            // 
            this.nameBox.BackColor = System.Drawing.SystemColors.Window;
            this.nameBox.HideSelection = false;
            this.nameBox.Location = new System.Drawing.Point(30, 40);
            this.nameBox.Name = "nameBox";
            this.nameBox.Size = new System.Drawing.Size(300, 20);
            this.nameBox.TabIndex = 7;
            // 
            // AdminInterface
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(773, 400);
            this.Controls.Add(this.editGroupBox);
            this.Controls.Add(this.searchGroupBox);
            this.Name = "AdminInterface";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AdminInterface";
            this.searchGroupBox.ResumeLayout(false);
            this.searchGroupBox.PerformLayout();
            this.editGroupBox.ResumeLayout(false);
            this.editGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox searchGroupBox;
        private System.Windows.Forms.Label orLabel;
        private System.Windows.Forms.Button nameSearchButton;
        private System.Windows.Forms.TextBox nameSearchBox;
        private System.Windows.Forms.Button selectButton;
        private System.Windows.Forms.Label nameSearchLabel;
        private System.Windows.Forms.Label idSearchLabel;
        private System.Windows.Forms.Button idSearchButton;
        private System.Windows.Forms.ListBox selectBox;
        private System.Windows.Forms.TextBox idSearchBox;
        private System.Windows.Forms.GroupBox editGroupBox;
        private System.Windows.Forms.TextBox passwordBox;
        private System.Windows.Forms.Label passwordLabel;
        private System.Windows.Forms.Label idLabel;
        private System.Windows.Forms.TextBox idBox;
        private System.Windows.Forms.Label addressLabel;
        private System.Windows.Forms.TextBox addressBox;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.Button submitButton;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.TextBox nameBox;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Label commissionLabel;
        private System.Windows.Forms.TextBox commissionBox;
    }
}