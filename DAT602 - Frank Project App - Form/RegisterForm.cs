using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DAT602___Frank_Project_App___Form
{
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();
            CenterToScreen();
        }

        private void RegisterBtn_Click(object sender, EventArgs e)
        {
            string _username = UsernameInput.Text;
            string _password = PasswordInput.Text;
            string _email = EmailInput.Text;


            if (DataAccess.AddAccount(_username, _password, _email) == ("User created: " + _username))
            {
                MessageBox.Show($"Player '{_username}' created successfully");
                DialogResult = DialogResult.OK;

                UsernameInput.Text = "";
                PasswordInput.Text = "";
                EmailInput.Text = "";
            }
            else
            {
                RegisterMessage.Text = "Username already exists";
            }

        }

        public void HideLogin()
        {
            GoToLoginLabel.Visible = false;
        }

        private void GoToLoginLabel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.No;
        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;

            UsernameInput.Text = "";
            PasswordInput.Text = "";
            EmailInput.Text = "";
        }
    }
}
