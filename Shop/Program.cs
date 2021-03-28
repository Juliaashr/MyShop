using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop
{
    public delegate void CustomerEventHandler<R>(R name);
    class Program
    {
        private static void Customer_Handler<R>(R name)
        {
            Console.WriteLine($"Добро пожаловать в наш магазин, {name}!");
        }

            static void Main(string[] args)
        {
            Product<string>[] offeredProducts = {new Product<string>("продукты"), new Product<string>("товары для детей"),
                                                 new Product<string>("бытовые товары"), new Product<string>("товары для авто"),
                                                 new Product<string>("зоотовары"), new Product<string>("косметика"),
                                                 new Product<string>("лекарства"), new Product<string>("одежда и обувь")
            };

            Console.WriteLine("список предлагаемых товаров:");

            for (int i = 0; i < offeredProducts.Length; i++)
                Console.WriteLine($"{i+1}. {offeredProducts[i]}") ;

 
            IDictionary<Guid, Customer<string, string>> customers = new Dictionary<Guid, Customer<string, string>>(10);

            for (int j = 0; j < 10; j++)
            {
                Console.ForegroundColor = ConsoleColor.Red;

                Console.WriteLine("Введите имя:");
                string name = Console.ReadLine();

                if (name == "")
                    break;

                Console.WriteLine($"Введите количесво желаемых товаров для покупателя {name}:");

                try
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    var c = new Customer<string, string>(name, new Carts<string>(int.Parse(Console.ReadLine()), offeredProducts));

                    c.WelcomeCustomer += Customer_Handler<string>;
                    c.Welcome();

                    customers[c.Code] = c;
                }
                catch(FormatException e)
                {
                    Console.WriteLine(e.Message);
                }  
            }

            Help.Service(customers);

            Console.ReadKey();
        }
    }
}
