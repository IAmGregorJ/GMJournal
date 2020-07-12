using System.Linq;
using static System.Console;

namespace GMJournalConsole
{
    abstract class Person
    {
        protected string type;
        public string Type
        {
            get { return type; }
            set { type = value; }
        }
        protected string cpr;
        public string CPR
        {
            get { return cpr; }
            set { cpr = value; }
        }
        protected string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        protected string address;
        public string Address
        {
            get { return address; }
            set { address = value; }
        }
        protected string maalgruppe;
        public string Maalgruppe
        {
            get { return maalgruppe; }
            set { maalgruppe = value; }
        }
        protected string position;
        public string Position
        {
            get { return position; }
            set { position = value; }
        }
        protected string username;
        public string Username
        {
            get { return username; }
            set { username = value; }
        }
        protected string password;
        public string Password
        {
            get { return password; }
            set { password = value; }
        }
        public virtual void SetData()
        {
            Clear();
            WriteLine("======================");
            WriteLine("GMJournal - Ny Person");
            WriteLine("======================\n");
            Write("CPR Nummer (uden bindestreg): ");
            cpr = ReadLine();
            //make sure cpr is 10 digits long, and that the cpr is not in the database beforehand 
            string dbType = "people";
            int count = DBConnect.Count(dbType, cpr);
            while (cpr.Length != 10 || !cpr.All(char.IsDigit) || count > 0)
            {
                Write("Du har enten ikke indtastet en valid CPR nummer, eller personen er i systemet i forvejen. Prøv igen: ");
                cpr = ReadLine();
                count = DBConnect.Count(dbType, cpr);
            }
            WriteLine();
            Write("Navn: ");
            name = ReadLine();
            WriteLine();
            Write("Adresse: ");
            address = ReadLine();
            WriteLine();
        }
    }
}
