using System;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace DatabeseMenedger.Database
{
    class Db
    {
        private bool result = false;

        private const string Host = ParametersConnect.HOST;
        private const string Port = ParametersConnect.PORT; // 3306
        private const string Database = ParametersConnect.DATABASE;
        private const string User = ParametersConnect.USER; // mysql
        private const string Pass = ParametersConnect.PASS; // ""
        private string _connect;
        private MySqlCommand _command;


        public void CrateTable(string nameTable)
        {
            _connect = $"Server={Host};User={User};Password={Pass};Database={Database};Port={Port};";

            string tableIfNotExistsUsersIdIntAutoIncrementPrimaryKeyLoginVarchar =
                "CREATE TABLE IF NOT EXISTS @nameTable (" +
                "id INT(11) AUTO_INCREMENT PRIMARY KEY," +
                "login VARCHAR(50)," +
                "password VARCHAR(50)" +
                ") ENGINE=MYISAM";

            Connect(tableIfNotExistsUsersIdIntAutoIncrementPrimaryKeyLoginVarchar);
        }

        public void CrateDb(string nameDatabase)
        {
            Console.WriteLine("CrateDb CREATE  @nameDatabase");
            _connect = $"Server={Host};User={User};Password={Pass};Port={Port};";


            string createDatabase = "CREATE DATABASE IF NOT EXISTS " + nameDatabase;

            Connect(createDatabase);

            if (result)
            {
                Console.WriteLine("CrateDb  CREATE " + nameDatabase + "Ok");

            }
            else
            {
                Console.WriteLine("CrateDb  CREATE " + nameDatabase + "False");

            }

        }

        private async Task Connect(string commandCommandText)
        {
            using (MySqlConnection conn = new MySqlConnection(_connect))
            {
                try
                {
                    await conn.OpenAsync();
                    Console.WriteLine("Open");

                    _command = new MySqlCommand();


                    _command.CommandText = commandCommandText;
                    _command.Connection = conn;
                    await _command.ExecuteNonQueryAsync();
                    Console.WriteLine("Dne");
                    result = true;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    result = false;

                    throw;
                }
                finally
                {
                    await _command.Connection.CloseAsync();
                    Console.WriteLine("CloseAsync");
                }
            }
        }
    }
}