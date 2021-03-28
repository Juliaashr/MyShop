using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop
{
    class Help
    {
        private static void Customer_Handler<R>(R name)
        {
            Console.WriteLine($"Добро пожаловать в наш магазин, {name}!");
        }

        public static void Service(IDictionary<Guid, Customer<string, string>> customers)
        {
            Console.ForegroundColor = ConsoleColor.Red;

                Console.WriteLine("Введите 1, чтобы добавить покупателя; введите 2, чтобы просмотреть список покупателей; введите 3, чтобы начать поиск; 4 - чтобы выйти:");

                string helpVal = Console.ReadLine();

                switch(helpVal)
                {
                    case "1":
                        Console.WriteLine("Введите имя покупателя и количество желаемых товаров:");

                        Console.ForegroundColor = ConsoleColor.Green;

                        var newC = new Customer<string, string>(Console.ReadLine(), new Carts<string>(int.Parse(Console.ReadLine())));
                        customers.Add(newC.Code, newC);

                        newC.WelcomeCustomer += Customer_Handler<string>;
                        newC.Welcome();

                        Help.Service(customers);

                        break;
                    case "2":
                        foreach (KeyValuePair<Guid, Customer<string, string>> item in customers)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;

                            Console.WriteLine($"{item.Key} : {item.Value} - корзина:");
                            item.Value.ShowCart();
                        }
                        Help.Service(customers);
                        break;
                    case "3":
                        Console.WriteLine("Введите уникальный код для поиска покупателя: ");

                        Console.ForegroundColor = ConsoleColor.Green;

                        Find.TryGetCartOrder(customers, Guid.Parse(Console.ReadLine()));

                        Help.Service(customers);
                        break;
                    case "4":
                        Console.WriteLine("Выполнен выход!");
                        break;

                }
        }
    }
}
