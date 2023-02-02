using Final_Fantasy;

namespace TestProjet
{
    public class EntityTest
    {
        [Test]
        [TestCase(0, 5, 5)]
        [TestCase(50, 5, 60)]
        [TestCase(857, 5, 947)]
        public void SyncStats(int stat, int level, int expected)
        {
            Creature TestCreature = new Creature("Taotie");
            TestCreature.SPD = stat;
            TestCreature.Level = level;

            Entity.SyncLevelStat(TestCreature);

            Assert.That(TestCreature.SPD, Is.EqualTo(expected));
        }

        [Test]
        [TestCase("exp", 5, 135)]
        [TestCase("exp", 18, 3798)]
        [TestCase("nextLevelExp", 4, 135)]
        public void Exp(string expRank, int level, int expected)
        {
            Creature TestCreature = new Creature("Taotie");
            TestCreature.Level = level;

            int result = Entity.CalcExp(expRank, TestCreature);

            Assert.That((int)result, Is.EqualTo(expected));
        }
    }
}
