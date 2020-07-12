using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using static System.Console;
using static System.Convert;

namespace GMJournalConsole
{
    sealed class Udredning
        /* The class has been sealed to prevent future programmers from creating child classes from it
         * Different types of "udredning" do not exist (in the social sector) so child classes are unnecessary. */
    {
        private string date = (DateTime.Now).ToString("yyyy-MM-dd");
        public string Date
        {
            get { return date; }
            set { date = value; }
        }
        private string cpr;
        public string CPR
        {
            get { return cpr; }
            set { cpr = value; }
        }
        private string fysiskFunktionsnedsaettelse;
        public string FysiskFunktionsnedsaettelse
        {
            get { return fysiskFunktionsnedsaettelse; }
            set { fysiskFunktionsnedsaettelse = value; }
        }
        private string psykiskFunktionsnedsaettelse;
        public string PsykiskFunktionsnedsaettelse
        {
            get { return psykiskFunktionsnedsaettelse; }
            set { psykiskFunktionsnedsaettelse = value; }
        }
        private string socialtProblem;
        public string SocialtProblem
        {
            get { return socialtProblem; }
            set { socialtProblem = value; }
        }
        private string praktiskeOpgaverIHjemmet;
        public string PraktiskeOpgaverIHjemmet
        {
            get { return praktiskeOpgaverIHjemmet; }
            set { praktiskeOpgaverIHjemmet = value; }
        }
        private string egenomsorg;
        public string Egenomsorg
        {
            get { return egenomsorg; }
            set { egenomsorg = value; }
        }
        private string mobilitet;
        public string Mobilitet
        {
            get { return mobilitet; }
            set { mobilitet = value; }
        }
        private string kommunikation;
        public string Kommunikation
        {
            get { return kommunikation; }
            set { kommunikation = value; }
        }
        private string samfundsliv;
        public string Samfundsliv
        {
            get { return samfundsliv; }
            set { samfundsliv = value; }
        }
        private string socialtLiv;
        public string SocialtLiv
        {
            get { return socialtLiv; }
            set { socialtLiv = value; }
        }
        private string sundhed;
        public string Sundhed
        {
            get { return sundhed; }
            set { sundhed = value; }
        }
        private string omgivelser;
        public string Omgivelser
        {
            get { return omgivelser; }
            set { omgivelser = value; }
        }
        private string samletFagligVurdering;
        public string SamletFagligVurdering
        {
            get { return samletFagligVurdering; }
            set { samletFagligVurdering = value; }
        }
        private string samletFagligVurderingBeskrivelse;
        public string SamletFagligVurderingBeskrivelse
        {
            get { return samletFagligVurderingBeskrivelse; }
            set { samletFagligVurderingBeskrivelse = value; }
        }
        private string maalgruppe;
        public string Maalgruppe
        {
            get { return maalgruppe; }
            set { maalgruppe = value; }
        }
        public Udredning()
        {

        }
        public Udredning(string date, string cpr, string fysiskFunktionsnedsaettelse, string psykiskFunktionsnedsaettelse, 
            string socialtProblem, string praktiskeOpgaverIHjemmet, string egenomsorg, string mobilitet, string kommunikation, 
            string samfundsliv, string socialtLiv, string sundhed, string omgivelser, string samletFagligVurdering, 
            string samletFagligVurderingBeskrivelse, string maalgruppe)
        {

        }
        public void SetData()
        {
            //Løsning for at få lov til at skrive mere end 256 karakter i console
            //Jeg må indrømme at det er lidt mere code end jeg forstår, men fordi Sagsbehandlere har tendens til at skrive MEGET,
            //især i en udredning, var jeg nødt til at finde en løsning.
            //Løsningen fundet her: https://stackoverflow.com/a/44135529
            SetIn(new StreamReader(OpenStandardInput(), InputEncoding, false, bufferSize: 8192));

            string date = (DateTime.Now).ToString("yyyy-MM-dd");
            Clear();
            WriteLine("======================");
            WriteLine($"GMJournal - Udredning");
            WriteLine("======================\n");
            Write("Indtast CPR nummber på den borger som i laver udredning på: ");
            cpr = ReadLine();
            //sikre at cpr nr er 10 tal
            //se om borgeren allerede har en udredning
            string dbTypeP = "people";
            string dbTypeU = "udredning";
            int countp = DBConnect.Count(dbTypeP, cpr);
            int countu = DBConnect.Count(dbTypeU, cpr);
            while (cpr.Length != 10 || !cpr.All(char.IsDigit) || countp == 0 || countu > 0)
            {
                Write("Du har enten indtastet en valid CPR nummer, borgeren ikke eksisterer i systemet, " +
                    "\neller har en udredning i forvejen. Prøv igen: ");
                cpr = ReadLine();
                countp = DBConnect.Count(dbTypeP, cpr);
                countu = DBConnect.Count(dbTypeU, cpr);
            }
            //Lots and lots of questions to answer...
            Clear();
            WriteLine("======================");
            WriteLine($"GMJournal - Udredning");
            WriteLine("======================\n");
            WriteLine("Beskriv eventuel fysisk funktionsnedsættelse \n" +
                "(Hørenedsættelse, kommunikationsnedsættelse, mobilitetsnedsættelse, synsnedsættelse, og døvblindhed.)\n");
            fysiskFunktionsnedsaettelse = ReadLine();

            Clear();
            WriteLine("======================");
            WriteLine($"GMJournal - Udredning");
            WriteLine("======================\n");
            WriteLine("Beskriv eventuel psykisk funktionsnedsættelse \n" +
                "(Sindslidelse som angst, depression, forandret virkelighedsopfattelse, personlighedsforstyrrelse, \n" +
                "spiseforstyrrelse, stressbelastning og tilknytningsforstyrrelse. Intellektuel/kognitiv forstyrrelse \n" +
                "som demens, hjerneskade og udviklingsforstyrrelse, herunder opmærksomhedsforstyrrelse og autismespektrum.)\n");
            psykiskFunktionsnedsaettelse = ReadLine();

            Clear();
            WriteLine("======================");
            WriteLine($"GMJournal - Udredning");
            WriteLine("======================\n");
            WriteLine("Beskriv eventuelt socialt problem \n" +
                "(Hjemløshed, ind- og udadreagerende adfærd, kriminalitet, misbrug, omsorgssvigt, overgreb, prostitution, \n" +
                "seksuelt krænkende adfærd, selvskadende adfærd, selvmordstanker og - forsøg og social isolation.)\n");
            socialtProblem = ReadLine();

            Clear();
            WriteLine("======================");
            WriteLine($"GMJournal - Udredning");
            WriteLine("======================\n");
            WriteLine("Beskriv varetagelse af de praktiske opgaver i hjemmet \n" +
                "(Hjælp og omsorg for andre, praktiske opgaver, indkøb, madlavning, rengøring og tøjvask.)\n");
            praktiskeOpgaverIHjemmet = ReadLine();

            Clear();
            WriteLine("======================");
            WriteLine($"GMJournal - Udredning");
            WriteLine("======================\n");
            WriteLine("Beskriv varetagelse af egenomsorg \n" +
                "(Af- og påklædning, vask, kropspleje, toiletbesøg, drikke og spise.)\n");
            egenomsorg = ReadLine();


            Clear();
            WriteLine("======================");
            WriteLine($"GMJournal - Udredning");
            WriteLine("======================\n");
            WriteLine("Beskriv borgerens mobilitet \n" +
                "(Gang og bevægelse, ændre og opretholde kropsstilling, bære, flytte og håndtere genstande og færden \n" +
                "med transportmidler.)\n");
            mobilitet = ReadLine();

            Clear();
            WriteLine("======================");
            WriteLine($"GMJournal - Udredning");
            WriteLine("======================\n");
            WriteLine("Beskriv borgerens kommunikation \n" +
                "(Forstå meddelelser, fremstille meddelelser, samtale, anvendelse af kommunikationshjælpemidler \n" +
                "og -teknikker og kommunikationsmiddel.)\n");
            kommunikation = ReadLine();

            Clear();
            WriteLine("======================");
            WriteLine($"GMJournal - Udredning");
            WriteLine("======================\n");
            WriteLine("Beskriv borgerens samfundsliv " +
                "(Beskæftigelse, bolig, uddannelse og privatøkonomi.Beskæftigelse, bolig, uddannelse og privatøkonomi.)\n");
            samfundsliv = ReadLine();

            Clear();
            WriteLine("======================");
            WriteLine($"GMJournal - Udredning");
            WriteLine("======================\n");
            WriteLine("Beskriv borgerens socialt liv \n" +
                "(Samspil og kontakt, relationer, sociale fællesskaber og netværk.)\n");
            socialtLiv = ReadLine();

            Clear();
            WriteLine("======================");
            WriteLine($"GMJournal - Udredning");
            WriteLine("======================\n");
            WriteLine("Beskriv borgerens sundhed \n" +
                "(Helbredsforhold, kostvaner og livsførelse og medicinsk behandling.)\n");
            sundhed = ReadLine();

            Clear();
            WriteLine("======================");
            WriteLine($"GMJournal - Udredning");
            WriteLine("======================\n");
            WriteLine("Beskriv borgerens omgivelser \n" +
                "(Holdninger i omgivelserne og boligområde.)\n");
            omgivelser = ReadLine();

            #region Samlet faglig vurdering
            Clear();
            WriteLine("======================");
            WriteLine($"GMJournal - Udredning");
            WriteLine("======================\n");
            WriteLine($"Hvad er den samlet faglig vurdering på borgeren?\n");

            char choice;
            WriteLine("A - Intet problem (ingen, fraværende, ubetydelig");
            WriteLine("B - Let problem (en smule, lidt)");
            WriteLine("C - Moderat problem (middel, noget)");
            WriteLine("D - Svært problem (omfattende, meget)");
            WriteLine("E - Fuldstændigt problem (totalt, kan ikke)\n");
            Write("Indtast dit valg: ");
            choice = char.ToLower(ToChar(ReadLine()));
            //These answers are standardised, and need to be identical in order to analyse the data later on
            while(choice != 'a' && choice != 'b' && choice != 'c' && choice != 'd' && choice != 'e')
            {
                Write("Det er ikke et gyldigt valg. Prøv igen:");
                choice = char.ToLower(ToChar(ReadLine()));
            }
            switch(choice)
            {
                case 'a':
                    samletFagligVurdering = "A - Intet problem (ingen, fraværende, ubetydelig)";
                    break;
                case 'b':
                    samletFagligVurdering = "B - Let problem (en smule, lidt)";
                    break;
                case 'c':
                    samletFagligVurdering = "C - Moderat problem (middel, noget)";
                    break;
                case 'd':
                    samletFagligVurdering = "D - Svært problem (omfattende, meget)";
                    break;
                case 'e':
                    samletFagligVurdering = "E - Fuldstændigt problem (totalt, kan ikke)";
                    break;
            }
            #endregion

            Clear();
            WriteLine("======================");
            WriteLine($"GMJournal - Udredning");
            WriteLine("======================\n");
            WriteLine($"Beskriv din Samlet Faglig Vurdering:\n");
            samletFagligVurderingBeskrivelse = ReadLine();

            #region Målgruppe
            #region Målgruppelist
            //Created a list of the pre-defined Målgrupper
            List<string> Maalgrupper = new List<string>
            {
                "1.1.1 Mobilitetsnedsættelse",
                "1.1.2 Synsnedsættelse ",
                "1.1.3 Hørenedsættelse",
                "1.1.4 Kommunikationsnedsættelse",
                "1.1.5 Døvblindhed",
                "1.2.1.1 Demens",
                "1.2.1.2.1 Medfødt hjerneskade",
                "1.2.1.2.2 Erhvervet hjerneskade",
                "1.2.1.3.1 Opmærksomhedsforstyrrelse",
                "1.2.1.3.2 Autismespektrum",
                "1.2.1.4 Udviklingshæmning",
                "1.2.2.1 Angst",
                "1.2.2.2 Depression",
                "1.2.2.3 Forandret virkelighedsopfattelse",
                "1.2.2.4 Personligheds-forstyrrelse",
                "1.2.2.5 Spiseforstyrrelse",
                "1.2.2.6 Tilknytningsforstyrrelse",
                "1.2.2.7 Stressbelastning",
                "2.1 Hjemløshed",
                "2.2 Indadreagerende adfærd",
                "2.3.1 Ikke-personfarlig kriminalitet",
                "2.3.2 Personfarlig kriminalitet",
                "2.4 Selvmordsforsøg eller selvmordstanker",
                "2.5.1 Alkoholmisbrug",
                "2.5.2 Stofmisbrug",
                "2.6 Omsorgssvigt",
                "2.7.1 Seksuelt overgreb",
                "2.7.2 Voldeligt overgreb",
                "2.8 Prostitution",
                "2.9 Seksuelt krænkende adfærd",
                "2.10 Selvskadende adfærd",
                "2.11 Udadreagerende adfærd",
                "2.12 Social isolation"
            };
            #endregion
            maalgruppe = "";
            while(maalgruppe == "")
            {
                Clear();
                WriteLine("======================");
                WriteLine($"GMJournal - Udredning");
                WriteLine("======================\n");
                WriteLine(@"For målgruppekoder, se VUM Metode Håndbog på https://socialstyrelsen.dk/udgivelser/vum");
                Write($"\nIndtast målgruppekode på borgeren:");
                //Created a throwaway variable to search the list
                string maalgruppeTemp = ReadLine();
                //The entire line from the search result is placed in the correct variable
                foreach (var item in Maalgrupper)
                {
                    if (item.Contains(maalgruppeTemp))
                        maalgruppe = item;
                }
            }
            #endregion
        }
        public void ShowData()
        {
            //Standard print of the data, using the Udredning that was cast to this method.f
            Clear();
            WriteLine("======================");
            WriteLine($"GMJournal - Udredning");
            WriteLine("======================\n");
            Write("Indtast CPR nummer på den borger, hvis udredning du vil se (uden bindestreg): ");
            string cpr = ReadLine();
            //make sure cpr is 10 digits long, and that the cpr is in the database beforehand 
            string dbType = "udredning";
            int count = DBConnect.Count(dbType, cpr);
            while (cpr.Length != 10 || !cpr.All(char.IsDigit) || count == 0)
            {
                Write("Du har ikke indtastet et gyldigt CPR nummer, eller borgeren har ingen udredning. Prøv igen: ");
                cpr = ReadLine();
                count = DBConnect.Count(dbType, cpr);
            }
            WriteLine();
            //Cast cpr to ChooseUdredning(), get Udredning back
            Udredning u = DBConnect.ChooseUdredning(cpr);
            WriteLine($"Dato for udredningen: {u.date}");
            WriteLine("\nFysisk Funktionsnedsættelse:\n");
            WriteLine(u.fysiskFunktionsnedsaettelse);
            Write("(...)");
            ReadKey();
            WriteLine("\n\nPsykisk Funktionsnedsættelse:\n");
            WriteLine(u.psykiskFunktionsnedsaettelse);
            Write("(...)");
            ReadKey();
            WriteLine("\n\nSocialt Problem:\n");
            WriteLine(u.socialtProblem);
            Write("(...)");
            ReadKey();
            WriteLine("\n\nPraktiske Opgaver i Hjemmet:\n");
            WriteLine(u.praktiskeOpgaverIHjemmet);
            Write("(...)");
            ReadKey();
            WriteLine("\n\nEgenomsorg:\n");
            WriteLine(u.egenomsorg);
            Write("(...)");
            ReadKey();
            WriteLine("\n\nMobilitet\n");
            WriteLine(u.mobilitet);
            Write("(...)");
            ReadKey();
            WriteLine("\n\nKommunikation:\n");
            WriteLine(u.kommunikation);
            Write("(...)");
            ReadKey();
            WriteLine("\n\nSamfundsliv:\n");
            WriteLine(u.samfundsliv);
            Write("(...)");
            ReadKey();
            WriteLine("\n\nSocialt Liv:\n");
            WriteLine(u.socialtLiv);
            Write("(...)");
            ReadKey();
            WriteLine("\n\nSundhed:\n");
            WriteLine(u.sundhed);
            Write("(...)");
            ReadKey();
            WriteLine("\n\nOmgivelser:\n");
            WriteLine(u.omgivelser);
            Write("(...)");
            ReadKey();
            WriteLine("\n\nSamlet Faglig Vudering:\n");
            WriteLine(u.samletFagligVurdering);
            Write("(...)");
            ReadKey();
            WriteLine("\n\nSamlet Faglig Vurdering - Beskrivelse:\n");
            WriteLine(u.samletFagligVurderingBeskrivelse);
            Write("(...)");
            ReadKey();
            WriteLine("\n\nMålgruppe:\n");
            WriteLine(u.maalgruppe);
            Write("(...)");
            ReadKey();
        }
    }
}
