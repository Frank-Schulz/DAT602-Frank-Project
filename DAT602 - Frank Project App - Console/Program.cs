using System;

namespace DAT602___Frank_Project_App___Console
{
    class Program
    {
        static void Main(string[] args)
        {
            /* Included procedures
            login
            addplayer
                player
                admin
            getAllUsers
            deleteAccount
            generateFood
            turnSnake
            updateGrid
	            moveSnake
		            collision
		            onFood

            */

            Test _test = new Test();

            // Testing login
            static void Login(string username, string password, Test _test)
            {
                Console.WriteLine("\nTesting login");
                Console.WriteLine("===============================================");
                Console.WriteLine($"{username} {password}");

                if (_test.login(username, password) == ("Login succesful"))
                {
                    Console.WriteLine($"User {username} logged in successfully");
                }
                else
                {
                    Console.WriteLine("Incorrect login details");
                }
                Console.WriteLine("----------------------------------------------");
            }

            // Testing addPlayer
            static void addPlayer(string username, string password, string email, Test _test)
            {
                Console.WriteLine("\nTesting addPlayer");
                Console.WriteLine("===============================================");
                if (_test.addPlayer(username, password, email) == ("User created: " + username))
                {
                    Console.WriteLine($"Player {username} created successfully");
                }
                else
                {
                    Console.WriteLine("Username already exists");
                    Console.WriteLine("----------------------------------------------");
                }
            }

            // Testing addAdmin
            static void addAdmin(string username, string password, string newUsername, string newPassword, string newEmail, Test _test)
            {
                Console.WriteLine("\nTesting addAdmin");
                Console.WriteLine("===============================================");
                if (_test.addAdmin(username, password, newUsername, newPassword, newEmail) == ("User created: " + username))
                {
                    Console.WriteLine($"Admin {newUsername} created successfully");
                }
                else
                {
                    Console.WriteLine("Admin already exists");
                    Console.WriteLine("----------------------------------------------");
                }
            }

            // Correct details
            Login("admin", "P@ssword1", _test);
            // Incorrect details
            Login("admin", "Password1", _test);

            addPlayer("Player1", "P@ssword1", "testerMail@thing.com", _test);
            addPlayer("Player2", "P@ssword1", "testerMail@thing.com", _test);
            addAdmin("admin", "P@ssword1", "TestPlayer", "P@ssword1", "testerMail@thing.com", _test);

            // Testing Get All Players
            Console.WriteLine("\nTesting Get All Users");
            Console.WriteLine("===============================================");

            int gap = 20;

            Console.WriteLine("Username" + (new String(' ', gap - 8)) + "Password" + (new String(' ', gap - 8)) + "Email");
            Console.WriteLine();
            foreach (var p in _test.getAllUsers())
            {
                Console.WriteLine(p.Username + (new String(' ', gap - p.Username.Length)) + p.Password + (new String(' ', gap - p.Password.Length)) + p.Email);
            }
            Console.WriteLine("----------------------------------------------");

            // Testing Delete Account
            Console.WriteLine("\nTesting Delete Account");
            Console.WriteLine("===============================================");

            Console.WriteLine(_test.deleteAccount("TestPlayer"));

            Console.WriteLine("----------------------------------------------");

            // Testing Generate Food
            Console.WriteLine("\nTesting Generate Food");
            Console.WriteLine("===============================================");

            Console.WriteLine(_test.genFood());

            Console.WriteLine("----------------------------------------------");

            // Testing Join Game
            Console.WriteLine("\nTesting Join Game");
            Console.WriteLine("===============================================");

            Console.WriteLine(_test.joinGame("player1"));

            Console.WriteLine("----------------------------------------------");

            // Testing Leave Game
            Console.WriteLine("\nTesting Leave Game");
            Console.WriteLine("===============================================");

            Console.WriteLine(_test.leaveGame("player1"));

            Console.WriteLine("----------------------------------------------");

            // Testing Turn Snake
            Console.WriteLine("\nTesting Turn Snake");
            Console.WriteLine("===============================================");

            Console.WriteLine(_test.turnSnake("player1", "1", "0"));

            Console.WriteLine("----------------------------------------------");

            // Testing Update Grid
            Console.WriteLine("\nTesting Update Grid");
            Console.WriteLine("===============================================");

            Console.WriteLine(_test.updateGrid());

            Console.WriteLine("----------------------------------------------");

            Console.ReadLine();
        }
    }
}
