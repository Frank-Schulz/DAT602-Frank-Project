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
    public partial class LoginForm : Form
    {
        private bool adminLogin;

        public LoginForm()
        {
            InitializeComponent();
            CenterToScreen();
        }

        public void AdminLogin()
        {
            adminLogin = true;
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            if (adminLogin == false)
            {
                LoginMessage.ForeColor = Color.WhiteSmoke;
                GoToRegisterLabel.Visible = true;
                LoginHeaderLabel.Text = "Login";
            }
            else
            {
                GoToRegisterLabel.Visible = false;
                LoginHeaderLabel.Text = "Admin Login";

                adminLogin = false;
            }
        }

        private void GoToRegisterLabel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.No;
        }
        
        private void LoginBtn_Click(object sender, EventArgs e)
        {
            string _username = UsernameInput.Text;
            string _password = PasswordInput.Text;

            string result = DataAccess.Login(_username, _password);

            if (result == ("Login successful"))
            {
                LoginMessage.ForeColor = Color.WhiteSmoke;
                MainForm.SetUser(_username);
            }
            else if (result == "WARNING: Account locked")
            {
                var users = DataAccess.GetAllUsers().Item1;
                var adminEmail = (
                    from user in users
                    where user.Value.Admin = true
                    select user.Value.Email).ToList()[0];

                LoginMessage.ForeColor = Color.Red;
                LoginMessage.Text = $"{result}" +
                    $"{Environment.NewLine}" +
                    $"Contact: {adminEmail}";

                PasswordInput.Text = "";
                return;
            }
            else
            {
                LoginMessage.ForeColor = Color.Red;
                LoginMessage.Text = $"{result}";

                PasswordInput.Text = "";
                return;
            }

            if (!IsAdmin(_username))
            {
                LoginMessage.ForeColor = Color.Red;
                LoginMessage.Text = "This account is NOT an admin!";
                return;
            }

            DialogResult = DialogResult.OK;
            UsernameInput.Text = "";
            PasswordInput.Text = "";
        }

        public bool IsAdmin(string username)
        {
            return DataAccess.GetAllUsers().Item1[username].Admin;
        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            LoginMessage.ForeColor = Color.WhiteSmoke;

            UsernameInput.Text = "";
            PasswordInput.Text = "";
        }
    }
}
