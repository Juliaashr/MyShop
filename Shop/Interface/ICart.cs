using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop
{
    public interface ICart<T>
    {
        Product<T>[] Cart { get; set; }
    }
}
