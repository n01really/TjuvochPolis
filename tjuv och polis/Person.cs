﻿using System;
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
        public string Name { get; set; }
        public List<Inventory> Items { get; set; }

        public Person(int x, int y, int xDirection,int yDirection, List<Inventory>items, string name)
        {
            X = x;
            Y = y;
            XDirection = xDirection;
            YDirection = yDirection;
            Items = new List<Inventory>();
            Name = name;
        }

        public virtual char GetCharacter()
        {
            return ' ';
        }

        //  Logic for movement in the city
        public void Move(int wallLeft, int wallTop,int width, int height)
        {
            int xWidth = wallLeft + width;
            int yHeight = wallTop + height;
            Console.SetCursorPosition(X, Y);
            Console.Write(" ");
            X += XDirection;
            Y += YDirection;
            X = Math.Clamp(X, wallLeft, xWidth - 2);
            Y = Math.Clamp(Y, wallTop, yHeight - 2);

            if (X == xWidth - 3 || X == wallLeft)
            {
                XDirection = -XDirection;
            }
            if (Y == yHeight - 5 || Y == wallTop)
            {
                YDirection = -YDirection;
            }
        }
    }

    class Robber : Person
    {
        public bool Prison { get; set; }
        public int PrisonTime { get; set; }
        public Robber(int x, int y, int xDirection, int yDirection, List<Inventory>items, bool prison, string name, int prisonTime) : base(x, y, xDirection, yDirection, items, name)
        {
            X = x;
            Y = y;
            XDirection = xDirection;
            YDirection = yDirection;
            Items = items;
            Prison = prison;
            PrisonTime = prisonTime;
        }
        public override char GetCharacter()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            return 'T';
            
        }
        public override string ToString()
        {
            return "Rånare";
        }
    }

    class Cop : Person 
    {
        public Cop(int x, int y, int xDirection, int yDirection, List<Inventory> items, string name) : base(x, y, xDirection, yDirection, items, name)
        {
            X = x;
            Y = y;
            XDirection = xDirection;
            YDirection = yDirection;
            Items = items;
        }
        public override char GetCharacter()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            return 'P';
            
        }
        public override string ToString()
        {
            return "Polis";
        }
    }

    class Citizen : Person
    {
        public bool Poor { get; set; }
        public Citizen(int x, int y, int xDirection, int yDirection, List<Inventory> items, string name, bool poor) : base(x, y, xDirection, yDirection, items, name) 
        {
            X = x;
            Y = y;
            XDirection = xDirection;
            YDirection = yDirection;
            Items = items;
            Poor = poor;
        }
        public override char GetCharacter()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            return 'M';
            
        }
        public override string ToString()
        {
            return "Medborgare";
        }
    }
}
