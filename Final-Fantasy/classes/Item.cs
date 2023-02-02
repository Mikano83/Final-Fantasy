using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        private int _itempower;
        private int _itemprice;
        private int _itemvalue;

        public Item(string identifier)
        {
            //Prepare json file from game data

            string json = File.ReadAllText(@"../../../../Final-Fantasy/json_data/item.json");

            JObject data = JObject.Parse(json);

            //Search json file for correspondance using the id of the item
            for (int i = 0; i <= data.Count; i++)
            {
                if (identifier == (string)data["Item"][i][""]["id"])
                {
                    _itemid = (int)data["Item"][i][""]["id"];
                    _itemname = (string)data["Item"][i][""]["name"];
                    _itemcategory = (string)data["Item"][i][""]["category"];
                    _itemdescription = (string)data["Item"][i][""]["description"];
                    _itempower = (int?)data["Item"][i][""]["power"];
                    _itemprice = (int)data["Item"][i][""]["price"];
                    _itemvalue = (int)data["Item"][i][""]["value"];

                }
            }
        }

        public int Itemid { get { return _itemid;} }
        public string Itemname { get { return _itemname;} }
        public string ItemCategory { get { return _itemcategory;} }
        public string ItemDescription { get { return _itemdescription;} }
        public int? ItemPower { get { return _itempower; } }
        public int Itemprice { get { return _itemprice;} }
        public int ItemValue { get { return _itemvalue;} }

        public void SkillEffect(Entity playerusing)
        {
            switch (this._itemcategory)
            {
                case "HP Recovery":
                    if (playerusing.CurrentHP != playerusing.MaxHP)
                    {
                        if (playerusing.CurrentHP + this._itempower > playerusing.MaxHP)
                        {
                            playerusing.CurrentHP = playerusing.MaxHP;
                        }
                        else if (playerusing.CurrentHP == playerusing.MaxHP)
                        {
                            Console.WriteLine("This character is already full life");
                        }
                        else
                        {
                            playerusing.CurrentHP += this._itempower;
                        }
                    }
                    break;
                case "MP Recovery":
                    if (playerusing.CurrentMP != playerusing.MaxMP)
                    {
                        if (playerusing.CurrentMP + this._itempower > playerusing.MaxMP)
                        {
                            playerusing.CurrentMP = playerusing.MaxMP;
                        }
                        else
                        {
                            playerusing.CurrentMP += this._itempower;
                        }
                    }
                    break;
                case "Offensive":
                    if (isInCombat == true)
                    {
                        //deals this._itempower (Enemy select here or in combat ?)
                    }
                    else Console.WriteLine("This item cannot be used out of combat");
                    break;
                case "Defensive":
                    if (isInCombat == true)
                    {
                        // increases playerusing stat by this._itempower (need to figure out how to make it last a defined number of combat round beofre reset. Also, need to figure a way to up a specific stat)
                    }
                    else Console.WriteLine("This item cannot be used out of combat");

                    break;
                default:
                    Console.WriteLine("This item cannot be used that way");
                    break;
            }
        }
    }
}
