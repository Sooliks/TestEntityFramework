using System;
using System.Linq;
using TestEntityFramework.DataBase;
using TestEntityFramework.DataBase.Models;
using AppContext = TestEntityFramework.DataBase.AppContext;

namespace TestEntityFramework
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            using (AppContext db = new AppContext())
            {
                var user = new Accounts("And");
                db.Accounts.Add(user);
                db.SaveChanges();
                Console.WriteLine("Объекты успешно сохранены");
                
                var users = db.Accounts.ToList();
                Console.WriteLine("Список объектов:");
                foreach (Accounts u in users)
                {
                    Console.WriteLine($"{u.Id}.{u.Name}");
                }
            }
        }
    }
}