using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace GMJournalWPF
{
    /// <summary>
    /// Interaction logic for UserAdminTest.xaml
    /// </summary>
    public partial class Brugere : Window
    {
        MySqlConnection conn = null;
        public Brugere()
        {
            this.setConnection();
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            cpr_txtbx.Focus();
        }
        private void setConnection()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;
            conn = new MySqlConnection(connectionString);
            try
            {
                conn.Open();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.updateDataGrid();
        }
        private void Window_Closed(object sender, System.EventArgs e)
        {
            conn.Close();
        }
        public void updateDataGrid()
        {
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT cpr, name, address, position, username, password " +
                    "FROM people WHERE type = 'user'";
            cmd.CommandType = CommandType.Text;
            MySqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dt.Columns["password"].Expression = "'*******'";
            userDataGrid.ItemsSource = dt.DefaultView;
            dr.Close();
        }
        private void cpr_txtbx_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!char.IsDigit(e.Text, e.Text.Length - 1))
                e.Handled = true;
        }
        private void add_btn_Click(object sender, RoutedEventArgs e)
        {
            string statement = "INSERT INTO people (type, cpr, name, address, position, username, password) " +
                "VALUES ('user', @cpr, @name, @address, @position, @username, @password)";
            this.AUD(statement, 0);
            add_btn.IsEnabled = false;
            edit_btn.IsEnabled = true;
            delete_btn.IsEnabled = true;
        }
        //FIX THIS
        private void edit_btn_Click(object sender, RoutedEventArgs e)
        {
            string statement = "UPDATE people SET address = @address, username = @username, password = @password " +
                "WHERE cpr = @cpr";
            this.AUD(statement, 1);
        }
        private void delete_btn_Click(object sender, RoutedEventArgs e)
        {
            string statement = "DELETE FROM people WHERE cpr = @cpr";
            this.AUD(statement, 2);
            this.resetAll();
        }
        private void resetAll()
        {
            cpr_txtbx.Text = "";
            name_txtbx.Text = "";
            address_txtbx.Text = "";
            position_combobx.Text = "";
            username_txtbx.Text = "";
            password_txtbx.Clear();
            add_btn.IsEnabled = true;
            edit_btn.IsEnabled = false;
            delete_btn.IsEnabled = false;
            cpr_txtbx.IsEnabled = true;
            name_txtbx.IsEnabled = true;
            position_combobx.IsEnabled = true;
        }
        private void reset_btn_Click(object sender, RoutedEventArgs e)
        {
            this.resetAll();
        }
        private void AUD(string statement, int state)
        {
            string msg = "";
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = statement;
            cmd.CommandType = CommandType.Text;

            switch (state)
            {
                case 0:
                    msg = "Bruger tilføjet.";
                    cmd.Parameters.Add("@cpr", MySqlDbType.Text, 10).Value = cpr_txtbx.Text;
                    cmd.Parameters.Add("@name", MySqlDbType.Text).Value = name_txtbx.Text;
                    cmd.Parameters.Add("@address", MySqlDbType.Text).Value = address_txtbx.Text;
                    cmd.Parameters.Add("@position", MySqlDbType.Text).Value = position_combobx.Text;
                    cmd.Parameters.Add("@username", MySqlDbType.Text).Value = username_txtbx.Text;
                    cmd.Parameters.Add("@password", MySqlDbType.Text).Value = password_txtbx.Password;
                    break;
                case 1:
                    msg = "Bruger modificeret.";
                    cmd.Parameters.Add("@cpr", MySqlDbType.Text, 10).Value = cpr_txtbx.Text;
                    cmd.Parameters.Add("@address", MySqlDbType.Text).Value = address_txtbx.Text;
                    cmd.Parameters.Add("@username", MySqlDbType.Text).Value = username_txtbx.Text;
                    cmd.Parameters.Add("@password", MySqlDbType.Text).Value = password_txtbx.Password;
                    break;
                case 2:
                    msg = "Bruger slettet.";
                    cmd.Parameters.Add("@cpr", MySqlDbType.Text, 10).Value = cpr_txtbx.Text;
                    break;
            }
            try
            {
                int n = cmd.ExecuteNonQuery();
                if (n > 0)
                {
                    MessageBox.Show(msg);
                    this.updateDataGrid();
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void userDataGrid_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            DataGrid dg = sender as DataGrid;
            DataRowView dr = dg.SelectedItem as DataRowView;
            if (dr != null)
            {
                cpr_txtbx.Text = dr["cpr"].ToString();
                name_txtbx.Text = dr["name"].ToString();
                address_txtbx.Text = dr["address"].ToString();
                position_combobx.Text = dr["position"].ToString();
                username_txtbx.Text = dr["username"].ToString();
                password_txtbx.Password = dr["password"].ToString();

                add_btn.IsEnabled = false;
                edit_btn.IsEnabled = true;
                delete_btn.IsEnabled = true;
                cpr_txtbx.IsEnabled = false;
                name_txtbx.IsEnabled = false;
                position_combobx.IsEnabled = false;
                username_txtbx.IsEnabled = true;
                password_txtbx.IsEnabled = true;
            }
        }
    }
}
