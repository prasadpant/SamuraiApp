using Microsoft.EntityFrameworkCore;
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

            //InsertMultipleSamurais();
            //InsertMultipleDifferentObjects();
            //SimpleSamuraiQuery();
            //MoreQueries();
            //UpdateSamurai();

            //RetrieveAndUpdateMultipleSamurais();

            //MultipleDatabaseOperations();

            //DeleteSamurais();
            //DeleteMultipleSamurais();

            //DeleteBySamuraiID();

            //GetSamuraisUsingSQLQuery();

            //This method can be used only in .Net Core 3.1
            //QueryUsingRawSQLWithInterpolation();

            QueryUsingFromSQLStoredProc();




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

        private static void InsertMultipleSamurais()
        {
            _context.Samurais.AddRange(new Samurai { Name = "Disco" },
                    new Samurai { Name = "Ganesh" },
                    new Samurai { Name = "Satish" });

            _context.SaveChanges();
            Console.ReadLine();

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

        private static void UpdateSamurai()
        {
            var samurai = _context.Samurais.FirstOrDefault();
            samurai.Name = samurai.Name + "San";
            _context.SaveChanges();
            Console.ReadLine();
        }

        private static void RetrieveAndUpdateMultipleSamurais()
        {
            var samurais = _context.Samurais.ToList();
            samurais.ForEach(sam => sam.Name += "san");
            _context.SaveChanges();
            Console.ReadLine();
        }

        private static void MultipleDatabaseOperations()
        {
            var samurais = _context.Samurais.FirstOrDefault();
            samurais.Name = "krash";

            _context.Samurais.Add(new Samurai { Name = "bali" });
            _context.SaveChanges();

            Console.ReadLine();

        }

        private static void DeleteSamurais()
        {
            var samurai = _context.Samurais.FirstOrDefault();
            _context.Samurais.Remove(samurai);
            _context.SaveChanges();
            Console.ReadLine();
        }

        private static void DeleteMultipleSamurais()
        {
            var samurais = _context.Samurais.Where(s => s.Name.Contains("san")).ToList();
            _context.Samurais.RemoveRange(samurais);
            _context.SaveChanges();
            Console.ReadLine();
        }

        private static void DeleteBySamuraiID()
        {
            //By Executing/Calling Stored Procedure
            int samuraiID = 7;

            _context.Database.ExecuteSqlCommand("exec DeleteSamuraiByID {0}", samuraiID);

            //_context.Samurais.FromSql(""); -- This is for Select queries.
            Console.ReadLine();
        }

        private static void GetSamuraisUsingSQLQuery()
        {
            //var samurais = _context.Samurais.FromSql("Select * from Samurais").ToList();
            //Samurais Left Join With Quotes and SamuraiBattles ( This will bring Quotes and Samuraibattles in samurai Object)
            var samurais = _context.Samurais.FromSql("Select * from Samurais").Include(s => s.Quotes).Include(s => s.SamuraiBattles);
            foreach (var Sam in samurais)
            {
                Console.WriteLine(Sam.Id + " " + Sam.Name);

                if (Sam.Quotes != null)
                {
                    for (int i = 0; i < Sam.Quotes.Count; i++)
                    {
                        Console.WriteLine(Sam.Quotes[i].Text);
                    }
                }

            }
            Console.ReadLine();
        }

        private static void QueryUsingRawSQLWithInterpolation()
        {
            string name = "Kiya";
            /* FromSQLInterpolated is available only on EFCore 3.1
            var samurais = _context.Samurais
                .FromSqlInerpolated($"Select * from Samurais Where Name = {name}")
                .ToList();
            */
        }

        private static void QueryUsingFromSQLStoredProc()
        {
            var text = "Satish";
            var samurais = _context.Samurais.FromSql("EXEC dbo.GetSamurais {0}", text).ToList();
            Console.ReadLine();

        }
    }
}
