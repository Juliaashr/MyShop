using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop
{
    public class Product<T> : IProduct<T>, IEquatable<Product<T>>
    {
        public T Category { get; set; }

        public Product(T category)
        {
            Category = category;
        }

        public override string ToString() => $"{Category.ToString()}";

        public bool Equals(Product<T> other)
        {
            if (other == null)
                return false;

            return Category.ToString() == other.Category.ToString();
        }

        public override bool Equals(object obj) => Equals((Product<T>)obj);

        public override int GetHashCode() => Category.GetHashCode();

        public static bool CompareCategory(Product<T> p1, Product<T> p2)
        {
            bool help = false;
            if (string.Compare(p1.Category.ToString(), p2.Category.ToString()) == -1)
                help = true;
            return help;
        }

    }
}
