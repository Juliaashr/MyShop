using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop
{
    class ProductSorter
    {
        static public void Sort<T>(IProduct<T>[] products, Func<IProduct<T>, IProduct<T>, bool> comparison)
        {
            bool swapped = true;
            IProduct<T> temp;
            do
            {
                swapped = false;
                for (int i = 0; i < products.Length - 1; i++)
                {
                    if (comparison(products[i + 1], products[i]))
                    {
                        temp = products[i];
                        products[i] = products[i + 1];
                        products[i + 1] = temp;
                        swapped = true;
                    }
                }
            } while (swapped);
        }
    }
}
