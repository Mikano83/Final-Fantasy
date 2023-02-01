using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Fantasy
{
    internal class Creature : Entity
    {
        public Creature(string identifier)
        {
            //Prepare json file from game data

            string json = File.ReadAllText(@"../../../../Final-Fantasy/json_data/creature.json");

            JObject data = JObject.Parse(json);

            //Search json file for correspondance using the name of the monster

            for (int i = 0; i <= data.Count; i++)
            {
                if (identifier == (string)data["Creature"][i][""]["name"])
                {
                    _name = (string)data["Creature"][i][""]["name"];
                    Random rnd = new Random();
                    _level = rnd.Next( (int)data["Creature"][i][""]["level"][0], (int)data["Creature"][i][""]["level"][1]+1 );
                    _type = (string)data["Creature"][i][""]["type"];

                    _exp = 0;
                    _expyield = rnd.Next((int)data["Creature"][i][""]["expyield"][0], (int)data["Creature"][i][""]["expyield"][1]);

                    for (int j = 0; j < data["Creature"][i][""]["movepool"].Count(); j++)
                    {
                        Skill skill = new Skill((string)data["Creature"][i][""]["movepool"][j]);
                        Movepool.Add(skill);
                    }

                    _maxhp = (int)data["Creature"][i][""]["HP"];
                    _maxmp = (int)data["Creature"][i][""]["MP"];

                    _currenthp = _maxhp;
                    _currentmp = _maxmp;

                    _attack = (int)data["Creature"][i][""]["ATK"];
                    _defense = (int)data["Creature"][i][""]["DEF"];
                    _magicatk = (int)data["Creature"][i][""]["MATK"];
                    _magicdef = (int)data["Creature"][i][""]["MDEF"];
                    _speed = (int)data["Creature"][i][""]["SPD"];
                    _luck = (int)data["Creature"][i][""]["LUCK"];
                }
            }

            _atkStage = 1;
            _defStage = 1;
            _magicatkStage = 1;
            _magicdefStage = 1;
            _spdStage = 1;
            _luckStage = 1;

            SyncLevelStat(this);
        }
    }
}
