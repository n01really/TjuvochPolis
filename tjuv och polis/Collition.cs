﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tjuv_och_polis
{
    internal class Collition
    {
        int robberyCount = 0;
        List<string> news = new List<string>();
        public void RobberCitizenCollition(List<Person> persons, int x, int y)
        {
            var robbers = persons.OfType<Robber>().ToList();
            var citizens = persons.OfType<Citizen>().ToList();

            bool robbery = false;


            foreach(var robber in robbers)
            {
                foreach(var citizen in citizens)
                {
                    if (robber.X == citizen.X && robber.Y == citizen.Y)
                    {
                        robbery = true;
                        news.Add("Medborgare blev rånad!");
                        robberyCount++;
                        if (news.Count > 5)
                        {
                            news.RemoveAt(0);
                        }
                    }
                }    
            }
            Console.SetCursorPosition(x, y);
            Console.WriteLine($"Antal rån: {robberyCount}");


            for (int i = news.Count - 1; i >= 0; i--)
            {
                Console.SetCursorPosition(x, y + 2 + i);
                Console.WriteLine(news[i]);
            }
            
        }
    }
}
