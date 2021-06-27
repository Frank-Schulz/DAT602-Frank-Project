using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace DAT602___Frank_Project_App___Form
{
    class DataAccess
    {
        private static string connectionString
        {
            get { return "Server=localhost;Port=3306;Database=dat602frankprojectdb;Uid=root;password=ShadowSQL73;"; }
        }

        private static MySqlConnection _mySqlConnection = null;
        public static MySqlConnection MySqlConnection
        {
            get
            {
                if (_mySqlConnection == null)
                {
                    _mySqlConnection = new MySqlConnection(connectionString);
                }

                return _mySqlConnection;

            }
        }

        // login method
        public static string Login(string pUsername, string pPassword)
        {
            List<MySqlParameter> p = new List<MySqlParameter>();
            // Username
            var aP = new MySqlParameter("@Username", MySqlDbType.VarChar, 50);
            aP.Value = pUsername;
            p.Add(aP);
            // Password
            aP = new MySqlParameter("@Password", MySqlDbType.VarChar, 50);
            aP.Value = pPassword;
            p.Add(aP);


            var aDataSet = MySqlHelper.ExecuteDataset(DataAccess.MySqlConnection, "call login(@UserName, @Password)", p.ToArray());

            // expecting one table with one row
            return (aDataSet.Tables[0].Rows[0])["MESSAGE"].ToString();
        }

        // logout method
        public static string Logout(string pUsername)
        {
            List<MySqlParameter> p = new List<MySqlParameter>();
            // Username
            var aP = new MySqlParameter("@Username", MySqlDbType.VarChar, 50);
            aP.Value = pUsername;
            p.Add(aP);

            var aDataSet = MySqlHelper.ExecuteDataset(DataAccess.MySqlConnection, "call logout(@UserName)", p.ToArray());

            // expecting one table with one row
            return (aDataSet.Tables[0].Rows[0])["MESSAGE"].ToString();
        }

        // addAdmin method
        public static void PromoteDemoteAccount(string pUsername)
        {
            List<MySqlParameter> p = new List<MySqlParameter>();
            MySqlParameter aP;
            // New Username
            aP = new MySqlParameter("@Username", MySqlDbType.VarChar, 50);
            aP.Value = pUsername;
            p.Add(aP);

            MySqlHelper.ExecuteDataset(DataAccess.MySqlConnection, "call promoteDemoteAccount(@UserName)", p.ToArray());
        }

        // addPlayer method
        public static string AddAccount(string pUsername, string pPassword, string pEmail)
        {
            List<MySqlParameter> p = new List<MySqlParameter>();
            // Username
            var aP = new MySqlParameter("@Username", MySqlDbType.VarChar, 50);
            aP.Value = pUsername;
            p.Add(aP);
            // Password
            aP = new MySqlParameter("@Password", MySqlDbType.VarChar, 50);
            aP.Value = pPassword;
            p.Add(aP);
            // Email
            aP = new MySqlParameter("@Email", MySqlDbType.VarChar, 50);
            aP.Value = pEmail;
            p.Add(aP);


            var aDataSet = MySqlHelper.ExecuteDataset(DataAccess.MySqlConnection, "call addAccount(@UserName, @Password, @Email)", p.ToArray());

            // expecting one table with one row
            return (aDataSet.Tables[0].Rows[0])["MESSAGE"].ToString();
        }

        public static void AccountLockedToggle(string pUsername)
        {
            List<MySqlParameter> p = new List<MySqlParameter>();
            // Username
            var aP = new MySqlParameter("@Username", MySqlDbType.VarChar, 50);
            aP.Value = pUsername;
            p.Add(aP);

            MySqlHelper.ExecuteDataset(DataAccess.MySqlConnection, "call accountLockedToggle(@Username)", p.ToArray());
            
        }

        // get all users method
        public static Tuple<Dictionary<string, Account>, DataTable> GetAllUsers()
        {
            var aDataSet = MySqlHelper.ExecuteDataset(DataAccess.MySqlConnection, "call getAllUsers()");

            List<Account> accountList = (
                from aResult in aDataSet.Tables[0].AsEnumerable()
                select new Account
                {
                    Username = aResult.Field<string>("Username"),
                    Password = aResult.Field<string>("Password"),
                    Email = aResult.Field<string>("Email"),
                    Admin = aResult.Field<bool>("Admin"),
                    LoginAttempts = aResult.Field<int>("LoginAttempts"),
                    Online = aResult.Field<bool>("Online"),
                    Highscore = aResult.Field<int>("Highscore")
                }
            ).ToList();

            //Dictionary<string, Account> accounts = new Dictionary<string, Account>();
            var users = accountList.ToDictionary(x => x.Username, x => x);


            DataTable accountTable = aDataSet.Tables[0];

            var result = Tuple.Create<Dictionary<string, Account>, DataTable>(users, accountTable);
            return result;
        }

        // delete account method
        public static string DeleteAccount(string pUsername)
        {

            List<MySqlParameter> p = new List<MySqlParameter>();
            // Username
            var aP = new MySqlParameter("@Username", MySqlDbType.VarChar, 50);
            aP.Value = pUsername;
            p.Add(aP);

            var aDataSet = MySqlHelper.ExecuteDataset(DataAccess.MySqlConnection, "call deleteAccount(@UserName)", p.ToArray());

            // expecting one table with one row
            return (aDataSet.Tables[0].Rows[0])["MESSAGE"].ToString();
        }

        // generate food method
        public static string GenFood()
        {

            var aDataSet = MySqlHelper.ExecuteDataset(DataAccess.MySqlConnection, "call genFood()");

            // expecting one table with one row
            return (aDataSet.Tables[0].Rows[0])["MESSAGE"].ToString();
        }

        // join game method
        public static string JoinGame(string player)
        {

            List<MySqlParameter> p = new List<MySqlParameter>();
            // Username
            var aP = new MySqlParameter("@player", MySqlDbType.VarChar, 50);
            aP.Value = player;
            p.Add(aP);

            var aDataSet = MySqlHelper.ExecuteDataset(DataAccess.MySqlConnection, "call joinGame(@player)", p.ToArray());

            // expecting one table with one row
            return (aDataSet.Tables[0].Rows[0])["MESSAGE"].ToString();
        }

        // leave game method
        public static string LeaveGame(string player)
        {

            List<MySqlParameter> p = new List<MySqlParameter>();
            // Username
            var aP = new MySqlParameter("@player", MySqlDbType.VarChar, 50);
            aP.Value = player;
            p.Add(aP);

            var aDataSet = MySqlHelper.ExecuteDataset(DataAccess.MySqlConnection, "call leaveGame(@player)", p.ToArray());

            // expecting one table with one row
            return (aDataSet.Tables[0].Rows[0])["MESSAGE"].ToString();
        }

        // turn snake method
        public static string TurnSnake(string player, string X, string Y)
        {

            List<MySqlParameter> p = new List<MySqlParameter>();
            // Username
            var aP = new MySqlParameter("@player", MySqlDbType.VarChar, 50);
            aP.Value = player;
            p.Add(aP);
            // X
            aP = new MySqlParameter("@X", MySqlDbType.VarChar, 10);
            aP.Value = X;
            p.Add(aP);
            // Y
            aP = new MySqlParameter("@Y", MySqlDbType.VarChar, 10);
            aP.Value = Y;
            p.Add(aP);

            var aDataSet = MySqlHelper.ExecuteDataset(DataAccess.MySqlConnection, "call turnSnake(@player, @X, @Y)", p.ToArray());

            // expecting one table with one row
            return (aDataSet.Tables[0].Rows[0])["MESSAGE"].ToString();
        }

        // update grid method
        public static string UpdateGrid()
        {
            var aDataSet = MySqlHelper.ExecuteDataset(DataAccess.MySqlConnection, "call updateGrid()");

            // expecting one table with one row
            return (aDataSet.Tables[0].Rows[0])["MESSAGE"].ToString();
        }
    
        // Get Game Grid info
        public static DataTable GetGameGrid()
        {
            UpdateGrid();

            var aDataSet = MySqlHelper.ExecuteDataset(DataAccess.MySqlConnection, "call getGameGrid()");

            Console.WriteLine(aDataSet.ToString());
            return aDataSet.Tables[0];
        }
    }
}