using System.Linq;
using static System.Console;
using static System.Convert;

namespace GMJournalConsole
{
    class UserMenu
    {
        public string dbType = "people";
        public string personType = "user";
        public void Start()
        {
            int choice;
            do
            {
                Clear();
                WriteLine("======================");
                WriteLine("GMJournal - Brugermenu");
                WriteLine("======================\n");
                WriteLine("1 - List brugere:");
                WriteLine("2 - Tilføj en ny bruger: ");
                WriteLine("3 - Redigere i en brugers stamdata eller adgangskode: ");
                WriteLine("4 - Slette en bruger: ");
                WriteLine("\n0 - Afslut programmet:");
                Write("\n\nIndast dit valg: ");

                choice = ToInt32(ReadLine());
                //Make sure the user doesn't crash the program by writing something other than what they should
                while (choice != 1 && choice != 2 && choice != 3 && choice != 4 && choice != 0)
                {
                    Write("Det er ikke et gyldigt valg. Prøv igen:");
                    choice = char.ToLower(ToChar(ReadLine()));
                }

                switch (choice)
                {
                    case 1:
                        ListUsers();
                        break;
                    case 2:
                        AddUser();
                        break;
                    case 3:
                        Modify();
                        break;
                    case 4:
                        Delete();
                        break;
                    case 0:
                        WriteLine("Tak for i dag.");
                        break;
                }
            }
            while (choice != 0);
        }
        public void AddUser()
        {
            //get the data
            User user = new User();
            user.SetData();
            //write the data to the database
            DBConnect.Insert(dbType, personType, user);
        }

        public void ListUsers()
        {
            //list is created from the database in DBConnect, then returned here
            var list = DBConnect.ListUsers(dbType, personType);

            Clear();
            WriteLine("===================");
            WriteLine("GMJournal - Brugere");
            WriteLine("===================\n");
            WriteLine("CPR : Navn : Adresse : Stilling : Brugernavn");
            //print each object from the returned list
            foreach (User u in list)
            {
                WriteLine($"{u.CPR} : {u.Name} : {u.Address} : {u.Position} : {u.Username}");
            }
            WriteLine();
            WriteLine($"Der er i alt {list.Count} brugere i databasen.\n");
            Write("Tryk på en tast for at fortsætte: ");
            ReadKey();
        }
        public void Modify()
        {
            int choice;
            string column = "", newValue;

            Clear();
            WriteLine("======================");
            WriteLine("GMJournal - Redigere Bruger");
            WriteLine("======================\n");
            Write("Indtast CPR nummer på den bruger du vil redigere (uden bindestreg): ");
            string cpr = ReadLine();

            //make sure the cpr is 10 digits, and the user exists in the database beforehand
            string dbType = "people";
            int count = DBConnect.Count(dbType, cpr);
            while (cpr.Length != 10 || !cpr.All(char.IsDigit) || count == 0)
            {
                Write("Du har enten ikke indtastet en valid CPR nummer, eller brugeren ikke eksisterer. Prøv igen: ");
                cpr = ReadLine();
                count = DBConnect.Count(dbType, cpr);
            }
            WriteLine();

            //Cast cpr to ChooseUser(), get User back
            User u = DBConnect.ChooseUser(cpr);
            WriteLine($"Du har valgt {u.Name}:");
            WriteLine("========================\n");
            WriteLine("Vil du redigere i deres:\n");
            WriteLine("1 - Adresse:");
            WriteLine("2 - Position:");
            WriteLine("3 - Password:");
            WriteLine("\n0 - Gå tilbage: ");
            Write("\nIndtast dit valg: ");
            choice = ToInt32(ReadLine());
            //Make sure the user doesn't crash the program by writing something other than what they should
            while (choice != 1 && choice != 2 && choice != 3 && choice != 0)
            {
                Write("Det er ikke et gyldigt valg. Prøv igen:");
                choice = char.ToLower(ToChar(ReadLine()));
            }
            switch (choice)
            {
                case 1:
                    column = "address";
                    break;
                case 2:
                    column = "position";
                    break;
                case 3:
                    column = "password";
                    break;
                case 0:
                    return;
            }
            WriteLine($"\nHvad skal værdien være efter ændringen?");
            newValue = ReadLine();
            DBConnect.Update(column, newValue, cpr);
        }
        public void Delete()
        {
            char choice = 'n';
            Clear();
            WriteLine("======================");
            WriteLine("GMJournal - Slet Bruger");
            WriteLine("======================\n");
            Write("Indtast CPR nummer på den person du vil slette (uden bindestreg): ");
            string cpr = ReadLine();

            //Make sure the user doesn't crash the program by writing something other than what they should
            string dbType = "people";
            int count = DBConnect.Count(dbType, cpr);
            while (cpr.Length != 10 || !cpr.All(char.IsDigit) || count == 0)
            {
                Write("Du har enten indtastet en valid CPR nummer, eller personen ikke eksisterer i systemet. Prøv igen: ");
                cpr = ReadLine();
                count = DBConnect.Count(dbType, cpr);
            }

            WriteLine();
            User u = DBConnect.ChooseUser(cpr);
            WriteLine("========================\n");
            Write($"Er du sikker du vil slette {u.Name} (j/n)? ");
            choice = char.ToLower(ToChar(ReadLine()));
            //I've chosen not to control the user input since deleting a user is so permanent. So if 'j', the user gets deleted,
            //but anything else just brings them back to the menu.
            switch (choice)
            {
                case 'j':
                    DBConnect.Delete(cpr);
                    WriteLine($"{u.Name} er blevet slettet.");
                    break;
                default:
                    break;
            }
            Write("Tryk på en tast for at fortsætte: ");
            ReadKey();
        }
    }
}
