using System;

namespace P1
{
    /**
     * This class should have the following properties
     *      Name (String)
     *      Description (String)
     *      Colour (String)
     *      Price (Decimal)
     */
    class Product
    {
        private string Name,Description,Colour;
        private double Price;
        public Product(string name, string description, string colour, double price)
        {
            Name=name;
            Description=description;
            Colour=colour;
            Price=price;
            // To be modified
        }
        public string name{
            get{return Name;}
            set{Name=value;}
        }
        public string description{
            get{return Description;}
            set{Description=value;}
        }
        public string colour{
            get{return Colour;}
            set{Colour=value;}
        }
        public double price{
            get{return Price;}
            set{Price=value;}
        }
        public override string ToString()
        {
            // To be modified
            // You can choose to print in json string or any other human readable format
            return $"Name:{Name} Description:{Description} Colour:{Colour} Price:{Price}";
        }
    }
}
