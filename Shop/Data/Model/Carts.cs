using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop
{
    delegate void Sort<T> (Product<T>[] products, Func<Product<T>, Product<T>, bool> comparison);
    public class Carts<T> : ICart<T>
    {
        public Product<T>[] Cart { get; set; }

        public Carts(int size, params Product<T>[] offeredProducts)
        {
            Cart = new Product<T>[size];

            CartInitialise(offeredProducts);
        }

        public void CartInitialise(params Product<T>[] offeredProducts)
        {
            Console.WriteLine($"Введите {Cart.Length} номера товаров для покупателя:");

            for (int i = 0; i < Cart.Length; i++)
            {
                try
                {
                    int inPut = int.Parse(Console.ReadLine());

                    int n = 1;

                    foreach (var item in offeredProducts)
                    {
                        Cart[i] = (inPut == n) ? item : Cart[i];
                        n++;
                    }
                }
                catch (FormatException e)
                {
                    Console.WriteLine(e.Message);
                }

            }

            Sort<T> sort = ProductSorter.Sort<T>;
            sort.Invoke(Cart, Product<T>.CompareCategory);
        }

        public void CartInfo()
        {
            foreach (var item in Cart)
            {
                Console.WriteLine(item.ToString());
            }
        }

    }
}
