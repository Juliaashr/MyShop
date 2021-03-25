using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop
{
    class Help
    {
        public static void Service(IDictionary<Guid, Customer<string, string>> customers)
        {
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Red;

                Console.WriteLine("Введите 1, чтобы добавить покупателя; введите 2, чтобы просмотреть список покупателей; введите 3, чтобы начать поиск; 4 - чтобы выйти:");

                string helpVal = Console.ReadLine();

                if (helpVal == "1")
                {
                    Console.WriteLine("Введите имя покупателя и коичество желаемых товаров:");

                    Console.ForegroundColor = ConsoleColor.Green;

                    var newC = new Customer<string, string>(Console.ReadLine(), new Carts<string>(int.Parse(Console.ReadLine())));
                    customers.Add(newC.Code, newC);
                }

                if (helpVal == "2")
                    foreach (KeyValuePair<Guid, Customer<string, string>> item in customers)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;

                        Console.WriteLine($"{item.Key} : {item.Value} - корзина:");
                        item.Value.ShowCart();
                    }

                if (helpVal == "3")
                {

                    Console.WriteLine("Введите уникальный код для поиска покупателя: ");

                    Console.ForegroundColor = ConsoleColor.Green;

                    Find.TryGetCartOrder(customers, Guid.Parse(Console.ReadLine()));
                }

                if (helpVal == "4")
                    break;
            }
        }
    }
}
