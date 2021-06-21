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
            return null;
        }

        public static void CreateTable(this SqliteConnection conn) { }

        public static void InsertProducts(this SqliteConnection conn, IEnumerable<Product> products) { }
        
        public static IEnumerable<Product> ReadProducts(this SqliteConnection conn) 
        {
            return new List<Product>();
        }
    }
}
