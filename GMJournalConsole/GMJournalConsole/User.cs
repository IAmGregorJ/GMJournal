using static System.Console;


namespace GMJournalConsole
{
    class User : Person
    {
        public User()
        {

        }
        public User(string cpr, string name, string address, string position, string username, string password)
        {

        }
        public override void SetData()
        {
            base.SetData();
            Write("Stillingsbetegnelse (Sagsbehandler/System Administrator): ");
            position = ReadLine();
            //Make sure the answer is one of the only two possibilities
            while(position != "Sagsbehandler" && position != "System Administrator")
            {
                Write("Du har ikke indtastet en valid stillingsbetegnelse. Prøv igen: ");
                position = ReadLine();
            }
            WriteLine();
            Write("Brugernavn: ");
            username = ReadLine();
            WriteLine();
            Write("Adgangskode: ");
            password = ReadLine();
            WriteLine();
            Write($"Brugeren {name} er oprettet. Tryk en tast for at komme tilbage til menuen.");
            ReadKey();
        }
    }
}
