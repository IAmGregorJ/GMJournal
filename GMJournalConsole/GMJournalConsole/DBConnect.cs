using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Configuration;
using static System.Console;
using static System.Convert;

namespace GMJournalConsole
{
    /* This class has been made static in order to save code throughout the project - no more need to instantiate 
     * the class everywhere it is used - DBConnect.GetUsernamePassword() will now suffice*/
    static class DBConnect
    {
        private static MySqlConnection connection;

        static DBConnect()
        {
            connection = new MySqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        }
        private static bool OpenConnection()
        {
            try
            {
                connection.Open();
                return true;
            }
            //Printing out an eventual exception in this case will let the user know tha there are connection issues to the database
            catch (MySqlException ex)
            {
                WriteLine($"Error: {ex.ToString()}");
            }
            return false;
        }
        private static bool CloseConnection()
        {
            try
            {
                connection.Close();
                return true;
            }
            //Printing out an eventual exception in this case will let the user know tha there are connection issues to the database
            catch (MySqlException ex)
            {
                WriteLine($"Error: {ex.ToString()}");
            }
            return false;
        }

        //Current user (at login)
        public static (string, string) GetUsernamePassword(string currentuser)
        {
            string password = "";
            string position = "";
            //It's true that I could have done this in a better way with fewer lines of code, but I typed this out while testing
            //the possibilities, and it worked. I chose instead to concentrate on perfecting the code in other areas of my program,
            //because this works just fine as it is.
            string queryPassword = $"SELECT password FROM people WHERE username = '{currentuser}'";
            string queryPosition = $"SELECT position FROM people WHERE username = '{currentuser}'";

            //make sure the connection is open
            if(OpenConnection() == true)
            {
                MySqlCommand commandPassword = new MySqlCommand(queryPassword, connection);

                password = commandPassword.ExecuteScalar().ToString();

                MySqlCommand commandPosition = new MySqlCommand(queryPosition, connection);
                position = commandPosition.ExecuteScalar().ToString();

                //close connection
                CloseConnection();

                return (password, position);
            }
            //the else statement is redundant, since if(OpenConnection() == false) it will return an exception. However, 
            //omitting the else gives an error that not all code paths return a value
            else
            {
                return (password, position);
            }
        }
        public static List<User> ListUsers(string dbType, string personType)
        {
            //I brought dbType and personType down because this was the first list that I created - I wasn't sure if I would end
            //up using the same method for Citizen as well. I ended up not using the same method, because the objects, and
            //therefore the paramaters that need to be returned, are different.
            string query = $"SELECT * FROM {dbType} WHERE type = '{personType}'";

            //create list
            List<User> list = new List<User>();

            if(OpenConnection() == true)
            {
                //create command
                MySqlCommand command = new MySqlCommand(query, connection);

                //create datareader and execute
                MySqlDataReader reader = command.ExecuteReader();

                //read data and put in list as long as there are items to be read / while(reader.Read())
                while (reader.Read())
                {
                    User u = new User();
                    u.CPR = reader["cpr"].ToString();
                    u.Name = reader["name"].ToString();
                    u.Address = reader["address"].ToString();
                    u.Position = reader["position"].ToString();
                    u.Username = reader["username"].ToString();
                    u.Password = reader["password"].ToString();

                    list.Add(u);
                }

                //close datareader
                reader.Close();

                //close connection
                CloseConnection();
                //return list
                return list;
            }
            else
            {
                return list;
            }
        }
        public static List<Citizen> ListCitizens(string dbType, string personType)
        {
            string query = $"SELECT * FROM {dbType} WHERE type = '{personType}'";

            //create list
            List<Citizen> list = new List<Citizen>();

            if(OpenConnection() == true)
            {
                //create command
                MySqlCommand command = new MySqlCommand(query, connection);

                //create datareader and execute
                MySqlDataReader reader = command.ExecuteReader();

                //read data and put in list
                while (reader.Read())
                {
                    Citizen c = new Citizen();
                    c.CPR = reader["cpr"].ToString();
                    c.Name = reader["name"].ToString();
                    c.Address = reader["address"].ToString();
                    c.Maalgruppe = reader["maalgruppe"].ToString();

                    list.Add(c);
                }

                //close datareader
                reader.Close();

                //close connection
                CloseConnection();

                //return list
                return list;
            }
            else
            {
                return list;
            }
        }
        public static void Insert(string dbType, string personType, User user)
        {
            string query = $"INSERT INTO {dbType} (type, cpr, name, address, position, username, password) " +
                $"VALUES ('{personType}', '{user.CPR}', '{user.Name}', '{user.Address}', " +
                $"'{user.Position}', '{user.Username}', '{user.Password}')";

            if(OpenConnection() == true)
            {
                //create command - use connection info from Initialise()
                MySqlCommand command = new MySqlCommand(query, connection);

                //ExecuteNonQuery is used because the command returns any data - just the command is executed, and the number
                //of rows affected is returned as well, but I don't use this information in my code.
                command.ExecuteNonQuery();

                //close connection
                CloseConnection();
            }
        }
        public static void Insert(string dbType, string personType, Citizen citizen)
        {
            string query = $"INSERT INTO {dbType} (type, cpr, name, address, maalgruppe) " +
                $"VALUES ('{personType}', '{citizen.CPR}', '{citizen.Name}', '{citizen.Address}', " +
                $"'{citizen.Maalgruppe}')";

            if(OpenConnection() == true)
            {
                //create command - use connection info from Initialise()
                MySqlCommand command = new MySqlCommand(query, connection);

                //execute command
                command.ExecuteNonQuery();

                //close connection
                CloseConnection();
            }
        }
        public static void Insert(Udredning udredning)
        {
            string query = $"INSERT INTO udredning (date, cpr, fysiskFunktionsnedsaettelse, psykiskFunktionsnedsaettelse, " +
                $"socialtProblem, praktiskeOpgaverIHjemmet, egenomsorg, mobilitet, kommunikation, samfundsliv, socialtLiv, " +
                $"sundhed, omgivelser, samletFagligVurdering, samletFagligVurderingBeskrivelse, maalgruppe) " +
                $"VALUES ('{udredning.Date}', '{udredning.CPR}', '{udredning.FysiskFunktionsnedsaettelse}', " +
                $"'{udredning.PsykiskFunktionsnedsaettelse}', '{udredning.SocialtProblem}', '{udredning.PraktiskeOpgaverIHjemmet}', " +
                $"'{udredning.Egenomsorg}', '{udredning.Mobilitet}', '{udredning.Kommunikation}', '{udredning.Samfundsliv}', " +
                $"'{udredning.SocialtLiv}', '{udredning.Sundhed}', '{udredning.Omgivelser}', '{udredning.SamletFagligVurdering}', " +
                $"'{udredning.SamletFagligVurderingBeskrivelse}', '{udredning.Maalgruppe}')";
            string queryMaalgruppe = $"UPDATE people SET maalgruppe = '{udredning.Maalgruppe}' WHERE cpr = '{udredning.CPR}'";


            if (OpenConnection() == true)
            {
                //create command - use connection info from Initialise()
                MySqlCommand command = new MySqlCommand(query, connection);
                MySqlCommand commandMaalgruppe = new MySqlCommand(queryMaalgruppe, connection);

                //execute command
                command.ExecuteNonQuery();
                commandMaalgruppe.ExecuteNonQuery();

                //close connection
                CloseConnection();
            }
        }
        public static void Update(string column, string newValue, string cpr)
        {
            string query = $"UPDATE people SET {column} = '{newValue}' WHERE cpr = '{cpr}'";

            //open connection
            if (OpenConnection() == true)
            {
                //create mysql command
                MySqlCommand command = new MySqlCommand();
                //Assign query using CommandText
                command.CommandText = query;
                //Assign the connection using Connection
                command.Connection = connection;

                //Execute query
                command.ExecuteNonQuery();

                //close connection
                CloseConnection();
            }
        }
        public static void Delete(string cpr)
        {
            string query = $"DELETE FROM people WHERE cpr = '{cpr}'";

            if (OpenConnection() == true)
            {
                //create mysql command
                MySqlCommand command = new MySqlCommand(query, connection);

                //execute command
                command.ExecuteNonQuery();

                //close connection
                CloseConnection();
            }
        }
        public static User ChooseUser(string cpr)
        {
            string query = $"SELECT * FROM people where cpr = '{cpr}'";
            User u = new User();

            if(OpenConnection() == true)
            {
                //create command
                MySqlCommand command = new MySqlCommand(query, connection);

                //create datareader and execute
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    u.CPR = cpr;
                    u.Name = reader["name"].ToString();
                    u.Address = reader["address"].ToString();
                    u.Position = reader["position"].ToString();
                    u.Position = reader["username"].ToString();
                    u.Password = reader["password"].ToString();
                }
                reader.Close();

                //close connection
                CloseConnection();

                //return User
                return u;
            }
            else
            {
                return u;
            }
        }
        public static Citizen ChooseCitizen(string cpr)
        {
            string query = $"SELECT * FROM people where cpr = '{cpr}'";
            Citizen c = new Citizen();

            if(OpenConnection() == true)
            {
                //create command
                MySqlCommand command = new MySqlCommand(query, connection);

                //create datareader and execute
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    c.CPR = cpr;
                    c.Name = reader["name"].ToString();
                    c.Address = reader["address"].ToString();
                    c.Maalgruppe = reader["maalgruppe"].ToString();
                }

                //close datareader
                reader.Close();

                //close connection
                CloseConnection();

                //return list
                return c;
            }
            else
            {
                return c;
            }
        }
        public static Udredning ChooseUdredning(string cpr)
        {
            string query = $"SELECT * FROM udredning where cpr = '{cpr}'";
            Udredning u = new Udredning();

            if(OpenConnection() == true)
            {
                //create command
                MySqlCommand command = new MySqlCommand(query, connection);

                //create datareader and execute
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    //FIX DATE
                    u.Date = reader["date"].ToString();
                    u.CPR = cpr;
                    u.FysiskFunktionsnedsaettelse = reader["fysiskFunktionsnedsaettelse"].ToString();
                    u.PsykiskFunktionsnedsaettelse = reader["psykiskFunktionsnedsaettelse"].ToString();
                    u.SocialtProblem = reader["socialtProblem"].ToString();
                    u.PraktiskeOpgaverIHjemmet = reader["praktiskeOpgaverIHjemmet"].ToString();
                    u.Egenomsorg = reader["egenomsorg"].ToString();
                    u.Mobilitet = reader["mobilitet"].ToString();
                    u.Kommunikation = reader["kommunikation"].ToString();
                    u.Samfundsliv = reader["samfundsliv"].ToString();
                    u.SocialtLiv = reader["socialtLiv"].ToString();
                    u.Sundhed = reader["sundhed"].ToString();
                    u.Omgivelser = reader["omgivelser"].ToString();
                    u.SamletFagligVurdering = reader["samletFagligVurdering"].ToString();
                    u.SamletFagligVurderingBeskrivelse = reader["samletFagligVurderingBeskrivelse"].ToString();
                    u.Maalgruppe = reader["maalgruppe"].ToString();
                }

                //close datareader
                reader.Close();

                //close connection
                CloseConnection();

                //return list
                return u;
            }
            else
            {
                return u;
            }
        }
        public static int Count(string dbType, string cpr)
        {
            //Counting gives me the possibility not only to return a row count where necessary (which I haven't done - instead
            //counting the items in the returned list (DBConnect.List<>)), but it also gives me the possibility to check
            //if the user/citizen/udredning already exists in the database - i.e. if(count == >0)
            string query = $"SELECT COUNT(*) FROM {dbType} WHERE cpr = '{cpr}'";
            int count = -1;
            if (OpenConnection() == true)
            {
                MySqlCommand command = new MySqlCommand(query, connection);
                count = ToInt32(command.ExecuteScalar());
                CloseConnection();
                return count;
            }
            else
            {
                return count;
            }
        }
    }
}
