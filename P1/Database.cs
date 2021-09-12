using System;
using System.Collections.Generic;
using Microsoft.Data.Sqlite;

namespace P1
{
    /**
     * This static class should be a provider for an SQLite db
     * Make sure the package is included in your project
     * 
     * 
     * Run the following to install the package in your project directory :
     *      
     *          dotnet add package Microsoft.Data.Sqlite
     * 
     * Read documentation for Microsoft.Data.Sqlite
     * and complete the following functions.
     * 
     * 
     * Note "this" within the function parameter is called a method extension
     * Read : https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/extension-methods
     */
    static class Database
    {
        public static SqliteConnection CreateConnection() 
        {
            
            SqliteConnection connection;
            connection = new SqliteConnection("Data Source=database.db;");
            try
            {
                connection.Open();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return connection;

        }

        public static void CreateTable(this SqliteConnection conn) { 
            SqliteCommand command;
            string Createsql = "CREATE TABLE SampleTable(Name VARCHAR(30), Description VARCHAR(50), Colour VARCHAR(10), Price DOUBLE(5,2))";
            command = conn.CreateCommand();
            command.CommandText = Createsql;
            command.ExecuteNonQuery();

        }
        public static void addProduct(this SqliteConnection conn, Product product) {
            SqliteCommand command;
            command = conn.CreateCommand();
            command.CommandText = $"INSERT INTO SampleTable(Name, Description, Colour, Price) VALUES ('{product.name}', '{product.description}', '{product.colour}', {product.price});";
            command.ExecuteNonQuery();
        }
        public static void InsertProducts(this SqliteConnection conn, IEnumerable<Product> products) {
            foreach(var product in products)
            {
                SqliteCommand command;
                command = conn.CreateCommand();
                command.CommandText = $"INSERT INTO SampleTable(Name, Description, Colour, Price) VALUES ('{product.name}', '{product.description}', '{product.colour}', {product.price});";
                command.ExecuteNonQuery();
            }
            

        }
        
        public static IEnumerable<Product> ReadProducts(this SqliteConnection conn) 
        {
            SqliteDataReader reader;
            SqliteCommand command;
            List<Product> products = new List<Product>();
            command = conn.CreateCommand();
            command.CommandText = "SELECT * FROM SampleTable";

            reader = command.ExecuteReader();

            while (reader.Read())
            {
                string name,description,colour;
                double price;
                name=reader.GetString(0);
                description=reader.GetString(1);
                colour=reader.GetString(2);
                price=double.Parse(reader.GetString(3),System.Globalization.CultureInfo.InvariantCulture);
                products.Add(new Product(name,description,colour,price));
            }
            

            return products;
        }
        public static void deleteProduct(this SqliteConnection conn, Product product) {
            SqliteCommand command;
            command = conn.CreateCommand();
            command.CommandText = $"DELETE FROM SampleTable WHERE (Name='{product.name}' AND Description='{product.description}' AND Colour='{product.colour}' AND Price={product.price})";
            command.ExecuteNonQuery();
        }
        public static void deleteTable(this SqliteConnection conn,string tableName) { 
            SqliteCommand command;
            command = conn.CreateCommand();
            command.CommandText = $"DROP Table '{tableName}'";
            command.ExecuteNonQuery();
        }
    }
}
