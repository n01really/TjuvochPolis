using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tjuv_och_polis
{
    internal class Person
    {
        public int X { get; set; }
        public int Y { get; set; }

        public int XDirection { get; set; }
        public int YDirection { get; set; }

        public List<Inventory> Items { get; set; }

        public Person(int x, int y, int xDirection,int yDirection, List<Inventory>items)
        {
            X = x;
            Y = y;
            XDirection = xDirection;
            YDirection = yDirection;
            Items = new List<Inventory>();
        }

        public virtual char GetCharacter()
        {
            return ' ';
        }
        public void Move(int width, int height)
        {
            Console.SetCursorPosition(X, Y);
            Console.Write(" ");

            X += XDirection;
            Y += YDirection;

            X = Math.Clamp(X, 1, width - 2);
            Y = Math.Clamp(Y, 3, height - 2);

            if (X == width - 2 || X == 1)
            {
                XDirection = -XDirection;
            }
            if (Y == height - 2 || Y == 3)
            {
                YDirection = -YDirection;
            }
        }
    }

    class Robber : Person
    {
        bool Prison { get; set; }
        public Robber(int x, int y, int xDirection, int yDirection, List<Inventory>items, bool prison) : base(x, y, xDirection, yDirection, items)
        {
            X = x;
            Y = y;
            XDirection = xDirection;
            YDirection = yDirection;
            Items = new List<Inventory>();
            Prison = prison;
        }

        public override char GetCharacter()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            return 'T';
            
        }
    }

    class Cop : Person 
    {
        public Cop(int x, int y, int xDirection, int yDirection, List<Inventory> items) : base(x, y, xDirection, yDirection, items)
        {
            X = x;
            Y = y;
            XDirection = xDirection;
            YDirection = yDirection;
            Items = new List<Inventory>();
        }
        public override char GetCharacter()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            return 'P';
            
        }
        
    }

    class Citizen : Person
    {
        public Citizen(int x, int y, int xDirection, int yDirection, List<Inventory> items) : base(x, y, xDirection, yDirection, items) 
        {
            X = x;
            Y = y;
            XDirection = xDirection;
            YDirection = yDirection;
            Items = new List<Inventory>();
            Items.Add(new Inventory("Wallet"));
            Items.Add(new Inventory("Watch"));
            Items.Add(new Inventory("Keys"));
            Items.Add(new Inventory("Phone"));
        }
        public override char GetCharacter()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            return 'M';
            
        }
    }
}
