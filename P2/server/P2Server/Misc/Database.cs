using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using P2Server.Misc;
using P2Server.Model;

namespace P2Server.Misc
{
    public interface IDatabase
    {
        public List<Product> Get();
    }

    public class Database : IDatabase
    {
        // Change this according to previous task
        // Make sure you use services.AddSingleton<Database>(); in startup.cs
        // Singleton class / purely static class = not the best practise
        public List<Product> Get()
        {
            return new List<Product>() { new Product(), new Product(), new Product() };
        }
    }
}
