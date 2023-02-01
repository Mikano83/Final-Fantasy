using Final_Fantasy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Fantasy
{
    internal class Map
    {
        internal class Game
        {
            public Game(List<Character> maps, List<Sprite> sprites)
            {
            }
        }
    }
}

namespace Final_Fantasy
{
}

namespace Final_Fantasy
{
    internal class Program
    {
        private const int W = 180;
        private const int V = 50;
        private static int windowHeight;
        private static int windowWidth;

        public static int WindowWidth { get; private set; }

        private static void SetWindowWidth(int value)
        {
            windowWidth = value;
        }
        public static int GetWindowWidth() => windowWidth;

        public static int WindowHeight { get; private set; }

        private static void SetWindowHeight(int value)
        {
            windowHeight = value;
        }
        public static int GetWindowHeight() => windowWidth;

        public static int WindowHeight { get; private set; }

        static void Main(string[] args)
        {

            //Set the definition of the window
            int desireWidth = W;
            int desireHeight = V;
            SetWindowWidth(desireWidth);
            SetWindowHeight(desireHeight);
            Console.SetWindowSize(desireWidth, desireHeight);
            Console.SetBufferSize(desireWidth, desireHeight);
            Console.CursorVisible = false;



            //Create the map
            Character map = new Character();

            //Create the player
            Map player = new Map();

            //Create the enemy
            Enemy enemy = new Enemy();

            //Create the sprite
            Sprite sprite = new Sprite();

            //Create the list of sprites
            List<Sprite> sprites = new List<Sprite>();

            //Add the enemy to the list of sprites
            sprites.Add(enemy);

            //Add the player to the list of sprites
            sprites.Add(player);

            //Add the sprite to the list of sprites
            sprites.Add(sprite);

            //Create the list of maps
            List<Character> maps = new List<Character>();

            //Add the map to the list of maps
            maps.Add(map);

            //Create the game
            Game game = new Game(maps, sprites);
        }
    }
}
