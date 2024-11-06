using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tjuv_och_polis
{
    internal class Population
    {
        public static void Populate(int width, int height, List<Person> persons)
        {
            Random rnd = new Random();
            string[] names = new string[]
            {
                "Andersson", "Johansson", "Karlsson", "Nilsson", "Eriksson",
                "Larsson", "Olsson", "Persson", "Svensson", "Gustafsson",
                "Pettersson", "Jonsson", "Jansson", "Hansson", "Bengtsson",
                "Jönsson", "Lindberg", "Jakobsson", "Magnusson", "Olofsson",
                "Lindgren", "Axelsson", "Bergström", "Lundberg", "Lundgren",
                "Lindström", "Mattsson", "Fredriksson", "Sandberg", "Henriksson",
                "Forsberg", "Sjöberg", "Wallin", "Engström", "Eklund",
                "Danielsson", "Håkansson", "Lundin", "Gunnarsson", "Holm",
                "Samuelsson", "Fransson", "Nyberg", "Arvidsson", "Berglund",
                "Isaksson", "Ström", "Berg", "Ekström", "Söderberg"
            };

            for (int i = 0; i < 20; i++)
            {
                var rndPos = PositionsGenerate.GeneratePosition(width, height, rnd);
                persons.Add(new Citizen(rndPos.X, rndPos.Y, rndPos.XDirection, rndPos.YDirection, new List<Inventory>
                {
                new Inventory("plonkan"),
                new Inventory("klockan"),
                new Inventory("nyklarna"),
                new Inventory("telefonen")
                }, names[i]));
            }

            for (int i = 0; i < 10; i++)
            {
                var rndPos = PositionsGenerate.GeneratePosition(width, height, rnd);
                persons.Add(new Robber(rndPos.X, rndPos.Y, rndPos.XDirection, rndPos.YDirection, new List<Inventory>(), prison: false, names[i + 20], 0));
            }

            for (int i = 0; i < 10; i++)
            {
                var rndPos = PositionsGenerate.GeneratePosition(width, height, rnd);
                persons.Add(new Cop(rndPos.X, rndPos.Y, rndPos.XDirection, rndPos.YDirection, new List<Inventory>(), names[i + 30]));
            }
        }
    }
}

