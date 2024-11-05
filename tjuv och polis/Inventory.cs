using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tjuv_och_polis
{
    internal class Inventory
    {
        public string Items { get; set; }
        public Inventory(string items)
        {
            Items = items;
        }
        public override string ToString()
        {
            return Items;
        }
    }
}
