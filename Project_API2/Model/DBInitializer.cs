using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_API2.Model
{
    public class DBInitializer : DbContext
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
                context.Land.Add(l1);
                context.SaveChanges();
            }
        }
    }
}
