using System.Linq;
using static System.Console;
using static System.Convert;

namespace GMJournalConsole
{
    class CitizenMenu
    {
        public string dbType = "people";
        public string personType = "citizen";

        // !!! - There is no way to delete a citizen in this program, since the law prevents this.

        public void Start()
        {
            int choice;
            do
            {
                Clear();
                WriteLine("======================");
                WriteLine("GMJournal - Borgermenu");
                WriteLine("======================\n");
                WriteLine("1 - List borgere:");
                WriteLine("2 - Tilføj en ny borger: ");
                WriteLine("3 - Redigere i en borgers stamdata: ");
                WriteLine("4 - Tilføj/se Udredning");
                WriteLine("\n0 - Afslut programmet:");
                Write("\n\nIndast dit valg: ");

                choice = ToInt32(ReadLine());
                //Make sure the user doesn't crash the program by writing something "illegal"
                while (choice != 1 && choice != 2 && choice != 3 && choice != 4 && choice != 0)
                {
                    Write("Det er ikke et gyldigt valg. Prøv igen:");
                    choice = char.ToLower(ToChar(ReadLine()));
                }

                switch (choice)
                {
                    case 1:
                        ListCitizens();
                        break;
                    case 2:
                        AddCitizen();
                        break;
                    case 3:
                        Modify();
                        break;
                    case 4:
                        UdredningMenu udredningMenu = new UdredningMenu();
                        udredningMenu.Start();
                        break;
                    case 0:
                        WriteLine("Tak for i dag.");
                        break;
                    default:
                        WriteLine("Du har tastet forkert. Prøv igen");
                        Start();
                        break;
                }
            }
            while (choice != 0);
        }
        public void AddCitizen()
        {
            //get the data
            Citizen citizen = new Citizen();
            citizen.SetData();
            //write the data to the database
            DBConnect.Insert(dbType, personType, citizen);
        }

        public void ListCitizens()
        {
            //list is created from the database in DBConnect, then returned here
            var list = DBConnect.ListCitizens(dbType, personType);

            Clear();
            WriteLine("===================");
            WriteLine("GMJournal - Borgere");
            WriteLine("===================\n");
            WriteLine("CPR : Navn : Adresse : Målgruppe");
            //print each object from the returned list
            foreach (Citizen c in list)
            {
                WriteLine($"{c.CPR} : {c.Name} : {c.Address} : {c.Maalgruppe}");
            }
            WriteLine();
            WriteLine($"Der er i alt {list.Count} borgere i databasen.\n");
            Write("Tryk på en tast for at fortsætte: ");
            ReadKey();
        }
        public void Modify()
        {
            string column = "address", newValue;

            Clear();
            WriteLine("======================");
            WriteLine("GMJournal - Redigere Borger");
            WriteLine("======================\n");
            Write("Indtast CPR nummer på den borger du vil redigere: ");
            string cpr = ReadLine();
            //make sure the cpr is 10 digits, and the user exists in the database beforehand
            string dbType = "people";
            int count = DBConnect.Count(dbType, cpr);
            while (cpr.Length != 10 || !cpr.All(char.IsDigit) || count == 0)
            {
                Write("Du har enten ikke indtastet en valid CPR nummer, eller borgeren ikke eksisterer i systemet. Prøv igen: ");
                cpr = ReadLine();
                count = DBConnect.Count(dbType, cpr);
            }
            WriteLine();

            //Cast cpr to ChooseCitizen(), get Citizen back
            Citizen c = DBConnect.ChooseCitizen(cpr);

            WriteLine($"Du har valgt {c.Name}:");
            WriteLine("========================\n");
            //There is  no way to edit anything other than the citizen's address in this program, 
            //since the law specifies these items must be changed centrally
            WriteLine("Du må kun redigere borgerens adresse:\n");
            WriteLine($"\nHvad skal værdien være efter ændringen?");
            newValue = ReadLine();
            DBConnect.Update(column, newValue, cpr);
        }
    }
}