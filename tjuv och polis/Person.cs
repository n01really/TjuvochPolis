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
        }
    }
}
