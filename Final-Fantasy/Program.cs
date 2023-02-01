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

            Console.WriteLine(Ally1.Name);
            Console.WriteLine("Level : " + Ally1.Level);

            Console.WriteLine("Current HP : " + Ally1.CurrentHP);
            Console.WriteLine("Current MP : " + Ally1.CurrentMP + "\n");

            Console.WriteLine(Ally2.Name);
            Console.WriteLine("Level : " + Ally2.Level);

            Console.WriteLine("Current HP : " + Ally2.CurrentHP);
            Console.WriteLine("Current MP : " + Ally2.CurrentMP + "\n");

            Console.WriteLine(Ally3.Name);
            Console.WriteLine("Level : " + Ally3.Level);

            Console.WriteLine("Current HP : " + Ally3.CurrentHP);
            Console.WriteLine("Current MP : " + Ally3.CurrentMP + "\n\n");


            Console.WriteLine(Ennemy1.Name);
            Console.WriteLine("Level : " + Ennemy1.Level);

            Console.WriteLine("Current HP : " + Ennemy1.CurrentHP);
            Console.WriteLine("Current MP : " + Ennemy1.CurrentMP + "\n");

            Console.WriteLine(Ennemy2.Name);
            Console.WriteLine("Level : " + Ennemy2.Level);

            Console.WriteLine("Current HP : " + Ennemy2.CurrentHP);
            Console.WriteLine("Current MP : " + Ennemy2.CurrentMP + "\n");

            Console.WriteLine(Ennemy3.Name);
            Console.WriteLine("Level : " + Ennemy3.Level);

            Console.WriteLine("Current HP : " + Ennemy3.CurrentHP);
            Console.WriteLine("Current MP : " + Ennemy3.CurrentMP + "\n\n");

            Team PlayerTeam = new Team();
            Team EnnemyTeam = new Team();

            PlayerTeam.TeamContent[0] = Ally1;
            PlayerTeam.TeamContent[1] = Ally2;
            PlayerTeam.TeamContent[2] = Ally3;
            EnnemyTeam.TeamContent[0] = Ennemy1;
            EnnemyTeam.TeamContent[1] = Ennemy2;
            EnnemyTeam.TeamContent[2] = Ennemy3;

            Combat wildCombat = new Combat(PlayerTeam, EnnemyTeam);
            wildCombat.ExecuteTurn(PlayerTeam.TeamContent[0].Movepool[0], EnnemyTeam.TeamContent[0].Movepool[0]);

            Console.WriteLine("\n" + Ally1.Name);
            Console.WriteLine("Level : " + Ally1.Level);

            Console.WriteLine("Current HP : " + Ally1.CurrentHP);
            Console.WriteLine("Current MP : " + Ally1.CurrentMP + "\n");

            Console.WriteLine(Ally2.Name);
            Console.WriteLine("Level : " + Ally2.Level);

            Console.WriteLine("Current HP : " + Ally2.CurrentHP);
            Console.WriteLine("Current MP : " + Ally2.CurrentMP + "\n");

            Console.WriteLine(Ally3.Name);
            Console.WriteLine("Level : " + Ally3.Level);

            Console.WriteLine("Current HP : " + Ally3.CurrentHP);
            Console.WriteLine("Current MP : " + Ally3.CurrentMP + "\n\n");


            Console.WriteLine(Ennemy1.Name);
            Console.WriteLine("Level : " + Ennemy1.Level);

            Console.WriteLine("Current HP : " + Ennemy1.CurrentHP);
            Console.WriteLine("Current MP : " + Ennemy1.CurrentMP + "\n");

            Console.WriteLine(Ennemy2.Name);
            Console.WriteLine("Level : " + Ennemy2.Level);

            Console.WriteLine("Current HP : " + Ennemy2.CurrentHP);
            Console.WriteLine("Current MP : " + Ennemy2.CurrentMP + "\n");

            Console.WriteLine(Ennemy3.Name);
            Console.WriteLine("Level : " + Ennemy3.Level);

            Console.WriteLine("Current HP : " + Ennemy3.CurrentHP);
            Console.WriteLine("Current MP : " + Ennemy3.CurrentMP + "\n\n");
        }
    }
}