using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Fantasy
{ 
    internal class Inventory : Menu
    {
        public List<Item> _items;
        public int _gilamount;

        public Inventory()
        {
            _items = new List<Item>();
            _gilamount = 0;
        }

        public List<Item> Items { get { return _items; } }
        public int GilAmount { get { return _gilamount; } }

        public void AddGil(int value)
        {
            this._gilamount += value;
        }
        public void RemoveGil(int value) 
        { 
            this._gilamount -= value;
        }

        public void AddItem(Item item)
        {
            _items.Add(item);
        }
    }
}
