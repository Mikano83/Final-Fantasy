using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Fantasy
{
    internal class Sprite
    {
        private int x;
        private int y;
        private int width;
        private int height;
        private ConsoleColor color;
        private char symbol;
        private int speed;
        private int[] direction;
        private int[] position;
        private int[] velocity;
        private int[] acceleration;
        private int[] maxVelocity;

        public Sprite(int x, int y, int width, int height, ConsoleColor color, char symbol, int speed)
        {
            this.x = x;
            this.y = y;
            this.width = width;
            this.height = height;
            this.color = color;
            this.symbol = symbol;
            this.speed = speed;
        }

        public int X { get => x; set => x = value; }
        public int Y { get => y; set => y = value; }
        public int Width { get => width; set => width = value; }
        public int Height { get => height; set => height = value; }
        public ConsoleColor Color { get => color; set => color = value; }
        public char Symbol { get => symbol; set => symbol = value; }
        public int Speed { get => speed; set => speed = value; }
        public int[] Direction { get => direction; set => direction = value; }
        public int[] Position { get => position; set => position = value; }
        public int[] Velocity { get => velocity; set => velocity = value; }
        public int[] Acceleration { get => acceleration; set => acceleration = value; }
        public int[] MaxVelocity { get => maxVelocity; set => maxVelocity = value; }

        public void Draw()
        {
            Console.ForegroundColor = Color;
            Console.SetCursorPosition(X, Y);
            Console.Write(Symbol);
        }

        public void Move()
        {
            X += direction[0] * speed;
            Y += direction[1] * speed;
        }
    }
}

// Path: Final-Fantasy\Sprite.cs
