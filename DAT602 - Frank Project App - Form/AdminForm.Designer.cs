
namespace DAT602___Frank_Project_App___Form
{
    partial class AdminForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.PromoteDemoteAccount = new System.Windows.Forms.Button();
            this.DeleteAccount = new System.Windows.Forms.Button();
            this.ExitBtn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.AccountListData = new System.Windows.Forms.DataGridView();
            this.Username = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Online = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Admin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.State = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AccountLockedToggle = new System.Windows.Forms.Button();
            this.AccountDetails = new System.Windows.Forms.TextBox();
            this.AddAccountButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.AccountListData)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Account List";
            // 
            // PromoteDemoteAccount
            // 
            this.PromoteDemoteAccount.AccessibleDescription = "";
            this.PromoteDemoteAccount.Location = new System.Drawing.Point(394, 253);
            this.PromoteDemoteAccount.Name = "PromoteDemoteAccount";
            this.PromoteDemoteAccount.Size = new System.Drawing.Size(140, 28);
            this.PromoteDemoteAccount.TabIndex = 2;
            this.PromoteDemoteAccount.Text = "Promote/Demote Account";
            this.PromoteDemoteAccount.UseVisualStyleBackColor = true;
            this.PromoteDemoteAccount.Click += new System.EventHandler(this.PromoteDemoteAccountBtn_Click);
            // 
            // DeleteAccount
            // 
            this.DeleteAccount.Location = new System.Drawing.Point(540, 203);
            this.DeleteAccount.Name = "DeleteAccount";
            this.DeleteAccount.Size = new System.Drawing.Size(100, 28);
            this.DeleteAccount.TabIndex = 3;
            this.DeleteAccount.Text = "Delete Account";
            this.DeleteAccount.UseVisualStyleBackColor = true;
            this.DeleteAccount.Click += new System.EventHandler(this.AccountDeleteBtn_Click);
            // 
            // ExitBtn
            // 
            this.ExitBtn.Location = new System.Drawing.Point(540, 555);
            this.ExitBtn.Name = "ExitBtn";
            this.ExitBtn.Size = new System.Drawing.Size(100, 28);
            this.ExitBtn.TabIndex = 4;
            this.ExitBtn.Text = "Exit";
            this.ExitBtn.UseVisualStyleBackColor = true;
            this.ExitBtn.Click += new System.EventHandler(this.ExitBtn_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(395, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Account Details";
            // 
            // AccountListData
            // 
            this.AccountListData.AllowUserToAddRows = false;
            this.AccountListData.AllowUserToDeleteRows = false;
            this.AccountListData.AllowUserToResizeColumns = false;
            this.AccountListData.AllowUserToResizeRows = false;
            this.AccountListData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.AccountListData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Username,
            this.Online,
            this.Admin,
            this.State});
            this.AccountListData.Location = new System.Drawing.Point(16, 33);
            this.AccountListData.MultiSelect = false;
            this.AccountListData.Name = "AccountListData";
            this.AccountListData.ReadOnly = true;
            this.AccountListData.RowHeadersVisible = false;
            this.AccountListData.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.AccountListData.Size = new System.Drawing.Size(372, 550);
            this.AccountListData.TabIndex = 7;
            this.AccountListData.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.AccountListData_CellClick);
            // 
            // Username
            // 
            this.Username.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Username.DataPropertyName = "Username";
            this.Username.HeaderText = "Username";
            this.Username.Name = "Username";
            this.Username.ReadOnly = true;
            // 
            // Online
            // 
            this.Online.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.Online.DataPropertyName = "Online";
            this.Online.HeaderText = "Online";
            this.Online.Name = "Online";
            this.Online.ReadOnly = true;
            this.Online.Width = 62;
            // 
            // Admin
            // 
            this.Admin.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.Admin.DataPropertyName = "Admin";
            this.Admin.HeaderText = "Admin";
            this.Admin.Name = "Admin";
            this.Admin.ReadOnly = true;
            this.Admin.Width = 61;
            // 
            // State
            // 
            this.State.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.State.DataPropertyName = "LoginAttempts";
            this.State.HeaderText = "Login Fails";
            this.State.Name = "State";
            this.State.ReadOnly = true;
            this.State.Width = 82;
            // 
            // AccountLockedToggle
            // 
            this.AccountLockedToggle.Location = new System.Drawing.Point(394, 203);
            this.AccountLockedToggle.Name = "AccountLockedToggle";
            this.AccountLockedToggle.Size = new System.Drawing.Size(140, 28);
            this.AccountLockedToggle.TabIndex = 8;
            this.AccountLockedToggle.Text = "Lock/Unlock Account";
            this.AccountLockedToggle.UseVisualStyleBackColor = true;
            this.AccountLockedToggle.Click += new System.EventHandler(this.AccountLockedToggle_Click);
            // 
            // AccountDetails
            // 
            this.AccountDetails.Enabled = false;
            this.AccountDetails.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AccountDetails.Location = new System.Drawing.Point(394, 33);
            this.AccountDetails.Multiline = true;
            this.AccountDetails.Name = "AccountDetails";
            this.AccountDetails.Size = new System.Drawing.Size(246, 155);
            this.AccountDetails.TabIndex = 9;
            // 
            // AddAccountButton
            // 
            this.AddAccountButton.Location = new System.Drawing.Point(394, 342);
            this.AddAccountButton.Name = "AddAccountButton";
            this.AddAccountButton.Size = new System.Drawing.Size(90, 23);
            this.AddAccountButton.TabIndex = 10;
            this.AddAccountButton.Text = "Add Account";
            this.AddAccountButton.UseVisualStyleBackColor = true;
            this.AddAccountButton.Click += new System.EventHandler(this.AddAccountButton_Click);
            // 
            // AdminForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(661, 600);
            this.Controls.Add(this.AddAccountButton);
            this.Controls.Add(this.AccountDetails);
            this.Controls.Add(this.AccountLockedToggle);
            this.Controls.Add(this.AccountListData);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ExitBtn);
            this.Controls.Add(this.DeleteAccount);
            this.Controls.Add(this.PromoteDemoteAccount);
            this.Controls.Add(this.label1);
            this.Name = "AdminForm";
            this.Text = "Admin Tools";
            this.Load += new System.EventHandler(this.AdminForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.AccountListData)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button PromoteDemoteAccount;
        private System.Windows.Forms.Button DeleteAccount;
        private System.Windows.Forms.Button ExitBtn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView AccountListData;
        private System.Windows.Forms.Button AccountLockedToggle;
        private System.Windows.Forms.TextBox AccountDetails;
        private System.Windows.Forms.DataGridViewTextBoxColumn Username;
        private System.Windows.Forms.DataGridViewTextBoxColumn Online;
        private System.Windows.Forms.DataGridViewTextBoxColumn Admin;
        private System.Windows.Forms.DataGridViewTextBoxColumn State;
        private System.Windows.Forms.Button AddAccountButton;
    }
}