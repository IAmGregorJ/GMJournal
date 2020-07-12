using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data;
using System.Windows;
using System;
using System.Windows.Controls;
using System.Windows.Input;

namespace GMJournalWPF
{
    /// <summary>
    /// Interaction logic for Udredning.xaml
    /// </summary>
    public partial class Udredning : Window
    {
        MySqlConnection conn = null;
        string cpr = "poop";
        public Udredning(string sentCpr)
        {
            cpr = sentCpr;
            this.setConnection();
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
        }
        private void setConnection()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;
            conn = new MySqlConnection(connectionString);
            try
            {
                conn.Open();
            }
            catch(MySqlException ex)
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
        private void updateDataGrid()
        {
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT date, cpr, fysiskFunktionsnedsaettelse, psykiskFunktionsnedsaettelse, " +
                "socialtProblem, praktiskeOpgaverIHjemmet, egenomsorg, mobilitet, kommunikation, samfundsliv, socialtLiv, " +
                "sundhed, omgivelser, samletFagligVurdering, samletFagligVurderingBeskrivelse, maalgruppe " +
                $"FROM udredning WHERE cpr = '{cpr}'";
            cmd.CommandType = CommandType.Text;
            MySqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            udredningDataGrid.ItemsSource = dt.DefaultView;
            dr.Close();
            this.udredningDataGrid.SelectionMode = DataGridSelectionMode.Single;
            this.udredningDataGrid.SelectedIndex = 0;
            if (maalgruppe_combobx.Text == "")
            {
                gemUdredningen_btn.IsEnabled = true;
                date_dtpk.IsEnabled = true;
                cpr_txtbx.IsEnabled = true;
                fysiskFunktionsnedsaettelse_txtbx.IsEnabled = true;
                psykiskFunktionsnedsaettelse_txtbx.IsEnabled = true;
                socialtProblem_txtbx.IsEnabled = true;
                praktiskeOpgaverIHjemmet_txtbx.IsEnabled = true;
                egenomsorg_txtbx.IsEnabled = true;
                mobilitet_txtbx.IsEnabled = true;
                kommunikation_txtbx.IsEnabled = true;
                samfundsliv_txtbx.IsEnabled = true;
                socialtliv_txtbx.IsEnabled = true;
                sundhed_txtbx.IsEnabled = true;
                omgivelser_txtbx.IsEnabled = true;
                samletFagligVurdering_combobx.IsEnabled = true;
                maalgruppe_combobx.IsEnabled = true;
                samletFagligVurderingBeskrivelse_txtbx.IsEnabled = true;
            }
            else
            {
                gemUdredningen_btn.IsEnabled = false;
                date_dtpk.IsEnabled = false;
                cpr_txtbx.IsEnabled = false;
                fysiskFunktionsnedsaettelse_txtbx.IsEnabled = false;
                psykiskFunktionsnedsaettelse_txtbx.IsEnabled = false;
                socialtProblem_txtbx.IsEnabled = false;
                praktiskeOpgaverIHjemmet_txtbx.IsEnabled = false;
                egenomsorg_txtbx.IsEnabled = false;
                mobilitet_txtbx.IsEnabled = false;
                kommunikation_txtbx.IsEnabled = false;
                samfundsliv_txtbx.IsEnabled = false;
                socialtliv_txtbx.IsEnabled = false;
                sundhed_txtbx.IsEnabled = false;
                omgivelser_txtbx.IsEnabled = false;
                samletFagligVurdering_combobx.IsEnabled = false;
                maalgruppe_combobx.IsEnabled = false;
                samletFagligVurderingBeskrivelse_txtbx.IsEnabled = false;
            }
        }
        private void gemUdredningen_btn_Click(object sender, RoutedEventArgs e)
        {
            string statement = "INSERT INTO udredning (date, cpr, fysiskFunktionsnedsaettelse, psykiskFunktionsnedsaettelse, " +
                "socialtProblem, praktiskeOpgaverIHjemmet, egenomsorg, mobilitet, kommunikation, samfundsliv, socialtLiv, " +
                "sundhed, omgivelser, samletFagligVurdering, samletFagligVurderingBeskrivelse, maalgruppe) " +
                "VALUES (@date, @cpr, @fysiskFunktionsnedsaettelse, @psykiskFunktionsnedsaettelse, " +
                "@socialtProblem, @praktiskeOpgaverIHjemmet, @egenomsorg, @mobilitet, @kommunikation, @samfundsliv, @socialtLiv, " +
                "@sundhed, @omgivelser, @samletFagligVurdering, @samletFagligVurderingBeskrivelse, @maalgruppe)";
            this.AUD(statement, 0);
            string statementMaal = "UPDATE people SET maalgruppe = @maalgruppe WHERE cpr = @cpr";
            this.AUD(statementMaal, 1);
            gemUdredningen_btn.IsEnabled = false;
        }
        private void AUD(string statement, int state)
        {
            string msg = "";
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = statement;
            cmd.CommandType = CommandType.Text;
            switch(state)
            {
                case 0:
                    msg = "Udredningen gemt.";
                    cmd.Parameters.Add("@date", MySqlDbType.Date).Value = (DateTime.Now).ToString("yyyy-MM-dd");
                    cmd.Parameters.Add("@cpr", MySqlDbType.Text, 10).Value = cpr_txtbx.Text;
                    cmd.Parameters.Add("@fysiskFunktionsnedsaettelse", MySqlDbType.Text).Value = fysiskFunktionsnedsaettelse_txtbx.Text;
                    cmd.Parameters.Add("@psykiskFunktionsnedsaettelse", MySqlDbType.Text).Value = psykiskFunktionsnedsaettelse_txtbx.Text;
                    cmd.Parameters.Add("@socialtProblem", MySqlDbType.Text).Value = socialtProblem_txtbx.Text;
                    cmd.Parameters.Add("@praktiskeOpgaverIHjemmet", MySqlDbType.Text).Value = praktiskeOpgaverIHjemmet_txtbx.Text;
                    cmd.Parameters.Add("@egenomsorg", MySqlDbType.Text).Value = egenomsorg_txtbx.Text;
                    cmd.Parameters.Add("@mobilitet", MySqlDbType.Text).Value = mobilitet_txtbx.Text;
                    cmd.Parameters.Add("@kommunikation", MySqlDbType.Text).Value = kommunikation_txtbx.Text;
                    cmd.Parameters.Add("@samfundsliv", MySqlDbType.Text).Value = samfundsliv_txtbx.Text;
                    cmd.Parameters.Add("@socialtLiv", MySqlDbType.Text).Value = socialtliv_txtbx.Text;
                    cmd.Parameters.Add("@sundhed", MySqlDbType.Text).Value = sundhed_txtbx.Text;
                    cmd.Parameters.Add("@omgivelser", MySqlDbType.Text).Value = omgivelser_txtbx.Text;
                    cmd.Parameters.Add("@samletFagligVurdering", MySqlDbType.Text).Value = samletFagligVurdering_combobx.Text;
                    cmd.Parameters.Add("@samletFagligVurderingBeskrivelse", MySqlDbType.Text).Value = samletFagligVurderingBeskrivelse_txtbx.Text;
                    cmd.Parameters.Add("@maalgruppe", MySqlDbType.Text).Value = maalgruppe_combobx.Text;
                    break;
                case 1:
                    msg = "Målgruppe tilføjet til borgeren.";
                    cmd.Parameters.Add("@cpr", MySqlDbType.Text).Value = cpr_txtbx.Text;
                    cmd.Parameters.Add("@maalgruppe", MySqlDbType.Text).Value = maalgruppe_combobx.Text;
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
        private void udredningDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid dg = sender as DataGrid;
            DataRowView dr = dg.SelectedItem as DataRowView;
            if (dr != null)
            {
                date_dtpk.Text = dr["date"].ToString();
                cpr_txtbx.Text = dr["cpr"].ToString();
                fysiskFunktionsnedsaettelse_txtbx.Text = dr["fysiskFunktionsnedsaettelse"].ToString();
                psykiskFunktionsnedsaettelse_txtbx.Text = dr["psykiskFunktionsnedsaettelse"].ToString();
                socialtProblem_txtbx.Text = dr["socialtProblem"].ToString();
                praktiskeOpgaverIHjemmet_txtbx.Text = dr["praktiskeOpgaverIHjemmet"].ToString();
                egenomsorg_txtbx.Text = dr["egenomsorg"].ToString();
                mobilitet_txtbx.Text = dr["mobilitet"].ToString();
                kommunikation_txtbx.Text = dr["kommunikation"].ToString();
                samfundsliv_txtbx.Text = dr["samfundsliv"].ToString();
                socialtliv_txtbx.Text = dr["socialtLiv"].ToString();
                sundhed_txtbx.Text = dr["sundhed"].ToString();
                omgivelser_txtbx.Text = dr["omgivelser"].ToString();
                samletFagligVurdering_combobx.Text = dr["samletFagligVurdering"].ToString();
                samletFagligVurderingBeskrivelse_txtbx.Text = dr["samletFagligVurderingBeskrivelse"].ToString();
                maalgruppe_combobx.Text = dr["maalgruppe"].ToString();
            }
            else
            {
                cpr_txtbx.Text = cpr;
                date_dtpk.Text = (DateTime.Now).ToString("yyyy-MM-dd");
            }
        }
    }
}
