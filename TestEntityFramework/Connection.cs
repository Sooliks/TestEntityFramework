using System;
using System.Linq;

namespace TestEntityFramework
{
    public class Connection
    {
        public static void Register(string login, string email, string password)
        {
            if (IsEmailExist(email))
            {
                Console.WriteLine("Аккаунт с таким email уже существует!");
                return;
            }

            if (IsLoginExist(login))
            {
                Console.WriteLine("Аккаунт с таким логином уже существует!");
                return;
            }
            using (AppContext db = new AppContext())
            {
                string saltePassword = Bcrypt.BCrypt.HashPassword(password, Bcrypt.BCrypt.GenerateSalt());
                var user = new Accounts(login,email,saltePassword);
                db.Accounts.Add(user);
                db.SaveChanges();
            }
            Console.WriteLine("Вы успешно зарегистрировались!");
        }

        public static void Authorization(string login, string password)
        {
            if (!IsLoginExist(login))
            {
                Console.WriteLine("Аккаунт с таким логином или паролем не существует!1");
                return;
            }
            if (!PasswordCheck(login, password))
            {
                Console.WriteLine("Аккаунт с таким логином или паролем не существует!2");
                return;
            }
            Console.WriteLine("Вы успешно авторизовались!");
        }
        
        public static bool IsLoginExist(string login)
        {
            bool result;
            using (AppContext db = new AppContext())
            {
                result = db.Accounts.Any(x => x.Login == login);
                db.SaveChanges();
            }
            return result;
        }
        public static bool IsEmailExist(string email)
        {
            bool result;
            using (AppContext db = new AppContext())
            {
                result = db.Accounts.Any(x => x.Email == email);
                db.SaveChanges();
            }
            return result;
        }

        public static bool PasswordCheck(string login, string password)
        {
            Accounts activeAccount = new Accounts();
            using (AppContext db = new AppContext())
            {
                var accounts = db.Accounts.ToList();
                foreach (Accounts account in accounts)
                {
                    if (account.Login == login)
                    {
                        activeAccount = account;
                    }
                }
            }
            if (Bcrypt.BCrypt.CheckPassword(password, activeAccount.Password)) return true;
            return false;
        }
        
    }
}