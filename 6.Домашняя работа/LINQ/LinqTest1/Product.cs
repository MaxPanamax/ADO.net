using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqTest1
{
    class Product
    {
        public string Name { set; get; }
        public int Price { set; get; }
        public string Manufacturer { set; get; }
        public int Count { set; get; }
        public override string ToString()
        {
            return String.Format("{0}  {1}  {2}  {3}",this.Name, this.Price,this.Manufacturer,this.Count);
        }
    }
}
