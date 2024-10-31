using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tjuv_och_polis
{
    internal class Collition
    {
        int robberyCount = 0;
        int arrestMade = 0;
        Queue news = new Queue();
        Random rnd = new Random();
        public void CollitionManager(List<Person> persons, int x, int y, int jailStartX, int jailStartY, int jailWidth, int jailHeight)
        {
            var robbers = persons.OfType<Robber>().ToList();
            var citizens = persons.OfType<Citizen>().ToList();
            var cops = persons.OfType<Cop>().ToList();


            foreach (var robber in robbers)
            {
                var citizen = citizens.FirstOrDefault
                    (citizen => citizen.X == robber.X && citizen.Y == robber.Y && citizen.Items.Any());
                if (citizen != null)
                {
                    robberyCount++;

                    int index = rnd.Next(citizen.Items.Count);
                    Inventory itemRobbed = citizen.Items[index];

                    citizen.Items.RemoveAt(index);
                    robber.Items.Add(itemRobbed);
                    Console.SetCursorPosition(citizen.X, citizen.Y);
                    Console.Write("X");
                    
                    news.Enqueue(DateTime.Now.ToString("HH:mm:ss") + " Medborgare blev rånad! Han tog: " + itemRobbed.Items + ". Plats: " + citizen.X + ":" + citizen.Y + "           ");
                }
            }
            foreach (var cop in cops)
            {
                var robber = robbers.FirstOrDefault(robber => robber.X == cop.X && robber.Y == cop.Y && robber.Items.Any());
                if (robber != null)    
                {
                    
                    news.Enqueue(DateTime.Now.ToString("HH:mm:ss") + " Tjuv blev tagen! Plats: " + robber.X + ":" + robber.Y + "                                  ");
                    
                    arrestMade++;

                    cop.Items.AddRange(robber.Items);
                    robber.Items.Clear();
                    robber.Prison = true;
                    robber.X = jailStartX + 5;
                    robber.Y = jailStartY + 5;
                }

            }
            //if (news.Count > 5)
            //{
            //    news.Dequeue();
            //}
            Console.SetCursorPosition(x, y);
            Console.WriteLine($"Antal rån: {robberyCount}.  Antal gripna: {arrestMade}");

            if (news.Count > 0)
            {
                Console.SetCursorPosition(x, y + 2);
                Console.Beep();
                Console.WriteLine(news.Dequeue());
                Thread.Sleep(1500);
            }
        }
    }
}
