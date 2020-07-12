using static System.Console;

namespace GMJournalConsole
{
    class Citizen : Person
    {
        public Citizen()
        {
        }
        public Citizen(string cpr, string name, string address, string maalgruppe)
        {
        }
        public override void SetData()
        {
            base.SetData();
            //maalgruppe will first be added when the user adds an "udredning" to the citizen.
            Write("Målgruppen bliver først tilføjet til borgeren ved udredningen.");
            maalgruppe = "";
            ReadKey();
            WriteLine();
            Write($"\nBorgeren {name} er oprettet. Tryk en tast for at komme tilbage til menuen.");
            ReadKey();
        }
    }
}
