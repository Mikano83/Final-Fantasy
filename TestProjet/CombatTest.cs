using Final_Fantasy;

namespace TestProjet
{
    public class CombatTest
    {
        public Combat CreateTestCombat()
        {
            Creature Ally1 = new Creature("Taotie");
            Ally1.Name = "Ally1";
            Creature Ally2 = new Creature("Taotie");
            Ally2.Name = "Ally2";
            Creature Ally3 = new Creature("Taotie");
            Ally3.Name = "Ally3";
            Creature Ennemy1 = new Creature("Taotie");
            Ennemy1.Name = "Ennemy1";
            Creature Ennemy2 = new Creature("Taotie");
            Ennemy2.Name = "Ennemy2";
            Creature Ennemy3 = new Creature("Taotie");
            Ennemy3.Name = "Ennemy3";

            Team PlayerTeam = new Team();
            Team EnnemyTeam = new Team();

            PlayerTeam.TeamContent[0] = Ally1;
            PlayerTeam.TeamContent[1] = Ally2;
            PlayerTeam.TeamContent[2] = Ally3;
            EnnemyTeam.TeamContent[0] = Ennemy1;
            EnnemyTeam.TeamContent[1] = Ennemy2;
            EnnemyTeam.TeamContent[2] = Ennemy3;

            Combat wildCombat = new(PlayerTeam, EnnemyTeam);
            return wildCombat;
        }

        public Skill CreateTestSkill(string skillName)
        {
            Skill skill = new Skill(skillName);
            return skill;
        }

        //[Test]
        //public void Critical()
        //{
        //    Skill TestSkill = CreateTestSkill("Attack");
        //    bool result = Combat.CheckCritical(TestSkill);
        //    Assert.That(result, Is.EqualTo());
        //}

        [Test]
        [TestCase(999, 0, true)]
        [TestCase(0, 999, false)]

        public void Priority(int a, int b, bool expected)
        {
            Combat wildCombat = CreateTestCombat();

            wildCombat.PlayerEntities[0].SPD = a;
            wildCombat.PlayerEntities[1].SPD = a;
            wildCombat.PlayerEntities[1].SPD = a;

            wildCombat.OpponentEntities[0].SPD = b;
            wildCombat.OpponentEntities[1].SPD = b;
            wildCombat.OpponentEntities[2].SPD = b;

            bool result = wildCombat.CheckPriority();

            Assert.That(result, Is.EqualTo(expected));
        }


        [Test]
        [TestCase("Fire", "Human", 2.0f)]
        [TestCase("Ice", "Beast", 2.0f)]
        [TestCase("Lightning", "Mechanical", 2.0f)]
        [TestCase("Wind", "Flying", 2.0f)]

        [TestCase("Earth", "Flying", 0.0f)]

        [TestCase("Ice", "Human", 1.0f)]
        [TestCase("Fire", "Beast", 1.0f)]

        public void TypeMatchup(string a, string b, float expected)
        {
            float result = Combat.CheckTypeMatchup(a, b);

            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        [TestCase("Fire", "Fire", 1.5f)]
        [TestCase("Human", "Fire", 1.0f)]
        [TestCase("???", "???", 1.5f)]

        public void Stab(string a, string b, float expected)
        {
            float result = Combat.CheckStab(a, b);

            Assert.That(result, Is.EqualTo(expected));
        }
    }
}