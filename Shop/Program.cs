using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop
{
    class Program
    {
        static void Main(string[] args)
        {
            Product<string>[] offeredProducts = {new Product<string>("продукты"), new Product<string>("товары для детей"),
                                                 new Product<string>("бытовые товары"), new Product<string>("товары для авто"),
                                                 new Product<string>("зоотовары"), new Product<string>("косметика"),
                                                 new Product<string>("лекарства"), new Product<string>("одежда и обувь")};

            Console.WriteLine("список предлагаемых товаров:");

            for (int i = 0; i < offeredProducts.Length; i++)
                Console.WriteLine(offeredProducts[i]);

            IDictionary<Guid, Customer<string, string>> customers = new Dictionary<Guid, Customer<string, string>>(10);

            var c1 = new Customer<string, string>("Антон", new Carts<string>(3, offeredProducts));
            var c2 = new Customer<string, string>("Кирилл", new Carts<string>(4, offeredProducts));
            var c3 = new Customer<string, string>("Анна", new Carts<string>(3, offeredProducts));
            var c4 = new Customer<string, string>("Юлия", new Carts<string>(5, offeredProducts));
            var c5 = new Customer<string, string>("Павел", new Carts<string>(1, offeredProducts));
            var c6 = new Customer<string, string>("Алина", new Carts<string>(3, offeredProducts));
            var c7 = new Customer<string, string>("Константин", new Carts<string>(4, offeredProducts));
            var c8 = new Customer<string, string>("Дарья", new Carts<string>(5, offeredProducts));
            var c9 = new Customer<string, string>("Светлана", new Carts<string>(3, offeredProducts));
            var c10 = new Customer<string, string>("Валентин", new Carts<string>(2, offeredProducts));


            customers[c1.Code] = c1;
            customers[c2.Code] = c2;
            customers[c3.Code] = c3;
            customers[c4.Code] = c4;
            customers[c5.Code] = c5;
            customers[c6.Code] = c6;
            customers[c7.Code] = c7;
            customers[c8.Code] = c8;
            customers[c9.Code] = c9;
            customers[c10.Code] = c10;


            Help.Service(customers);




            Console.ReadKey();
        }
    }
}
