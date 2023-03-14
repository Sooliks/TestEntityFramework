using System;
using System.Linq;
using TestEntityFramework.DataBase;
using TestEntityFramework.DataBase;


namespace TestEntityFramework
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Выберите регистрация или авторизация (1,2): ");
            int selection = Convert.ToInt32(Console.ReadLine());
            switch (selection)
            {
                case 1:
                    Console.WriteLine("Введите логин");
                    string login = Console.ReadLine();
                    
                    Console.WriteLine("Введите email");
                    string email = Console.ReadLine();
                    
                    Console.WriteLine("Введите password");
                    string password = Console.ReadLine();
                    
                    Console.WriteLine("Подтвердите password");
                    string secondPassword = Console.ReadLine();
                    if (password != secondPassword)
                    {
                        Console.WriteLine("Пароли не совпадают");
                        break;
                    }
                    
                    Connection.Register(login,email,password);
                    
                    break;
                case 2:
                    Console.WriteLine("Введите логин");
                    string aLogin = Console.ReadLine();
                    
                    Console.WriteLine("Введите password");
                    string aPassword = Console.ReadLine();
                    
                    Connection.Authorization(aLogin,aPassword);
                    
                    break;
                default:
                    Console.WriteLine("Введите корректное значение");
                    break;
            }
        }
    }
}