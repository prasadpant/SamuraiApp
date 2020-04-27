using SamuraiApp.Data;
using SamuraiApp.Domain;
using System;
using System.Linq;

namespace SomeUI
{
    class Program
    {
        private static SamuraiContext _context = new SamuraiContext();
        
        static void Main(string[] args)
        {
            //InsertSamurai();
            //InsertMultipleDifferentObjects();
            //SimpleSamuraiQuery();
            MoreQueries();
        }

        private static void InsertSamurai()
        {
            var samurai = new Samurai { Name = "mommy" };

            using (var context = new SamuraiContext())
            {
                context.Samurais.Add(samurai);
                var results = context.SaveChanges();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(string.Format("Application has stored {0}", results));

                Console.ReadKey();
            }
        }

        private static void InsertMultipleDifferentObjects()
        {
            var samurai = new Samurai { Name = "Chanti Boss" };
            var battle = new Battle
                {
                    Name = "Battle of panipat",
                    StartDate = new DateTime(1575, 06, 16),
                    EndDate = new DateTime(1575, 06, 26 )
                };
            using(var samuraiContext = new SamuraiContext())
            {
                samuraiContext.AddRange(samurai, battle);
                samuraiContext.SaveChanges();
            }

            Console.ReadKey();
        }

        private static void SimpleSamuraiQuery()
        {
            using (var context = new SamuraiContext())
            {
                var samurais = context.Samurais.ToList();
                foreach(var samurai in samurais)
                {
                    Console.WriteLine(samurai.Name);
                }
            }
            Console.ReadLine();
        }

        private static void MoreQueries()
        {
            //var samurais = _context.Samurais.Where(s => s.Name == "prasad").ToList();

            //var samurais = _context.Samurais.Where(s => s.Name == "prasad").FirstOrDefault();

            //var samurais = _context.Samurais.FirstOrDefault(s => s.Name == "prasad");

            var samurais = _context.Samurais.Find(2);
        }
    }
}
