using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Fantasy
{
    internal class Entity
    {
        public static void SyncLevelStat(Entity entity)
        {
            //make sure Current HP updates to full health if creature was already on full health when leveling
            if (entity.CurrentHP == entity.MaxHP)
            {
                entity.MaxHP += (entity.MaxHP * 2 * entity.Level) / 100 + 10 + entity.Level;
                entity.CurrentHP = entity.MaxHP;
            }

            entity.ATK += ((entity.ATK * 2 * entity.Level) / 100 + 5);

            entity.DEF += ((entity.DEF * 2 * entity.Level) / 100 + 5);

            entity.MATK += ((entity.MATK * 2 * entity.Level) / 100 + 5);

            entity.MDEF += ((entity.MDEF * 2 * entity.Level) / 100 + 5);

            entity.SPD += ((entity.SPD * 2 * entity.Level) / 100 + 5);

            entity.LUCK += ((entity.LUCK * 2 * entity.Level) / 100 + 5);
        }

        public static int CalcExp(string selectValue, Entity entity)
        {
            int expResult;

            if (selectValue == "exp")
            {
                expResult = (int)(6.0f / 5.0f * Math.Pow(entity.Level,3) - 15 * Math.Pow(entity.Level, 2) + 100 * entity.Level - 140);

                entity.Exp = expResult;
                Console.WriteLine("Sync Exp Result : " + expResult);
                return expResult;
            }
            else if (selectValue == "nextLevelExp")
            {
                expResult = (int)(6.0f / 5.0f * Math.Pow(entity.Level + 1, 3) - 15 * Math.Pow(entity.Level + 1, 2) + 100 * (entity.Level + 1) - 140);
                Console.WriteLine("Sync nextLevelExp Result : " + expResult);
                return expResult;
            }
            throw new ArgumentException();
        }

        public static float ProcessMultiplier(int StageMod, string StageType)
        {
            float processedStageMod = 1.0f;

            if (StageType == "Base")
            {

                if (StageMod == -6)
                {
                    processedStageMod = 2 / 8;
                }

                else if (StageMod == -5)
                {
                    processedStageMod = 2 / 7;
                }

                else if (StageMod == -4)
                {
                    processedStageMod = 2 / 6;
                }

                else if (StageMod == -3)
                {
                    processedStageMod = 2 / 5;
                }

                else if (StageMod == -2)
                {
                    processedStageMod = 2 / 4;
                }

                else if (StageMod == -1)
                {
                    processedStageMod = 2 / 3;
                }

                else if (StageMod == 0)
                {
                    processedStageMod = 1;
                }

                else if (StageMod == 1)
                {
                    processedStageMod = 3 / 2;
                }

                else if (StageMod == 2)
                {
                    processedStageMod = 4 / 2;
                }

                else if (StageMod == 3)
                {
                    processedStageMod = 5 / 2;
                }

                else if (StageMod == 4)
                {
                    processedStageMod = 6 / 2;
                }

                else if (StageMod == 5)
                {
                    processedStageMod = 7 / 2;
                }

                else if (StageMod == 6)
                {
                    processedStageMod = 8 / 2;
                }

                else
                {
                    Console.WriteLine("Stage Multiplier Processing failed : invalid value " + StageMod);
                    return processedStageMod;
                }
            }

            else if (StageType == "Combat")
            {

                if (StageMod == -6)
                {
                    processedStageMod = 3 / 9;
                }

                else if (StageMod == -5)
                {
                    processedStageMod = 3 / 8;
                }

                else if (StageMod == -4)
                {
                    processedStageMod = 3 / 7;
                }

                else if (StageMod == -3)
                {
                    processedStageMod = 3 / 6;
                }

                else if (StageMod == -2)
                {
                    processedStageMod = 3 / 5;
                }

                else if (StageMod == -1)
                {
                    processedStageMod = 3 / 4;
                }

                else if (StageMod == 0)
                {
                    processedStageMod = 1;
                }

                else if (StageMod == 1)
                {
                    processedStageMod = 4 / 3;
                }

                else if (StageMod == 2)
                {
                    processedStageMod = 5 / 3;
                }

                else if (StageMod == 3)
                {
                    processedStageMod = 6 / 3;
                }

                else if (StageMod == 4)
                {
                    processedStageMod = 7 / 3;
                }

                else if (StageMod == 5)
                {
                    processedStageMod = 8 / 3;
                }

                else if (StageMod == 6)
                {
                   processedStageMod = 9 / 3;
                }

                else
                {
                    Console.WriteLine("Stage Multiplier Processing failed : invalid value " + StageMod);
                    return processedStageMod;
                }
            }

            return processedStageMod;
        }


        //general informations 

        protected string _name;
        protected int _level;
        protected string _type;
        protected int? _exp;
        protected int? _expyield;

        public string Name { get { return _name; } set { _name = value; } }
        public int Level { get { return _level; } set { _level = value; } }
        public string Type { get { return _type; } }
        public int? Exp { get { return _exp; } set { _exp = value; } }
        public int? ExpYield { get { return _expyield; } }

        //skills informations
        protected List<Skill> _movepool = new List<Skill>();
        public List<Skill> Movepool { get { return _movepool; } }

        //stats informations
        protected int _currenthp;
        protected int _currentmp;

        protected int _maxhp;
        protected int _maxmp;

        protected int _attack;
        protected int _defense;
        protected int _magicatk;
        protected int _magicdef;
        protected int _speed;
        protected int _luck;

        //Stat Stages for buffs & debuffs
        protected int _atkStage;
        protected int _defStage;
        protected int _magicatkStage;
        protected int _magicdefStage;
        protected int _spdStage;
        protected int _luckStage;

        public int CurrentHP { get { return _currenthp; } set { _currenthp = value; } }
        public int CurrentMP { get { return _currentmp; } set { _currentmp = value; } }

        public int MaxHP { get { return _maxhp; } set { _maxhp = value; } }
        public int MaxMP { get { return _maxmp; } set { _maxmp = value; } }

        public int ATK { get { return _attack; } set { _attack = value; } }
        public int DEF { get { return _defense; } set { _defense = value; } }
        public int MATK { get { return _magicatk; } set { _magicatk = value; } }
        public int MDEF { get { return _magicdef; } set { _magicdef = value; } }
        public int SPD { get { return _speed; } set { _speed = value; } }
        public int LUCK { get { return _luck; } set { _luck = value; } }


        public int ATKStage { get { return _atkStage; } set { _atkStage = value; } }
        public int DEFStage { get { return _defStage; } set { _defStage = value; } }
        public int MATKStage { get { return _magicatkStage; } set { _magicatkStage = value; } }
        public int MDEFStage { get { return _magicdefStage; } set { _magicdefStage = value; } }
        public int SPDStage { get { return _spdStage; } set { _spdStage = value; } }
        public int LUCKStage { get { return _luckStage; } set { _luckStage = value; } }
    }
}
