using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Fantasy
{
    internal class Combat
    {
        private static Creature _playerEntity;
        private static Creature _opponentEntity;

        public static Creature PlayerEntity { get { return _playerEntity; } set { _playerEntity = value; } }
        public static Creature OpponentEntity { get { return _opponentEntity; } set { _opponentEntity = value; } }


        public Combat(Team Player, Team Ennemy)
        {
            PlayerEntity = (Creature)Player.TeamContent[0];
            OpponentEntity = (Creature)Ennemy.TeamContent[0];
        }

        public void ExecuteTurn(Skill playerMove, Skill opponentMove)
        {
            // ===== Combat Turn =====

            bool playerPlaysFirst;
            bool isCritical = false;
            float CriticalMultiplier;
            int R = 0;
            float STAB = 1;
            float TypeMatchup = 1;

            playerPlaysFirst = CheckPriority(playerMove, opponentMove);

            // ===== Stats Clash (Mods not included : concerns items, certain moves/talents or specific conditions like weather =====

            if (playerPlaysFirst)
            {

                // ----- Player Turn -----

                CriticalMultiplier = 1;

                isCritical = CheckCritical(playerMove);
                if (isCritical)
                {
                    CriticalMultiplier = 1.5f;
                }

                //rand = random value comprised between 217 and 255 included | R = (rand x 100) / 255
                Random rnd = new Random();
                R = ((rnd.Next(0, 101) % ((255 - 217) + 1) + 217) * 100) / 255;

                //check STAB and Type weaknesses
                STAB = CheckStab(PlayerEntity.Type, playerMove.Type);
                TypeMatchup = CheckTypeMatchup(playerMove.Type, OpponentEntity.Type);

                if (playerMove.Category == "Physical")
                {
                    Console.WriteLine(PlayerEntity.Name + " did : " + ((int)(((((((PlayerEntity.Level * 2 / 5) + 2) * playerMove.Power * PlayerEntity.ATK / 2) / OpponentEntity.DEF) /* x Mod 1 */) + 2) /* Mod2 */ * R / 100) * STAB * TypeMatchup /* x Mod3 */ * CriticalMultiplier) + " damage !");
                    OpponentEntity.CurrentHP = (int)(OpponentEntity.CurrentHP - (((((((PlayerEntity.Level * 2 / 5) + 2) * playerMove.Power * PlayerEntity.ATK / 2) / OpponentEntity.DEF) /* x Mod 1 */) + 2) /* x Mod2 */ * R / 100) * STAB * TypeMatchup /* x Mod3 */ * CriticalMultiplier);
                }
                else if (playerMove.Category == "Magical")
                {
                    Console.WriteLine(PlayerEntity.Name + " did : " + ((int)(((((((PlayerEntity.Level * 2 / 5) + 2) * playerMove.Power * PlayerEntity.MATK / 2) / OpponentEntity.MDEF) /* x Mod 1 */) + 2) /* Mod2 */ * R / 100) * STAB * TypeMatchup /* x Mod3 */ * CriticalMultiplier) + " damage !");
                    OpponentEntity.CurrentHP = (int)(OpponentEntity.CurrentHP - (((((((PlayerEntity.Level * 2 / 5) + 2) * playerMove.Power * PlayerEntity.MATK / 2) / OpponentEntity.MDEF) /* x Mod 1 */) + 2) /* x Mod2 */ * R / 100) * STAB * TypeMatchup /* x Mod3 */ * CriticalMultiplier);
                }

                //Manage Stat reduction moves

                else if (playerMove.Category== "Status")
                {
                    StatusMoveCalc(playerMove.Name, OpponentEntity, PlayerEntity);
                }

                if (OpponentEntity.CurrentHP <= 0)
                {
                    Console.WriteLine("Ennemy " + OpponentEntity.Name + " has fainted, " + OpponentEntity.ExpYield + " exp obtained ! \n");
                    PlayerEntity.setExp(OpponentEntity.ExpYield);
                    return;
                }

                // ----- Ai Turn -----

                CriticalMultiplier = 1;

                isCritical = CheckCritical(playerMove);
                if (isCritical)
                {
                    CriticalMultiplier = 1.5f;
                }

                R = ((rnd.Next(0, 101) % ((255 - 217) + 1) + 217) * 100) / 255;

                //check STAB and Type weaknesses
                STAB = CheckStab(OpponentEntity.Type, opponentMove.Type);
                TypeMatchup = CheckTypeMatchup(opponentMove.Type, PlayerEntity.Type);

                if (opponentMove.Category == "Physical")
                {
                    Console.WriteLine(OpponentEntity.Name + " did : " + ((int)((((((OpponentEntity.Level * 2 / 5) + 2) * opponentMove.Power * OpponentEntity.ATK / 2) / PlayerEntity.DEF) /* x Mod 1 */) + 2) /* Mod2 */ * R / 100) * STAB * TypeMatchup /* x Mod3 */ * CriticalMultiplier + " damage !");
                    PlayerEntity.CurrentHP = (int)(PlayerEntity.CurrentHP - (((((((OpponentEntity.Level * 2 / 5) + 2) * opponentMove.Power * OpponentEntity.ATK / 2) / PlayerEntity.DEF) /* x Mod 1 */) + 2) /* Mod2 */ * R / 100) * STAB * TypeMatchup /* x Mod3 */ * CriticalMultiplier);
                }
                else if (opponentMove.Category == "Magical")
                {
                    Console.WriteLine(OpponentEntity.Name + " did : " + ((int)((((((OpponentEntity.Level * 2 / 5) + 2) * opponentMove.Power * OpponentEntity.MATK / 2) / PlayerEntity.MDEF) /* x Mod 1 */) + 2) /* Mod2 */ * R / 100) * STAB * TypeMatchup /* x Mod3 */ * CriticalMultiplier + " damage !");
                    PlayerEntity.CurrentHP = (int)(PlayerEntity.CurrentHP - (((((((OpponentEntity.Level * 2 / 5) + 2) * opponentMove.Power * OpponentEntity.MATK / 2) / PlayerEntity.MDEF) /* x Mod 1 */) + 2) /* Mod2 */ * R / 100) * STAB * TypeMatchup /* x Mod3 */ * CriticalMultiplier);
                }

                //Manage Stat reduction moves

                else if (opponentMove.Category == "Status")
                {
                    StatusMoveCalc(opponentMove.Name, PlayerEntity, OpponentEntity);
                }

                if (PlayerEntity.CurrentHP <= 0)
                {
                    Console.WriteLine(PlayerEntity.Name + " fainted ! ");
                    //add party check to determine if fight is lost
                    return;
                }
            }

            else if (!playerPlaysFirst)
            {

                // ----- Ai Turn -----

                CriticalMultiplier = 1;

                isCritical = CheckCritical(playerMove);
                if (isCritical)
                {
                    CriticalMultiplier = 1.5f;
                }

                //rand = random value comprised between 217 and 255 included | R = (rand x 100) / 255
                Random rnd = new Random();
                R = ((rnd.Next(0, 101) % ((255 - 217) + 1) + 217) * 100) / 255;

                //check STAB and Type weaknesses
                STAB = CheckStab(OpponentEntity.Type, opponentMove.Type);
                TypeMatchup = CheckTypeMatchup(opponentMove.Type, PlayerEntity.Type);

                if (opponentMove.Category == "Physical")
                {
                    Console.WriteLine(OpponentEntity.Name + " did : " + ((int)((((((OpponentEntity.Level * 2 / 5) + 2) * opponentMove.Power * OpponentEntity.ATK / 2) / PlayerEntity.DEF) /* x Mod 1 */) + 2) /* Mod2 */ * R / 100) * STAB * TypeMatchup /* x Mod3 */ * CriticalMultiplier + " damage !");
                    PlayerEntity.CurrentHP = (int)(PlayerEntity.CurrentHP - (((((((OpponentEntity.Level * 2 / 5) + 2) * opponentMove.Power * OpponentEntity.ATK / 2) / PlayerEntity.DEF) /* x Mod 1 */) + 2) /* Mod2 */ * R / 100) * STAB * TypeMatchup /* x Mod3 */ * CriticalMultiplier);
                }
                else if (opponentMove.Category == "Magical")
                {
                    Console.WriteLine(OpponentEntity.Name + " did : " + ((int)((((((OpponentEntity.Level * 2 / 5) + 2) * opponentMove.Power * OpponentEntity.MATK / 2) / PlayerEntity.MDEF) /* x Mod 1 */) + 2) /* Mod2 */ * R / 100) * STAB * TypeMatchup /* x Mod3 */ * CriticalMultiplier + " damage !");
                    PlayerEntity.CurrentHP = (int)(PlayerEntity.CurrentHP - (((((((OpponentEntity.Level * 2 / 5) + 2) * opponentMove.Power * OpponentEntity.MATK / 2) / PlayerEntity.MDEF) /* x Mod 1 */) + 2) /* Mod2 */ * R / 100) * STAB * TypeMatchup /* x Mod3 */ * CriticalMultiplier);
                }

                //Manage Stat reduction moves

                else if (opponentMove.Category == "Status")
                {
                    StatusMoveCalc(opponentMove.Name, PlayerEntity, OpponentEntity);
                }

                if (PlayerEntity.CurrentHP <= 0)
                {
                    Console.WriteLine(PlayerEntity.Name + " fainted ! ");
                    //add party check to determine if fight is lost
                    return;
                }

                // ----- Player Turn -----

                CriticalMultiplier = 1;

                isCritical = CheckCritical(playerMove);
                if (isCritical)
                {
                    CriticalMultiplier = 1.5f;
                }

                //rand = random value comprised between 217 and 255 included | R = (rand x 100) / 255
                R = ((rnd.Next(0, 101) % ((255 - 217) + 1) + 217) * 100) / 255;

                //check STAB and Type weaknesses
                STAB = CheckStab(PlayerEntity.Type, playerMove.Type);
                TypeMatchup = CheckTypeMatchup(playerMove.Type, OpponentEntity.Type);

                if (playerMove.Category == "Physical")
                {
                    Console.WriteLine(PlayerEntity.Name + " did : " + ((int)((((((PlayerEntity.Level * 2 / 5) + 2) * playerMove.Power * PlayerEntity.ATK / 2) / OpponentEntity.DEF) /* x Mod 1 */) + 2) /* Mod2 */ * R / 100) * STAB * TypeMatchup /* x Mod3 */ * CriticalMultiplier + " damage !");
                    OpponentEntity.CurrentHP = (int)(OpponentEntity.CurrentHP - (((((((PlayerEntity.Level * 2 / 5) + 2) * playerMove.Power * PlayerEntity.ATK / 2) / OpponentEntity.DEF) /* x Mod 1 */) + 2) /* x Mod2 */ * R / 100) * STAB * TypeMatchup /* x Mod3 */ * CriticalMultiplier);
                }
                else if (playerMove.Category == "Magical")
                {
                    Console.WriteLine(PlayerEntity.Name + " did : " + ((int)((((((PlayerEntity.Level * 2 / 5) + 2) * playerMove.Power * PlayerEntity.MATK / 2) / OpponentEntity.MDEF) /* x Mod 1 */) + 2) /* Mod2 */ * R / 100) * STAB * TypeMatchup /* x Mod3 */ * CriticalMultiplier + " damage !");
                    OpponentEntity.CurrentHP = (int)(OpponentEntity.CurrentHP - (((((((PlayerEntity.Level * 2 / 5) + 2) * playerMove.Power * PlayerEntity.MATK / 2) / OpponentEntity.MDEF) /* x Mod 1 */) + 2) /* x Mod2 */ * R / 100) * STAB * TypeMatchup /* x Mod3 */ * CriticalMultiplier);
                }

                //Manage Stat reduction moves

                else if (playerMove.Category == "Status")
                {
                    StatusMoveCalc(playerMove.Name, OpponentEntity, PlayerEntity);
                }

                if (OpponentEntity.CurrentHP <= 0)
                {
                    Console.WriteLine("Ennemy " + OpponentEntity.Name + " has fainted, " + OpponentEntity.ExpYield + " exp obtained ! \n");
                    PlayerEntity.setExp(OpponentEntity.ExpYield);
                    return;
                }
            }
            return;
        }

        public bool CheckPriority(Skill playerMove, Skill opponentMove)
        {
            // ===== Turn Play Order =====

            //priority moves !!!!!!!Not implemented!!!!!!!!!!!
            if (playerMove.Name == "[PRIORITY ATTACK]")
            {
                if (playerMove.Name == opponentMove.Name)
                {

                    Random rnd = new Random();
                    if ((rnd.Next(2) % 2) == 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                return true;
            }

            //Speed comparison
            if (PlayerEntity.SPD > OpponentEntity.SPD)
            {
                return true;
            }
            //Manage comparison when both speed are equal (random 50/50)
            else if (PlayerEntity.SPD == OpponentEntity.SPD)
            {
                Random rnd = new Random();
                if ((rnd.Next(2) % 2) == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public bool CheckCritical(Skill selectMove)
        {
            bool isCritical;

            //check Critical Chance (6% chance)
            Random rnd = new Random();
            if (rnd.Next(0, 101) < 6)
            {
                isCritical = true;
                Console.WriteLine("Critical!");
            }
            else
            {
                isCritical = false;
            }
            return isCritical;
        }

        public float CheckStab(string CreatureType, string AttackType)
        {
            float STAB = 1.0f;

            if (CreatureType == AttackType)
            {
                STAB += 0.5f;
            }

            return STAB;
        }

        public float CheckTypeMatchup(string attackingType, string defendingCreatureType)
        {
            float TypeMultiplier = 1;

            //list type matchup interaction to calculate TypeMultiplier for every possible Type combination (except for double identical type such as Normal/Normal. Which doesn't exists)

            switch (defendingCreatureType)
            {
                case "Human":
                    if (attackingType == "Fire")
                    {
                        TypeMultiplier *= 2.0f;
                    }
                    return TypeMultiplier;

                case "Beast":
                    if (attackingType == "Ice")
                    {
                        TypeMultiplier *= 2.0f;
                    }
                    return TypeMultiplier;

                case "Mechanical":
                    if (attackingType == "Lightning")
                    {
                        TypeMultiplier *= 2.0f;
                    }
                    return TypeMultiplier;

                case "Flying":
                    if (attackingType == "Wind")
                    {
                        TypeMultiplier *= 2.0f;
                    }

                    else if (attackingType == "Earth")
                    {
                        TypeMultiplier = 0.0f;
                    }

                    return TypeMultiplier;

                default:
                    return 1.0f;
            }
        }

        public void StatusMoveCalc(string attackName, Creature targetEntity, Creature attackingEntity)
        {
            //Defense reduction moves
            if (attackName == "Tail Whip")
            {
                if (targetEntity.DEFStage >= -6)
                {
                    targetEntity.DEFStage -= 1;
                }
                else
                {
                    Console.WriteLine("Ennemy Defense can't go any lower !");
                }
            }

            //Atk boost moves
            else if (attackName == "Hone Claws")
            {
                if (targetEntity.ATKStage <= 6)
                {
                    attackingEntity.ATKStage += 1;
                }
                else
                {
                    Console.WriteLine(attackingEntity.Name + "'s Attack can't go any higher !");
                }
            }

            Entity.SyncLevelStat(targetEntity);
            Entity.SyncLevelStat(attackingEntity);
        }
    }
}