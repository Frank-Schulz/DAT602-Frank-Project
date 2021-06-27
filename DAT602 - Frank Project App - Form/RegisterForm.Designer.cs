
namespace DAT602___Frank_Project_App___Form
{
    partial class RegisterForm
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
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.PasswordInput = new System.Windows.Forms.TextBox();
            this.UsernameInput = new System.Windows.Forms.TextBox();
            this.RegisterMessage = new System.Windows.Forms.Label();
            this.GoToLoginLabel = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.EmailInput = new System.Windows.Forms.TextBox();
            this.CancelBtn = new System.Windows.Forms.Button();
            this.RegisterBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label3.Location = new System.Drawing.Point(12, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(210, 20);
            this.label3.TabIndex = 10;
            this.label3.Text = "Register";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(38, 125);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Password";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(38, 77);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Username";
            // 
            // PasswordInput
            // 
            this.PasswordInput.Location = new System.Drawing.Point(41, 141);
            this.PasswordInput.Name = "PasswordInput";
            this.PasswordInput.Size = new System.Drawing.Size(153, 20);
            this.PasswordInput.TabIndex = 1;
            // 
            // UsernameInput
            // 
            this.UsernameInput.Location = new System.Drawing.Point(41, 93);
            this.UsernameInput.Name = "UsernameInput";
            this.UsernameInput.Size = new System.Drawing.Size(153, 20);
            this.UsernameInput.TabIndex = 0;
            // 
            // RegisterMessage
            // 
            this.RegisterMessage.ForeColor = System.Drawing.SystemColors.Control;
            this.RegisterMessage.Location = new System.Drawing.Point(8, 47);
            this.RegisterMessage.Name = "RegisterMessage";
            this.RegisterMessage.Size = new System.Drawing.Size(219, 22);
            this.RegisterMessage.TabIndex = 12;
            this.RegisterMessage.Text = "RegisterMessage";
            this.RegisterMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // GoToLoginLabel
            // 
            this.GoToLoginLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.GoToLoginLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GoToLoginLabel.ForeColor = System.Drawing.SystemColors.Highlight;
            this.GoToLoginLabel.Location = new System.Drawing.Point(13, 221);
            this.GoToLoginLabel.Name = "GoToLoginLabel";
            this.GoToLoginLabel.Size = new System.Drawing.Size(206, 13);
            this.GoToLoginLabel.TabIndex = 13;
            this.GoToLoginLabel.Text = "Login";
            this.GoToLoginLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.GoToLoginLabel.Click += new System.EventHandler(this.GoToLoginLabel_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(38, 173);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "Email";
            // 
            // EmailInput
            // 
            this.EmailInput.Location = new System.Drawing.Point(41, 189);
            this.EmailInput.Name = "EmailInput";
            this.EmailInput.Size = new System.Drawing.Size(153, 20);
            this.EmailInput.TabIndex = 3;
            // 
            // CancelBtn
            // 
            this.CancelBtn.Location = new System.Drawing.Point(125, 268);
            this.CancelBtn.Name = "CancelBtn";
            this.CancelBtn.Size = new System.Drawing.Size(75, 23);
            this.CancelBtn.TabIndex = 5;
            this.CancelBtn.Text = "Cancel";
            this.CancelBtn.UseVisualStyleBackColor = true;
            this.CancelBtn.Click += new System.EventHandler(this.CancelBtn_Click);
            // 
            // RegisterBtn
            // 
            this.RegisterBtn.Location = new System.Drawing.Point(34, 268);
            this.RegisterBtn.Name = "RegisterBtn";
            this.RegisterBtn.Size = new System.Drawing.Size(75, 23);
            this.RegisterBtn.TabIndex = 4;
            this.RegisterBtn.Text = "Register";
            this.RegisterBtn.UseVisualStyleBackColor = true;
            this.RegisterBtn.Click += new System.EventHandler(this.RegisterBtn_Click);
            // 
            // RegisterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(234, 310);
            this.Controls.Add(this.CancelBtn);
            this.Controls.Add(this.RegisterBtn);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.EmailInput);
            this.Controls.Add(this.GoToLoginLabel);
            this.Controls.Add(this.RegisterMessage);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.PasswordInput);
            this.Controls.Add(this.UsernameInput);
            this.Name = "RegisterForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RegisterForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox PasswordInput;
        private System.Windows.Forms.TextBox UsernameInput;
        private System.Windows.Forms.Label RegisterMessage;
        private System.Windows.Forms.Label GoToLoginLabel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox EmailInput;
        private System.Windows.Forms.Button CancelBtn;
        private System.Windows.Forms.Button RegisterBtn;
    }
}