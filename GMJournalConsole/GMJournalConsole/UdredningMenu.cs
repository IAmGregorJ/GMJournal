using System.Linq;
using static System.Console;
using static System.Convert;

namespace GMJournalConsole
{
    class UdredningMenu
    {
        public void Start()
        {
            int choice;
            do
            {
                Clear();
                WriteLine("======================");
                WriteLine("GMJournal - Udredningsmenu");
                WriteLine("======================\n");
                WriteLine("1 - Oprette en ny udredning ");
                WriteLine("2 - Se udredning på en borger: ");
                WriteLine("\n0 - Afslut:");
                Write("\n\nIndast dit valg: ");

                choice = ToInt32(ReadLine());
                //Make sure the user doesn't crash the program by writing something other than what they should
                while (choice != 1 && choice != 2 && choice != 0)
                {
                    Write("Det er ikke et gyldigt valg. Prøv igen:");
                    choice = char.ToLower(ToChar(ReadLine()));
                }

                switch (choice)
                {
                    case 1:
                        AddUdredning();
                        break;
                    case 2:
                        Udredning u = new Udredning();
                        u.ShowData();
                        break;
                    case 0:
                        break;
                }
            }
            while (choice != 0);
        }
        public void AddUdredning()
        {
            //get the data
            Udredning udredning = new Udredning();
            udredning.SetData();
            //write the data to the database
            DBConnect.Insert(udredning);
        }
    }
}