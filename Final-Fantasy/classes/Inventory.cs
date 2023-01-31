using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Fantasy
{ 
    internal class Inventory : Menu
    {
        private List<Item> _items;

        public Inventory()
        {
            _items = new List<Item>();
        }

        public List<Item> Items { get { return _items; } }
    }
}
