using System;

namespace RefactoredUserSystem
{
    class Program
    {

        protected const string deleteCommand = "delete";
        protected const string registerCommand = "register";
        protected static string commandToStopProcess = "end";
        protected static string argsErroMessage = "Too few parameters.";
        protected static string errorMessage = "must be at least 3 characters long.";
        protected static string userNameErrorMessage = $"Username {errorMessage}";
        protected static string passwordErrorMessage = $"Password {errorMessage}";
        protected static string usernameExist = "Username already exists.";
        protected static string maxUsersReached = "The system supports a maximum number of 4 users.";
        protected static string invalidAccountOrPassword = "Invalid account/password.";
        protected static string deletedAccountMesssage = "Deleted account.";
        protected static string registerAccountMessage = "Registered user.";
        protected static string redColor = "red";
        protected static string greenColor = "green";
        protected static int invalidLength = 3;
        protected static int userCapacity = 4;
        protected static int argumentsForUserProfil = 2;

        protected static void Main(string[] args)
        {
            RunUserSystem();
        }

        protected static void RunUserSystem()
        {
            string[,] userTable = new string[userCapacity, argumentsForUserProfil];

            string input = String.Empty;

            // main loop
            while ((input = Console.ReadLine()) != commandToStopProcess)
            {
                string[] commandArgs;
                string command;
                TakeArgumentsToRunTheAlgorithm(input, out commandArgs, out command);

                switch (command)
                {
                    case registerCommand:
                        {
                            RegisterUser(userTable, commandArgs);
                            break;
                        }
                    case deleteCommand:
                        {
                            DeleteUser(userTable, commandArgs);
                            break;
                        }
                }
            }
        }

        protected static void TakeArgumentsToRunTheAlgorithm(string input, out string[] commandArgs, out string command)
        {
            commandArgs = input.Split(" ");
            command = commandArgs[0];
        }

        protected static void DeleteUser(string[,] userTable, string[] commandArgs)
        {
            // validate arguments
            if (!Validation(commandArgs.Length, argsErroMessage, redColor))
            {
                return;
            }

            string username = commandArgs[1];
            string password = commandArgs[2];

            // validate username
            if (!Validation(username.Length, userNameErrorMessage, redColor))
            {
                return;
            }

            // validate password
            if (!Validation(password.Length, passwordErrorMessage, redColor))
            {
                return;
            }

            // find account to delete
            int accountIndex = ValidateIndex(userTable, redColor, username, password);
            if (accountIndex == -1)
            {
                return;
            }

            userTable[accountIndex, 0] = null;
            userTable[accountIndex, 1] = null;

            Print(deletedAccountMesssage, greenColor);
            return;
        }

        protected static void RegisterUser(string[,] userTable, string[] commandArgs)
        {
            // validate arguments
            if (!Validation(commandArgs.Length, argsErroMessage, redColor))
            {
                return;
            }

            string username = commandArgs[1];
            string password = commandArgs[2];

            // validate username
            if (!Validation(username.Length, userNameErrorMessage, redColor))
            {
                return;
            }

            // validate password
            if (!Validation(password.Length, passwordErrorMessage, redColor))
            {
                return;
            }

            // check if username exists
            if (UsernameExist(userTable, username, redColor))
            {
                return;
            }

            // find free slot
            int freeSlotIndex = ValidateIndex(userTable, redColor);
            if (freeSlotIndex == -1)
            {
                return;
            }

            // save user
            userTable[freeSlotIndex, 0] = username;
            userTable[freeSlotIndex, 1] = password;
            Print(registerAccountMessage, greenColor);
            return;
        }

        protected static int ValidateIndex(string[,] userTable,string color, string username = "", string password = "")
        {
            int index = -1;
            if (username.Length == 0)
            {
                for (int i = 0; i < userTable.GetLength(0); i++)
                {
                    if (userTable[i, 0] == null)
                    {
                        index = i;
                    }
                }

                // no free slots
                if (index == -1)
                {
                    Print(maxUsersReached, color);
                }
            }
            else
            {
                for (int i = 0; i < userTable.GetLength(0); i++)
                {
                    if (userTable[i, 0] == username &&
                        userTable[i, 1] == password)
                    {
                        index = i;
                    }
                }

                if (index == -1)
                {
                    Print(invalidAccountOrPassword, color);
                }
            }

            return index;
        }
        protected static bool UsernameExist(string[,] userTable, string username,string color)
        {
            bool usernameExists = false;
            for (int i = 0; i < userTable.GetLength(0); i++)
            {
                if (userTable[i, 0] == username)
                {
                    usernameExists = true;
                }
            }

            if (usernameExists)
            {
                Print(usernameExist, color);
            }

            return usernameExists;

        }
        protected static bool Validation(int currentLength, string text,string color)
        {
            if (currentLength < invalidLength)
            {
                Print(text, color);
                return false;
            }

            return true;
        }

        protected static void Print(string text, string color)
        {
            if (color == "red")
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }
            else if (color == "green")
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;

            }

            Console.WriteLine(text);

            Console.ResetColor();
        }
    }
}
