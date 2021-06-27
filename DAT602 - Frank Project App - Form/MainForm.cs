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
    public partial class MainForm : Form
    {
        readonly LoginForm _login = new LoginForm();
        readonly RegisterForm _register = new RegisterForm();
        readonly AdminForm _adminForm = new AdminForm();

        public static Account user = new Account();

        public MainForm()
        {
            InitializeComponent();
            CenterToScreen();
        }

        private void UpdateDisplay()
        {
            LoginButton.Visible = !user.Online;
            LogoutButton.Visible = user.Online;
            if (user.Online)
            {
                UsernameLabel.Text = $"Hello {user.Username}";
            }
            else
            {
                UsernameLabel.Text = "";
            }
        }

        public static void SetUser(string username)
        {
            if (username == "null")
            {
                user = new Account();
                return;
            }
            user = DataAccess.GetAllUsers().Item1[username];
        }

        private void StartGameBtn_Click(object sender, EventArgs e)
        {
            GameGrid grid = new GameGrid();
            if (!user.Online && Login() == true)
            {
                grid.ShowDialog();
            }
            else if (user.Online)
            {
                grid.ShowDialog();
            }
        }

        private void AdminToolsBtn_Click(object sender, EventArgs e)
        {
            if (Login("admin") == false) { return; }

            _adminForm.UpdateDisplay();
            _adminForm.ShowDialog();
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            var result = Login();
            if (result) UpdateDisplay();
        }

        private void LogoutButton_Click(object sender, EventArgs e)
        {
            DataAccess.Logout(user.Username);
            SetUser("null");
            UpdateDisplay();
        }

        private bool Login()
        {
            _login.ShowDialog();

            if (_login.DialogResult == DialogResult.No)
            {
                return Register();
            }
            else if (_login.DialogResult == DialogResult.Cancel)
            {
                return false;
            }
            return true;
        }
        private bool Login(string admin)
        {
            _login.AdminLogin();
            _login.ShowDialog();

            if (_login.DialogResult == DialogResult.Cancel)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private bool Register()
        {
            _register.ShowDialog();
            if (_register.DialogResult == DialogResult.No)
            {
                return Login();
            }
            else if (_register.DialogResult == DialogResult.Cancel)
            {
                return false;
            }
            return true;
        }

        private void ExitBtn_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
