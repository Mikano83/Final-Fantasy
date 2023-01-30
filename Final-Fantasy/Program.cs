using System.Reflection;
using System.Text;

namespace Final_Fantasy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var sb = new StringBuilder();
            var assembly = Assembly.GetExecutingAssembly();
            foreach (var type in assembly.GetTypes())
            {
                sb.AppendLine(type.ToString());
            }
            var result = sb.ToString();
            //System.IO.File.WriteAllText(@"C:\temp\output.txt", result);


            Creature Taotie1 = new Creature("Taotie");
            Creature Garru1 = new Creature("Garru");

            Console.WriteLine(Taotie1.Name);
            Console.WriteLine("Level : " + Taotie1.Level);
            Console.WriteLine("Type : " + Taotie1.Type + "\n");

            Console.WriteLine("Current HP : " + Taotie1.CurrentHP);
            Console.WriteLine("Current MP : " + Taotie1.CurrentMP);
            Console.WriteLine("MAX HP : " + Taotie1.MaxHP);
            Console.WriteLine("MAX MP : " + Taotie1.MaxMP + "\n");

            Console.WriteLine("Attack : " + Taotie1.ATK);
            Console.WriteLine("Defense : " + Taotie1.DEF);
            Console.WriteLine("Magical Attack : " + Taotie1.MATK);
            Console.WriteLine("Magical Defense : " + Taotie1.MDEF);
            Console.WriteLine("Speed : " + Taotie1.SPD);
            Console.WriteLine("Luck : " + Taotie1.LUCK + "\n\n");


            Console.WriteLine(Garru1.Name);
            Console.WriteLine("Level : " + Garru1.Level);
            Console.WriteLine("Type : " + Garru1.Type + "\n");

            Console.WriteLine("Current HP : " + Garru1.CurrentHP);
            Console.WriteLine("Current MP : " + Garru1.CurrentMP);
            Console.WriteLine("MAX HP : " + Garru1.MaxHP);
            Console.WriteLine("MAX MP : " + Garru1.MaxMP + "\n");

            Console.WriteLine("Attack : " + Garru1.ATK);
            Console.WriteLine("Defense : " + Garru1.DEF);
            Console.WriteLine("Magical Attack : " + Garru1.MATK);
            Console.WriteLine("Magical Defense : " + Garru1.MDEF);
            Console.WriteLine("Speed : " + Garru1.SPD);
            Console.WriteLine("Luck : " + Garru1.LUCK + "\n\n");

            Team PlayerTeam = new Team();
            Team EnnemyTeam = new Team();

            PlayerTeam.TeamContent[0] = Taotie1;
            EnnemyTeam.TeamContent[0] = Garru1;

            Combat wildCombat = new Combat(PlayerTeam, EnnemyTeam);
            wildCombat.ExecuteTurn(PlayerTeam.TeamContent[0].Movepool[0], EnnemyTeam.TeamContent[0].Movepool[1]);

            Console.WriteLine(Garru1.Name);
            Console.WriteLine("Level : " + Garru1.Level);
            Console.WriteLine("Type : " + Garru1.Type + "\n");

            Console.WriteLine("Current HP : " + Garru1.CurrentHP);
            Console.WriteLine("Current MP : " + Garru1.CurrentMP);
            Console.WriteLine("MAX HP : " + Garru1.MaxHP);
            Console.WriteLine("MAX MP : " + Garru1.MaxMP + "\n");

            Console.WriteLine("Attack : " + Garru1.ATK);
            Console.WriteLine("Defense : " + Garru1.DEF);
            Console.WriteLine("Magical Attack : " + Garru1.MATK);
            Console.WriteLine("Magical Defense : " + Garru1.MDEF);
            Console.WriteLine("Speed : " + Garru1.SPD);
            Console.WriteLine("Luck : " + Garru1.LUCK + "\n\n");
        }
    }
}