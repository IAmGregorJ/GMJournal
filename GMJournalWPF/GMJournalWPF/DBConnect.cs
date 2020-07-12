using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using MySql.Data.MySqlClient;
using static System.Console;

namespace GMJournalWPF
{
    class DBConnect
    {
        private MySqlConnection connection;
        private string server;
        private string database;
        private string uid;
        private string password;
        private string position;
        private string type;

        //Constructor
        public DBConnect()
        {
            Initialise();
        }

        //Values to initialise - modify them to match your db
        private void Initialise()
        {
            server = "url";
            database = "thisismycode_site_db_study";
            uid = "username";
            password = "***********";
            string connectionString;
            connectionString = $"SERVER = {server}; DATABASE = {database}; UID = {uid}; PASSWORD = {password}";

            connection = new MySqlConnection(connectionString);
        }

        //open connection to database
        private bool OpenConnection()
        {
            try
            {
                connection.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            return false;
        }

        //Close connection
        private bool CloseConnection()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            return false;
        }
        public (string, string, string) GetUsernamePassword(string currentuser)
        {
            string queryPassword = $"SELECT password FROM people WHERE username = '{currentuser}'";
            string queryPosition = $"SELECT position FROM people WHERE username = '{currentuser}'";
            string queryType = $"SELECT type FROM people WHERE username = '{currentuser}'";

            //open connection
            if (this.OpenConnection() == true)
            {
                MySqlCommand commandPassword = new MySqlCommand(queryPassword, connection);

                //ExecuteScalar fordi der er kun 1 værdi der returneres
                password = (commandPassword.ExecuteScalar() + "");

                MySqlCommand commandPosition = new MySqlCommand(queryPosition, connection);
                position = (commandPosition.ExecuteScalar() + "");

                MySqlCommand commandType = new MySqlCommand(queryType, connection);
                type = (commandType.ExecuteScalar() + "");

                //close connection
                this.CloseConnection();

                return (password, position, type);
            }
            else
            {
                return (password, position, type);
            }

            ////Insert statement DONE
            //public void InsertUser(string dbType, string personType, User newUser)
            //{
            //    string query = $"INSERT INTO {dbType} (type, cpr, name, address, maalgruppe, position, username, password) " +
            //        $"VALUES ('{personType}', '{newUser.CPR}', '{newUser.Name}', '{newUser.Address}', " +
            //        $"'{newUser.maalgruppe}', '{newUser.Position}', '{newUser.Username}', '{newUser.Password}')";

            //    //open connection
            //    if (this.OpenConnection() == true)
            //    {
            //        //create command - use connection info from Initialise()
            //        MySqlCommand command = new MySqlCommand(query, connection);

            //        //execute command
            //        command.ExecuteNonQuery();

            //        //close connection
            //        this.CloseConnection();
            //    }
            //}
            //public void InsertCitizen(string dbType, string personType, Citizen newPerson)
            //{
            //    string query = $"INSERT INTO {dbType} (type, cpr, name, address, maalgruppe, position, username, password) " +
            //        $"VALUES ('{personType}', '{newPerson.CPR}', '{newPerson.Name}', '{newPerson.Address}', " +
            //        $"'{newPerson.maalgruppe}', '{newPerson.Position}', '{newPerson.Username}', '{newPerson.Password}')";

            //    //open connection
            //    if (this.OpenConnection() == true)
            //    {
            //        //create command - use connection info from Initialise()
            //        MySqlCommand command = new MySqlCommand(query, connection);

            //        //execute command
            //        command.ExecuteNonQuery();

            //        //close connection
            //        this.CloseConnection();
            //    }
            //}

            ////Update statement DONE
            //public void Update(string column, string newValue, string cpr)
            //{
            //    //Få input fra bruger for at modificere dette - prøv at lave en generisk statement
            //    string query = $"UPDATE people SET {column} = '{newValue}' WHERE cpr = '{cpr}'";

            //    //open connection
            //    if (this.OpenConnection() == true)
            //    {
            //        //create mysql command
            //        MySqlCommand command = new MySqlCommand();
            //        //Assign query using CommandText
            //        command.CommandText = query;
            //        //Assign the connection using Connection
            //        command.Connection = connection;

            //        //Execute query
            //        command.ExecuteNonQuery();

            //        //close connection
            //        this.CloseConnection();
            //    }
            //}

            ////Delete statement DONE
            //public void Delete(string cpr)
            //{
            //    //Få input fra bruger for at modificere dette - prøv at lave en generisk statement
            //    string query = $"DELETE FROM people WHERE cpr = '{cpr}'";

            //    if (this.OpenConnection() == true)
            //    {
            //        //create mysql command
            //        MySqlCommand command = new MySqlCommand(query, connection);

            //        //execute command
            //        command.ExecuteNonQuery();

            //        //close connection
            //        this.CloseConnection();
            //    }
            //}

            ////Select statement DONE
            //public List<string>[] Select(string dbType, string personType)
            //{
            //    //husk at sætte en variabel for tabel - måske? Er det nødvendigt at liste fra skema?
            //    string query = $"SELECT * FROM {dbType} WHERE type = '{personType}'";

            //    //create list
            //    List<string>[] list = new List<string>[9];
            //    list[0] = new List<string>();
            //    list[1] = new List<string>();
            //    list[2] = new List<string>();
            //    list[3] = new List<string>();
            //    list[4] = new List<string>();
            //    list[5] = new List<string>();
            //    list[6] = new List<string>();
            //    list[7] = new List<string>();
            //    list[8] = new List<string>();

            //    //open connection
            //    if (this.OpenConnection() == true)
            //    {
            //        //create command
            //        MySqlCommand command = new MySqlCommand(query, connection);

            //        //create datareader and execute
            //        MySqlDataReader reader = command.ExecuteReader();

            //        //read data and put in list
            //        while (reader.Read())
            //        {
            //            list[0].Add(reader["id"] + "");
            //            list[1].Add(reader["type"] + "");
            //            list[2].Add(reader["cpr"] + "");
            //            list[3].Add(reader["name"] + "");
            //            list[4].Add(reader["address"] + "");
            //            list[5].Add(reader["maalgruppe"] + "");
            //            list[6].Add(reader["position"] + "");
            //            list[7].Add(reader["username"] + "");
            //            list[8].Add(reader["password"] + "");
            //        }

            //        //close datareader
            //        reader.Close();

            //        //close connection
            //        this.CloseConnection();

            //        //return list
            //        return list;
            //    }
            //    else
            //    {
            //        return list;
            //    }
            //}

            ////Count statement
            //public int Count()
            //{
            //    string query = "COUNT (*) FROM people";
            //    int count = -1;

            //    //open connection
            //    if (this.OpenConnection() == true)
            //    {
            //        //create command
            //        MySqlCommand command = new MySqlCommand(query, connection);

            //        //ExecuteScalar fordi der er kun 1 værdi der returneres
            //        count = ToInt32(command.ExecuteScalar() + "");

            //        //close connection
            //        this.CloseConnection();

            //        return count;
            //    }
            //    else
            //    {
            //        return count;
            //    }
            //}

            ////Choose user DONE
            //public List<string>[] ChoosePerson(string cpr)
            //{
            //    string query = $"SELECT * FROM people where cpr = '{cpr}'";

            //    //create list
            //    List<string>[] list = new List<string>[9];
            //    list[0] = new List<string>();
            //    list[1] = new List<string>();
            //    list[2] = new List<string>();
            //    list[3] = new List<string>();
            //    list[4] = new List<string>();
            //    list[5] = new List<string>();
            //    list[6] = new List<string>();
            //    list[7] = new List<string>();
            //    list[8] = new List<string>();

            //    //open connection
            //    if (this.OpenConnection() == true)
            //    {
            //        //create command
            //        MySqlCommand command = new MySqlCommand(query, connection);

            //        //create datareader and execute
            //        MySqlDataReader reader = command.ExecuteReader();

            //        //read data and put in list
            //        while (reader.Read())
            //        {
            //            list[0].Add(reader["id"] + "");
            //            list[1].Add(reader["type"] + "");
            //            list[2].Add(reader["cpr"] + "");
            //            list[3].Add(reader["name"] + "");
            //            list[4].Add(reader["address"] + "");
            //            list[5].Add(reader["maalgruppe"] + "");
            //            list[6].Add(reader["position"] + "");
            //            list[7].Add(reader["username"] + "");
            //            list[8].Add(reader["password"] + "");
            //        }

            //        //close datareader
            //        reader.Close();

            //        //close connection
            //        this.CloseConnection();

            //        //return list
            //        return list;
            //    }
            //    else
            //    {
            //        return list;
            //    }
            //}

            //Current user? DONE
        }
    }
}
