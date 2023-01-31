using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Fantasy
{
    internal class Quest : Menu
    {
        private float _questid;
        private string _questname;
        private string _questtype;
        private string _questpriority;
        private string _queststatus;
        private string _questdescription;
        private string[] _queststep;
        private string _questadvance;
        private int _gilreward;
        private int _xpreward;
        private Item? _itemreward;

        public Quest(float id, string name, string type, string priority, string status, string description, string[] step, int gil, int xp, Item item)
        {
            _questid = id;
            _questname = name;
            _questtype = type;
            _questpriority = priority;
            _queststatus = status;
            _questdescription = description;
            _queststep = step;
            _questadvance = _queststep[0];
            _gilreward = gil;
            _xpreward = xp;
            _itemreward = item;
        }

        public float Questid { get { return _questid; } }
        public string Questname { get { return _questname; } }
        public string QuestType { get { return _questtype; } }
        public string QuestStatus { get { return _queststatus; } }
        public string QuestPriority { get { return _questpriority; } }
        public string QuestDescription { get { return _questdescription; } }
        public string[] QuestStep { get { return _queststep;} }
        public int GilReward { get { return _gilreward;} }
        public int XpReward { get { return _xpreward;} }
        public Item? ItemReward { get { return _itemreward;} }

        public void QuestStart()
        {
           if(this._queststatus == "Not discovered")
            {
                this._queststatus = "Accepted";
                Console.WriteLine("You have started a new quest !");
            }
        }

        public void QuestAdvancement()
        {
            int index = Array.IndexOf(this._queststep, this._questadvance);
            switch (index)
            {
                case < 0:
                    throw new ArgumentException();
                default:
                    if (index < (this._queststep.Count() - 1))
                    {
                        this._questadvance = this._queststep[index + 1];
                    }
                    else if (index == (this._queststep.Count() - 1))
                    {
                        this._queststatus = "Finished";
                        Console.WriteLine("You have finished a quest !");
                    }
                    break;
            }

        }
    }

}
