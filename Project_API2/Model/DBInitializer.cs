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
                    Currency = "EUR",
                    Alpha3Code = "BEL"
                };
                var l2 = new Land()
                {
                    Name = "The Netherlands",
                    Currency = "EUR",
                    Alpha3Code = "NLD"
                };
                var l3 = new Land()
                {
                    Name = "France",
                    Currency = "EUR",
                    Alpha3Code = "FRA"
                };
                var l4 = new Land()
                {
                    Name = "Australia",
                    Currency = "AUD",
                    Alpha3Code = "AUS"
                };
                //var u3 = new Users()
                //{
                //    firstName = "testFirstName2",
                //    lastName = "testLastName2",
                //    liked = { l4 }
                //};
                context.Land.Add(l1);
                context.Land.Add(l2);
                context.Land.Add(l3);
                context.Land.Add(l4);
                //context.Users.Add(u3);
                context.SaveChanges();
            }
            if (!context.Users.Any())
            {
                var u1 = new Users()
                {
                    firstName = "Quinten",
                    lastName = "Schutyser"
                };
                var u2 = new Users()
                {
                    firstName = "testFirstName",
                    lastName = "testLastName"
                };
                context.Users.Add(u1);
                context.Users.Add(u2);
                context.SaveChanges();
            }
        }
    }
}
