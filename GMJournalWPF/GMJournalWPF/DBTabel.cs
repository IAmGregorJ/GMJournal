using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Configuration;
using MySql.Data.MySqlClient;
namespace GMJournalWPF
{
    class DBTabel
    {
        MySqlConnection connection;
        MySqlDataAdapter adapter;
        public DataTable GetTable(String query, String sortBy)
        {
            connection = new MySqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            adapter = new MySqlDataAdapter(query, connection);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            dataTable.DefaultView.Sort = sortBy;
            return dataTable;
        }
    }
}
