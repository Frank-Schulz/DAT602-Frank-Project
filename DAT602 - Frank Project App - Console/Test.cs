using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace DAT602___Frank_Project_App___Console
{
    class Test
    {
        private static string connectionString
        {
            get { return "Server=localhost;Port=3306;Database=dat602_frank_project;Uid=root;password=ShadowSQL73;"; }

        }

        private static MySqlConnection _mySqlConnection = null;
        public static MySqlConnection mySqlConnection
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
        public string login(string pUsername, string pPassword)
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


            var aDataSet = MySqlHelper.ExecuteDataset(Test.mySqlConnection, "call login(@UserName, @Password)", p.ToArray());

            // expecting one table with one row
            return (aDataSet.Tables[0].Rows[0])["MESSAGE"].ToString();
        }

        // addAdmin method
        public string addAdmin(string pUsername, string pPassword, string pNewUsername, string pNewPassword, string pNewEmail)
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
            // New Username
            aP = new MySqlParameter("@NewUsername", MySqlDbType.VarChar, 50);
            aP.Value = pNewUsername;
            p.Add(aP);
            // New Password
            aP = new MySqlParameter("@NewPassword", MySqlDbType.VarChar, 50);
            aP.Value = pNewPassword;
            p.Add(aP);
            // New Email
            aP = new MySqlParameter("@NewEmail", MySqlDbType.VarChar, 50);
            aP.Value = pNewEmail;
            p.Add(aP);

            var aDataSet = MySqlHelper.ExecuteDataset(Test.mySqlConnection, "call addAdmin(@UserName, @Password, @NewUserName, @NewPassword, @NewEmail)", p.ToArray());

            // expecting one table with one row
            return (aDataSet.Tables[0].Rows[0])["MESSAGE"].ToString();
        }

        // addPlayer method
        public string addPlayer(string pUsername, string pPassword, string pEmail)
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


            var aDataSet = MySqlHelper.ExecuteDataset(Test.mySqlConnection, "call addPlayer(@UserName, @Password, @Email)", p.ToArray());

            // expecting one table with one row
            return (aDataSet.Tables[0].Rows[0])["MESSAGE"].ToString();
        }

        // get all users method
        public List<User> getAllUsers()
        {
            List<User> lcPlayers = new List<User>();

            var aDataSet = MySqlHelper.ExecuteDataset(Test.mySqlConnection, "call getAllUsers()");
            lcPlayers = (from aResult in aDataSet.Tables[0].AsEnumerable()
                         select
                            new User
                            {
                                Username = aResult.Field<string>("Username"),
                                Password = aResult.Field<string>("Password"),
                                Email = aResult.Field<string>("Email")
                            }).ToList();
            return lcPlayers;
        }

        // delete account method
        public string deleteAccount(string pUsername)
        {

            List<MySqlParameter> p = new List<MySqlParameter>();
            // Username
            var aP = new MySqlParameter("@Username", MySqlDbType.VarChar, 50);
            aP.Value = pUsername;
            p.Add(aP);

            var aDataSet = MySqlHelper.ExecuteDataset(Test.mySqlConnection, "call deleteAccount(@UserName)", p.ToArray());

            // expecting one table with one row
            return (aDataSet.Tables[0].Rows[0])["MESSAGE"].ToString();
        }

        // generate food method
        public string genFood()
        {

            var aDataSet = MySqlHelper.ExecuteDataset(Test.mySqlConnection, "call genFood()");

            // expecting one table with one row
            return (aDataSet.Tables[0].Rows[0])["MESSAGE"].ToString();
        }

        // join game method
        public string joinGame(string player)
        {

            List<MySqlParameter> p = new List<MySqlParameter>();
            // Username
            var aP = new MySqlParameter("@player", MySqlDbType.VarChar, 50);
            aP.Value = player;
            p.Add(aP);

            var aDataSet = MySqlHelper.ExecuteDataset(Test.mySqlConnection, "call joinGame(@player)", p.ToArray());

            // expecting one table with one row
            return (aDataSet.Tables[0].Rows[0])["MESSAGE"].ToString();
        }

        // leave game method
        public string leaveGame(string player)
        {

            List<MySqlParameter> p = new List<MySqlParameter>();
            // Username
            var aP = new MySqlParameter("@player", MySqlDbType.VarChar, 50);
            aP.Value = player;
            p.Add(aP);

            var aDataSet = MySqlHelper.ExecuteDataset(Test.mySqlConnection, "call leaveGame(@player)", p.ToArray());

            // expecting one table with one row
            return (aDataSet.Tables[0].Rows[0])["MESSAGE"].ToString();
        }

        // turn snake method
        public string turnSnake(string player, string X, string Y)
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

            var aDataSet = MySqlHelper.ExecuteDataset(Test.mySqlConnection, "call turnSnake(@player, @X, @Y)", p.ToArray());

            // expecting one table with one row
            return (aDataSet.Tables[0].Rows[0])["MESSAGE"].ToString();
        }

        // update grid method
        public string updateGrid()
        {

            var aDataSet = MySqlHelper.ExecuteDataset(Test.mySqlConnection, "call updateGrid()");

            // expecting one table with one row
            return (aDataSet.Tables[0].Rows[0])["MESSAGE"].ToString();
        }
    }
}