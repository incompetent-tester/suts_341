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
        
            dbConn.deleteTable("SampleTable"); //commend this line if run for the first time
            dbConn.CreateTable();  
            List<Product> products = new List<Product>();
            products.Add(new Product("Name1","Desc1","Colour1",12.34));
            products.Add(new Product("Name2","Desc2","Colour2",12.34));
            products.Add(new Product("Name3","Desc3","Colour3",12.34));
            products.Add(new Product("Name4","Desc4","Colour4",12.34));
            dbConn.InsertProducts(products);

            IEnumerable<Product> readProducts = dbConn.ReadProducts();
            foreach(var p in readProducts)
            {
                Console.WriteLine(p.ToString());
            }
            bool done=false;
            while(!done){
                Console.WriteLine("Enter '1' to add new product");
                Console.WriteLine("Enter '2' to show all product");
                Console.WriteLine("Enter '3' to select a product");
                Console.WriteLine("Enter '4' to delete a product");
                Console.WriteLine("Enter 'q' to add new product");
                var userInput=Console.ReadLine();
                if(userInput=="1"){
                    Console.WriteLine("Adding new product");
                    Console.WriteLine("New product name");
                    var newName=Console.ReadLine();
                    Console.WriteLine("New product description");
                    var newDesc=Console.ReadLine();
                    Console.WriteLine("New product colour");
                    var newColour=Console.ReadLine();
                    Console.WriteLine("New product price");
                    var newPrice=Console.ReadLine();
                    double newPriceParsed=double.Parse(newPrice,System.Globalization.CultureInfo.InvariantCulture);
                    dbConn.addProduct(new Product(newName,newDesc,newColour,newPriceParsed));
                }
                else if(userInput=="2"){
                    Console.WriteLine("Product list");
                    foreach(var p in dbConn.ReadProducts())
                    {
                        Console.WriteLine(p.ToString());
                    }
                }
                else if(userInput=="3"){
                    Console.WriteLine("Selecting a product");
                    Console.WriteLine("Enter product information (name/description/colour/price)");
                    var productInfo=Console.ReadLine();
                    List<Product> searchedList = new List<Product>();
                    foreach(var p in dbConn.ReadProducts())
                    {
                        if(p.name==productInfo || p.description==productInfo ||p.colour==productInfo || p.price.ToString()==productInfo){
                            searchedList.Add(p);
                        }
                    }
                    foreach (var p in searchedList)
                    {
                        Console.WriteLine(p.ToString());
                    }
                }
                else if(userInput=="4"){
                    Console.WriteLine("Deleting a product");
                    Console.WriteLine("Product list");
                    var counter=1;
                    foreach(var p in dbConn.ReadProducts())
                    {
                        Console.WriteLine(counter+" "+p.ToString());
                        counter+=1;
                    }
                    Console.WriteLine("Enter product number that you want to delete");
                    var selectedNumber=Console.ReadLine();
                    int parsedSelectedNumber = 0;
                    Int32.TryParse(selectedNumber, out parsedSelectedNumber);
                    counter=0;
                    foreach(var p in dbConn.ReadProducts())
                    {
                        if(counter==parsedSelectedNumber-1){
                            dbConn.deleteProduct(p);
                            
                        }
                        counter+=1;
                    }

                }
                else if(userInput=="q"){
                    done=true;
                }
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
