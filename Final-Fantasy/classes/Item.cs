using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Fantasy
{
    internal class Item
    {
        private int _itemid;
        private string _itemname;
        private string _itemcategory;
        private string _itemdescription;
        private Skill _itemeffect;
        private int _itemprice;
        private int _itemvalue;

        public Item(int id, string name, string category, string description, Skill effect, int price, int value)
        {
            _itemid = id;
            _itemname = name;
            _itemcategory = category;
            _itemdescription = description;
            _itemeffect = effect;
            _itemprice = price;
            _itemvalue = value;
        }

        public int Itemid { get { return _itemid;} }
        public string Itemname { get { return _itemname;} }
        public string Category { get { return _itemcategory;} }
        public string ItemDescription { get { return _itemdescription;} }
        public Skill Sitemeffect { get { return _itemeffect; } }
        public int Itemprice { get { return _itemprice;} }
        public int ItemValue { get { return _itemvalue;} }
    }
}
