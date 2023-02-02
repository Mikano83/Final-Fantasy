using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
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
        private List<string> _queststep = new List<string>();
        private string _questadvance;
        private int _gilreward;
        private int _expreward;
        private string? _itemfinder;
        private Item _itemreward;

        public Quest(string identifier)
        {
            //Prepare json file from game data

            string json = File.ReadAllText(@"../../../../Final-Fantasy/json_data/quest.json");

            JObject data = JObject.Parse(json);

            //Search json file for correspondance using the id of the quest
            for (int i = 0; i <= data.Count; i++)
            {
                if (identifier == (string)data["Quest"][i][""]["id"])
                {
                    _questid = (int)data["Quest"][i][""]["id"];
                    _questname = (string)data["Quest"][i][""]["name"];
                    _questtype = (string)data["Quest"][i][""]["type"];
                    _questpriority = (string)data["Quest"][i][""]["priority"];
                    _queststatus = (string)data["Quest"][i][""]["status"];
                    _questdescription = (string)data["Quest"][i][""]["description"];

                    for (int j = 0; j < data["Quest"][i][""]["step"].Count(); j++)
                    {
                        string step = new string((string)data["Quest"][i][""]["step"][j]);
                        QuestStep.Add(step);
                    }


                    _gilreward = (int)data["Quest"][i][""]["gil"];
                    _expreward = (int)data["Quest"][i][""]["exp"];
                    _itemfinder = (string)data["Item"][i][""]["finder"];
                    _itemreward = new Item(_itemfinder);
                }
            }
        }

        public float Questid { get { return _questid; } }
        public string Questname { get { return _questname; } }
        public string QuestType { get { return _questtype; } }
        public string QuestStatus { get { return _queststatus; } }
        public string QuestPriority { get { return _questpriority; } }
        public string QuestDescription { get { return _questdescription; } }
        public List<string> QuestStep { get { return _queststep; } }
        public int GilReward { get { return _gilreward;} }
        public int ExpReward { get { return _expreward;} }
        public Item? ItemReward { get { return _itemreward;} }

        public void QuestStart()
        {
           if(this._queststatus == "Not discovered")
            {
                this._queststatus = "Accepted";
                Console.WriteLine("You have started a new quest !");
            }
        }

        public void QuestAdvancement(Inventory inventory, Team team)
        {
            int index = Array.IndexOf(this._queststep, this._questadvance);
            switch (index)
            {
                case < 0:                               // _questadvance cannot be below 0
                    throw new ArgumentException();
                default:
                    if (index < (this._queststep.Count() - 1))      // if _questadvance is not the last step of the quest, progresses to the next step
                    {
                        this._questadvance = this._queststep[index + 1];
                    }
                    else if (index == (this._queststep.Count() - 1))        // if _questadvance was the last step, end the quest and gives out the quest rewards
                    {
                        inventory.AddGil(this._gilreward);
                        /*Team of Creature players adds this._expreward to their experience points*
                         foreach( in team)
                        {
                            team.TeamContent += this.expreward;
                        }

                         */
                        if (this.ItemReward != null)
                        {
                            inventory.AddItem(this._itemreward);
                        }
                        this._queststatus = "Finished";
                        Console.WriteLine("You have finished a quest !");
                    }
                    break;
            }

        }
    }

}
