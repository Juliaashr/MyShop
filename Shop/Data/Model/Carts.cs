using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop
{
    public class Carts<T> : ICart<T>
    {
        public Product<T>[] Cart { get; set; }

        public Carts(int size, params Product<T>[] offeredProducts)
        {
            Cart = new Product<T>[size];

            Console.WriteLine($"Введите {size} номера товаров для покупателя:");

            for (int i = 0; i < size; i++)
            {
                try {
                    int inPut = int.Parse(Console.ReadLine());

                    for (int j = 0; j < offeredProducts.Length; j++)
                    {
                        if (inPut == j+1)
                            Cart[i] = new Product<T>(offeredProducts[j].Category);
                    }
                }
                catch(FormatException e)
                {
                    Console.WriteLine(e.Message);
                }
                
            }

            ProductSorter.Sort<T>(Cart, Product<T>.CompareCategory);

        }

    }
}
