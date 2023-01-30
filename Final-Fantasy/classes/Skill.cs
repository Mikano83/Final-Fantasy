using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Fantasy
{
    public class Skill
    {
        public Skill()
        {

        }

        public Skill(string identifier)
        {
            //Prepare json file from game data

            string json = File.ReadAllText(@"../../../../Final-Fantasy/json_data/skill.json");

            JObject data = JObject.Parse(json);

            //Search json file for correspondance using the name of the skill

            for (int i = 0; i <= data.Count; i++)
            {
                if (identifier == (string)data["Skill"][i][""]["name"])
                {
                    _name = (string)data["Skill"][i][""]["name"];
                    _type = (string)data["Skill"][i][""]["type"];
                    _category = (string)data["Skill"][i][""]["category"];
                    _element = (string)data["Skill"][i][""]["element"];
                    _power = (int)data["Skill"][i][""]["power"];
                    _contact = (bool)data["Skill"][i][""]["contact"];
                    _mpcost = (int)data["Skill"][i][""]["mpcost"];
                }
            }
        }

        private string _name;
        private string _type;
        private string _category;
        private string _element;
        private int _power;    
        private bool _contact;
        private int _mpcost;

        public string Name { get { return _name; } }
        public string Type { get { return _type; } }
        public string Category { get { return _category; } }
        public string Element { get { return _element; } }
        public int Power { get { return _power; } }
        public bool Contact { get { return _contact; } }
        public int MPCost { get { return _mpcost; } }
    }
}
