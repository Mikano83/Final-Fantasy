using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Fantasy
{
    internal class Quest
    {
        private int _questid;
        private string _questname;
        private string _questtype;
        private string _questtatus;
        private string _questdescription;
        private int _gilreward;
        private int _xpreward;
        private Item? _itemreward;

        public Quest(int id, string name, string type, string status, string description, int gil, int xp, Item item)
        {
            this._questid = id;
            this._questname = name;
            this._questtype = type;
            this._questtatus = status;
            this._questdescription = description;
            this._gilreward = gil;
            this._xpreward = xp;
            this._itemreward = item;
        }
    }
}
