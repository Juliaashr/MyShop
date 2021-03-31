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

        public Product(T category) => Category = category;

        public override string ToString() => $"{Category.ToString()}";

        public bool Equals(Product<T> other) => (other == null) ? false : Category.ToString().Equals(other?.Category.ToString());

        public override bool Equals(object obj) => Equals((Product<T>)obj);

        public override int GetHashCode() => Category.GetHashCode();

        public static bool CompareCategory(IProduct<T> first, IProduct<T> second) => (string.Compare(first?.Category.ToString(), second?.Category.ToString()) == -1) ? true : false;

    }
}
