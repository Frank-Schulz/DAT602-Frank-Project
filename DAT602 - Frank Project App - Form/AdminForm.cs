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
    public partial class AdminForm : Form
    {
        Account user;

        public AdminForm()
        {
            InitializeComponent();
            UpdateDisplay();
        }

        private void AdminForm_Load(object sender, EventArgs e)
        {
            CenterToScreen();

            var arg = new DataGridViewCellEventArgs(0, 0);
            AccountListData_CellClick(AccountListData, arg);
        }

        public void UpdateDisplay()
        {
            AccountListData.AutoGenerateColumns = false;
            AccountListData.DataSource = null;
            AccountListData.DataSource = DataAccess.GetAllUsers().Item2;
        }

        private void AccountListData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) { return; };

            DataGridViewRow row = AccountListData.Rows[e.RowIndex];
            var username = row.Cells[0].Value.ToString();

            Dictionary<string, Account> users = DataAccess.GetAllUsers().Item1;
            user = users[username];
            AccountDetails.Text =
                $"PASSWORD:     {user.Password}" +
                $"{Environment.NewLine}" +
                $"{Environment.NewLine}" +
                $"EMAIL:               {user.Email}" +
                $"{Environment.NewLine}" +
                $"{Environment.NewLine}" +
                $"HIGHSCORE:     {user.Highscore}";
        }

        private void AccountLockedToggle_Click(object sender, EventArgs e)
        {
            if (user != null)
            {
                DataAccess.AccountLockedToggle(user.Username);
            }
            else
            {
                MessageBox.Show("Please select a row");
            }
            UpdateDisplay();
        }

        private void PromoteDemoteAccountBtn_Click(object sender, EventArgs e)
        {
            DataAccess.PromoteDemoteAccount(user.Username);
            UpdateDisplay();
        }

        private void AccountDeleteBtn_Click(object sender, EventArgs e)
        {
            DataAccess.DeleteAccount(user.Username);
            UpdateDisplay();

            var arg = new DataGridViewCellEventArgs(0, 0);
            AccountListData_CellClick(AccountListData, arg);
        }

        private void AddAccountButton_Click(object sender, EventArgs e)
        {
            RegisterForm newAccount = new RegisterForm();
            newAccount.HideLogin();
            newAccount.ShowDialog();

            UpdateDisplay();
        }

        private void ExitBtn_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
    }
}
