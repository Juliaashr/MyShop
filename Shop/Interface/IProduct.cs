using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop
{
    public interface IProduct<T>
    {
        T Category { get; set; }
    }
}
