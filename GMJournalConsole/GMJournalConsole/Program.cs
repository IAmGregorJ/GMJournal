using System;
using System.Runtime.InteropServices;
using static System.Console;

namespace GMJournalConsole
{
    class Program
    {
        //start console program maximized - 
        //https://www.c-sharpcorner.com/code/448/code-to-auto-maximize-console-application-according-to-screen-width-in-c-sharp.aspx
        [DllImport("kernel32.dll", ExactSpelling = true)]
        private static extern IntPtr GetConsoleWindow();
        private static IntPtr ThisConsole = GetConsoleWindow();
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
        private const int Maximise = 3;

        static void Main(string[] args)
        {
            Console.SetWindowSize(Console.LargestWindowWidth, Console.LargestWindowHeight);
            ShowWindow(ThisConsole, Maximise);
        //end code to start console program maximized
            WriteLine("\n\n");
            WriteLine(@"    ________    _____        ____.                                       .__   ");
            WriteLine(@"   /  _____/   /     \      |    |  ____   __ __ _______   ____  _____   |  |  ");
            WriteLine(@"  /   \  ___  /  \ /  \     |    | /  _ \ |  |  \\_  __ \ /    \ \__  \  |  |  ");
            WriteLine(@"  \    \_\  \/    Y    \/\__|    |(  <_> )|  |  / |  | \/|   |  \ / __ \_|  |__");
            WriteLine(@"   \______  /\____|__  /\________| \____/ |____/  |__|   |___|  /(____  /|____/");
            WriteLine(@"          \/         \/                                       \/      \/       ");

            for (int i = 0; i < 3; i++)
            {
                System.Threading.Thread.Sleep(1000);
            }
            LoginMenu loginMenu = new LoginMenu();
            loginMenu.Start();
            ReadKey();
        }
    }

}