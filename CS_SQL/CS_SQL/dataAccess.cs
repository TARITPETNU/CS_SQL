using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_SQL
{
    class dataAccess
    {
        public static void InitializeDatabase()
        {


            using (SqliteConnection db = new SqliteConnection("Filename=Customers.db"))
            {
                db.Open();
                String tableCommand = "CREATE TABLE IF NOT " + "EXISTS Customers (UID INTEGER PRIMARY KEY, " +" firstName NVARCHAR(2048), " + "lastName NVARCHAR(20), " + "Email NVARCHAR(100) NULL)";

                SqliteCommand createTable = new SqliteCommand(tableCommand, db);

                createTable.ExecuteReader();
            }
        }
        public static void AddData(int ID, string name, string lastname, string Email)
        {
              using (SqliteConnection db =
              new SqliteConnection("Filename=Customers.db"))
            {
                db.Open();

                SqliteCommand insertCommand = new SqliteCommand();
                insertCommand.Connection = db;

                insertCommand.CommandText = "INSERT INTO Customers VALUES (@UID, @firstName, @lastName, @Email);";
                insertCommand.Parameters.AddWithValue("@UID", ID);
                insertCommand.Parameters.AddWithValue("@firstName", name);
                insertCommand.Parameters.AddWithValue("@lastName", lastname);
                insertCommand.Parameters.AddWithValue("@Email", Email);

                insertCommand.ExecuteReader();

                db.Close();
            }

        }
        public static List<String> GetData()
        {
            List<String> entries = new List<string>();   
            using (SqliteConnection db =
               new SqliteConnection("Filename=Customers.db"))
            {
                db.Open();

                SqliteCommand selectCommand = new SqliteCommand
                    ("SELECT * from Customers", db);

                SqliteDataReader query = selectCommand.ExecuteReader();

                while (query.Read())
                {
                    entries.Add(query.GetString(0));
                    entries.Add(query.GetString(1));
                    entries.Add(query.GetString(2));
                    entries.Add(query.GetString(3));
                }

                db.Close();
            }

            return entries;
        }
    }
}
