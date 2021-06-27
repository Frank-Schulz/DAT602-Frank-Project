
namespace DAT602___Frank_Project_App___Form
{
    partial class LoginForm
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
            this.UsernameInput = new System.Windows.Forms.TextBox();
            this.PasswordInput = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.GoToRegisterLabel = new System.Windows.Forms.Label();
            this.LoginMessage = new System.Windows.Forms.Label();
            this.LoginHeaderLabel = new System.Windows.Forms.Label();
            this.LoginBtn = new System.Windows.Forms.Button();
            this.CancelBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // UsernameInput
            // 
            this.UsernameInput.Location = new System.Drawing.Point(41, 93);
            this.UsernameInput.MaxLength = 50;
            this.UsernameInput.Name = "UsernameInput";
            this.UsernameInput.Size = new System.Drawing.Size(153, 20);
            this.UsernameInput.TabIndex = 0;
            // 
            // PasswordInput
            // 
            this.PasswordInput.Location = new System.Drawing.Point(41, 141);
            this.PasswordInput.MaxLength = 50;
            this.PasswordInput.Name = "PasswordInput";
            this.PasswordInput.PasswordChar = '*';
            this.PasswordInput.Size = new System.Drawing.Size(153, 20);
            this.PasswordInput.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(38, 77);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Username";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(38, 125);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Password";
            // 
            // GoToRegisterLabel
            // 
            this.GoToRegisterLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.GoToRegisterLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GoToRegisterLabel.ForeColor = System.Drawing.SystemColors.Highlight;
            this.GoToRegisterLabel.Location = new System.Drawing.Point(12, 176);
            this.GoToRegisterLabel.Name = "GoToRegisterLabel";
            this.GoToRegisterLabel.Size = new System.Drawing.Size(206, 13);
            this.GoToRegisterLabel.TabIndex = 5;
            this.GoToRegisterLabel.Text = "Register";
            this.GoToRegisterLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.GoToRegisterLabel.Visible = false;
            this.GoToRegisterLabel.Click += new System.EventHandler(this.GoToRegisterLabel_Click);
            // 
            // LoginMessage
            // 
            this.LoginMessage.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.LoginMessage.Location = new System.Drawing.Point(8, 44);
            this.LoginMessage.Name = "LoginMessage";
            this.LoginMessage.Size = new System.Drawing.Size(219, 33);
            this.LoginMessage.TabIndex = 13;
            this.LoginMessage.Text = "LoginMessage";
            this.LoginMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LoginHeaderLabel
            // 
            this.LoginHeaderLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.LoginHeaderLabel.Location = new System.Drawing.Point(12, 24);
            this.LoginHeaderLabel.Name = "LoginHeaderLabel";
            this.LoginHeaderLabel.Size = new System.Drawing.Size(210, 20);
            this.LoginHeaderLabel.TabIndex = 14;
            this.LoginHeaderLabel.Text = "Login";
            this.LoginHeaderLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LoginBtn
            // 
            this.LoginBtn.Location = new System.Drawing.Point(35, 223);
            this.LoginBtn.Name = "LoginBtn";
            this.LoginBtn.Size = new System.Drawing.Size(75, 23);
            this.LoginBtn.TabIndex = 3;
            this.LoginBtn.Text = "Login";
            this.LoginBtn.UseVisualStyleBackColor = true;
            this.LoginBtn.Click += new System.EventHandler(this.LoginBtn_Click);
            // 
            // CancelBtn
            // 
            this.CancelBtn.Location = new System.Drawing.Point(126, 223);
            this.CancelBtn.Name = "CancelBtn";
            this.CancelBtn.Size = new System.Drawing.Size(75, 23);
            this.CancelBtn.TabIndex = 4;
            this.CancelBtn.Text = "Cancel";
            this.CancelBtn.UseVisualStyleBackColor = true;
            this.CancelBtn.Click += new System.EventHandler(this.CancelBtn_Click);
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(234, 261);
            this.Controls.Add(this.CancelBtn);
            this.Controls.Add(this.LoginBtn);
            this.Controls.Add(this.LoginHeaderLabel);
            this.Controls.Add(this.LoginMessage);
            this.Controls.Add(this.GoToRegisterLabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.PasswordInput);
            this.Controls.Add(this.UsernameInput);
            this.Name = "LoginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LoginForm";
            this.Load += new System.EventHandler(this.LoginForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox UsernameInput;
        private System.Windows.Forms.TextBox PasswordInput;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label GoToRegisterLabel;
        private System.Windows.Forms.Label LoginMessage;
        private System.Windows.Forms.Label LoginHeaderLabel;
        private System.Windows.Forms.Button LoginBtn;
        private System.Windows.Forms.Button CancelBtn;
    }
}