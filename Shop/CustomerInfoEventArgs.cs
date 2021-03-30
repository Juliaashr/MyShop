using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop
{
    public class CustomerInfoEventArgs<R> : EventArgs
    {
        public CustomerInfoEventArgs(R name) => Name = name;
        public R Name { get; private set; }
    }
}
