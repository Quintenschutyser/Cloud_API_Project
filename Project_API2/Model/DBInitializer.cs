using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_API2.Model
{
    public class DBInitializer
    {
        public static void Initialize(LibraryContext context)
        {
            context.Database.EnsureCreated();
            if (!context.Land.Any())
            {
                var l1 = new Land()
                {
                    Name = "Belgium",
                    Currency = "EUR"
                };
                var l2 = new Land()
                {
                    Name = "The Netherlands",
                    Currency = "EUR"
                };
                context.Land.Add(l1);
                context.Land.Add(l2);
                context.SaveChanges();
            }
        }
    }
}
