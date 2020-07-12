using System.Windows;
using System.Windows.Input;

namespace GMJournalWPF
{
    /// <summary>
    /// Interaction logic for LoginScreen.xaml
    /// </summary>
    public partial class LoginScreen : Window
    {
        public LoginScreen()
        {
            InitializeComponent();
            username.Focus();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
        }
        private void loginSubmit_Click(object sender, RoutedEventArgs e)
        {
            DBConnect dBConnect = new DBConnect();
            var variables = dBConnect.GetUsernamePassword(username.Text);
            var pass = variables.Item1;
            var position = variables.Item2;
            var type = variables.Item3;

            if (password.Password == pass)
            {
                //something?
                if (position == "System Administrator")
                {
                    Brugere dashboard = new Brugere();
                    dashboard.Show();
                    this.Close();
                }
                else
                {
                    Borgere dashboard = new Borgere();
                    dashboard.Show();
                    this.Close();
                }
            }
        }
        private void password_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter || e.Key == Key.Return)
            {
                loginSubmit_Click(this, new RoutedEventArgs());
            }
        }
    }
}
