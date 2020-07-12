using System;
using static System.Console;

namespace GMJournalConsole
{
    class LoginMenu
    {
        public void Start()
        {
            Clear();
            WriteLine("=================");
            WriteLine("GMJournal - Login");
            WriteLine("=================\n");
            Write("Brugernavn: ");
            string currentuser = ReadLine();
            WriteLine();
            Write("Adgangskode: ");
            string pass = "";
            //write '*' instead of numbers to protect the password from prying eyes
            do
            {
                ConsoleKeyInfo key = ReadKey(true);
                //backspace and enter should not work the same as other keys because of their function
                if (key.Key != ConsoleKey.Backspace && key.Key != ConsoleKey.Enter)
                {
                    pass += key.KeyChar;
                    Write("*");
                }
                else
                {
                    if (key.Key == ConsoleKey.Backspace && pass.Length > 0)
                    {
                        pass = pass.Substring(0, (pass.Length - 1));
                        /*
                         The first \b goes back, then the space "overwrites" the asterisk,
                         and because the space moved the cursor forward, there's the second \b
                        */
                        Write("\b \b");
                    }
                    else if (key.Key == ConsoleKey.Enter)
                    {
                        break;
                    }
                }
            }
            while (true);

            WriteLine();

            UserMenu userMenu = new UserMenu();
            CitizenMenu citizenMenu = new CitizenMenu();

            //This works for getting the password and username from the database
            var variables = DBConnect.GetUsernamePassword(currentuser);
            var password = variables.Item1;
            var position = variables.Item2;

            if (pass == password)
            {
                Write("\nDu er nu logget på. Vent venligst");
                for (int i = 0; i < 3; i++)
                {
                    Write(".");
                    System.Threading.Thread.Sleep(1000);
                }
                if (position == "System Administrator")
                {
                    userMenu.Start();
                }
                else
                {
                    citizenMenu.Start();
                }
            }
            else
            {
                WriteLine("Der var et problem med dit brugernavn eller adgangskode.\nTryk på en tast for at prøve igen.");
                ReadKey();
                Start();
            }

        }
    }
}
