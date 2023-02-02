using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Final_Fantasy
{
    internal class Combat
    {
        private static Entity[] _playerEntities;
        private static Entity[] _opponentEntities;
        public bool _isInCombat;

        public static Entity[] PlayerEntities { get { return _playerEntities; } set { _playerEntities = value; } }
        public static Entity[] OpponentEntities { get { return _opponentEntities; } set { _opponentEntities = value; } }
        public bool IsInCombat { get { return _isInCombat; } set { _isInCombat = value; } }


        public Combat(Team Player, Team Ennemy)
        {
            IsInCombat = true;
            PlayerEntities = Player.TeamContent;
            OpponentEntities = Ennemy.TeamContent;
        }

        public void ExecuteTurn(Skill playerMove, Skill opponentMove)
        {
            // ===== Combat Turn =====

            bool playerPlaysFirst;

            playerPlaysFirst = CheckPriority();

            // ===== Stats Clash =====

            if (playerPlaysFirst)
            {
                // ----- Player Turn -----

                for(int i = 0; i < PlayerEntities.Length; i++)
                {
                    DamageCalc(PlayerEntities[i], OpponentEntities[i], playerMove);
                    KillResult(PlayerEntities[i], OpponentEntities[i]);
                }

                // ----- Ai Turn -----

                for (int i = 0; i < OpponentEntities.Length; i++)
                {
                    DamageCalc(OpponentEntities[i], PlayerEntities[i], playerMove);
                    KillResult(OpponentEntities[i], PlayerEntities[i]);
                }
            }

            else if (!playerPlaysFirst)
            {

                // ----- Ai Turn -----

                for (int i = 0; i < OpponentEntities.Length; i++)
                {
                    //PlayerEntities[i] member should take random player selection && playerMove should also take skill selection return value
                    DamageCalc(OpponentEntities[i], PlayerEntities[i], playerMove);
                    KillResult(OpponentEntities[i], PlayerEntities[i]);
                }

                // ----- Player Turn -----

                for (int i = 0; i < PlayerEntities.Length; i++)
                {
                    //OpponentEntities[i] member should take ennemy selection function return value && playerMove should also take skill selection return value
                    DamageCalc(PlayerEntities[i], OpponentEntities[i], playerMove);
                    KillResult(PlayerEntities[i], OpponentEntities[i]);
                }
            }
            return;
        }

        public bool CheckPriority()
        {
            // ===== Turn Play Order ====

            int PlayerTeamSpeed = 0;
            int OpponentTeamSpeed = 0;

            foreach (Entity entity in PlayerEntities)
            {
                if (entity == null)
                {
                    break;
                }
                PlayerTeamSpeed += entity.SPD;
            }
            foreach (Entity entity in OpponentEntities)
            {
                if (entity == null)
                {
                    break;
                }
                OpponentTeamSpeed += entity.SPD;
            }

            //Speed comparison
            if (PlayerTeamSpeed > OpponentTeamSpeed)
            {
                return true;
            }
            //Manage comparison when both speed are equal (random 50/50)
            else if (PlayerTeamSpeed == OpponentTeamSpeed)
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

        public void StatusMoveCalc(Entity targetEntity, Entity attackingEntity, string attackName)
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

        public void DamageCalc(Entity attackingEntity, Entity targetEntity, Skill attack)
        {
            if(attackingEntity == null || targetEntity == null || attackingEntity.CurrentHP <= 0)
            {
                return;
            }

            bool isCritical = false;
            float CriticalMultiplier;
            int R = 0;
            float STAB = 1;
            float TypeMatchup = 1;

            CriticalMultiplier = 1;

            isCritical = CheckCritical(attack);
            if (isCritical)
            {
                CriticalMultiplier = 1.5f;
            }

            //rand = random value comprised between 217 and 255 included | R = (rand x 100) / 255
            Random rnd = new Random();
            R = ((rnd.Next(0, 101) % ((255 - 217) + 1) + 217) * 100) / 255;

            //check STAB and Type weaknesses
            STAB = CheckStab(attackingEntity.Type, attack.Type);
            TypeMatchup = CheckTypeMatchup(attack.Type, targetEntity.Type);

            //================ PHYSICAL ATTACK ===================

            if (attack.Category == "Physical")
            {
                Console.WriteLine(
                    attackingEntity.Name 
                    + " did : " + ((int)(((((

                    (attackingEntity.Level * 2 / 5) + 2) 

                    * attack.Power * attackingEntity.ATK / 2) 

                    / targetEntity.DEF)) + 2) * R / 100) 

                    * STAB * TypeMatchup * CriticalMultiplier 

                    + " damage !");


                targetEntity.CurrentHP = 
                    (int)(targetEntity.CurrentHP 

                    - (((((((attackingEntity.Level * 2 / 5) + 2)

                    * attack.Power * attackingEntity.ATK / 2) 

                    / targetEntity.DEF)) + 2) * R / 100) 

                    * STAB * TypeMatchup * CriticalMultiplier);
            }

            //================ MAGICAL ATTACK ===================

            else if (attack.Category == "Magical")
            {
                Console.WriteLine(
                    attackingEntity.Name + " did : " + ((int)(((((

                    (attackingEntity.Level * 2 / 5) + 2)

                    * attack.Power * attackingEntity.MATK / 2)

                    / targetEntity.MDEF)) + 2) * R / 100)

                    * STAB * TypeMatchup * CriticalMultiplier

                    + " damage !");

                targetEntity.CurrentHP =
                    (int)(targetEntity.CurrentHP

                    - (((((((attackingEntity.Level * 2 / 5) + 2)

                    * attack.Power * attackingEntity.MATK / 2)

                    / targetEntity.MDEF)) + 2) * R / 100)

                    * STAB * TypeMatchup * CriticalMultiplier);
            }

            //================ SPECIAL ATTACK ===================

            else if (attack.Category == "Status")
            {
                StatusMoveCalc(targetEntity, attackingEntity, attack.Name);
            }
        }

        public void KillResult(Entity attackingEntity, Entity targetEntity)
        {
            if (attackingEntity == null || targetEntity == null)
            {
                return;
            }

            if (targetEntity.CurrentHP <= 0)
            {
                Console.WriteLine("Ennemy " + targetEntity.Name + " has fainted, " + targetEntity.ExpYield + " exp obtained ! \n");
                attackingEntity.setExp(targetEntity.ExpYield);
                return;
            }

            else if (attackingEntity.CurrentHP <= 0)
            {
                Console.WriteLine(attackingEntity.Name + " fainted ! ");
                //add party check to determine if fight is lost
                return;
            }
        }
    }
}