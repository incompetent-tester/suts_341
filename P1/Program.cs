using System;
using System.Collections.Generic;

namespace P1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("This is the program for L1.");

            var dbConn = Database.CreateConnection();
            dbConn.CreateTable();

            /**
             * Section to be modified
             */
            List<Product> products = new List<Product>();
            
            // Add a new products here
            /*
            products.Add(new Product( ... ));
            products.Add(new Product(... ));
            products.Add(new Product(... ));
            products.Add(new Product(... ));
            */
            dbConn.InsertProducts(products);

            IEnumerable<Product> readProducts = dbConn.ReadProducts();

            foreach(var p in readProducts)
            {
                Console.WriteLine(p.ToString());
            }

            /**
             * Add User interaction function here LT4.4
             */
            // while(!done)
            //{
            //  var input = Console...
            //  switch(input)
            //  {
            //  }
            //}
            //
            //
        }
    }
}
