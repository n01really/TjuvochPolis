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
        public int inJail = 0;
        public void CollitionManager(List<Person> persons, int x, int y, int jailStartX, int jailStartY, int jailWidth, int jailHeight, bool reset)
        {
            var robbers = persons.OfType<Robber>().ToList();
            var citizens = persons.OfType<Citizen>().ToList();
            var cops = persons.OfType<Cop>().ToList();

            //  Reset functionality
            if (reset == true)
            {
                robberyCount = 0;
                arrestMade = 0;
                inJail = 0;
                while (news.Count > 0)
                {
                    news.Dequeue();
                }
                reset = false;
                Menu.reset = false;
            }

            //  Logic for when a robber run into a citizen.
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
                    Console.Beep();//det är till för att vara iriterande, jag har hört att det är irriterande att bli rånad
                    Thread.Sleep(500);
                    Console.SetCursorPosition(citizen.X, citizen.Y);
                    Console.Write("X");
                    
                    news.Enqueue(DateTime.Now.ToString("HH:mm:ss") + " Medborgaren " + citizen.Name + " blev rånad av " + robber.Name + "! Han tog " + itemRobbed.Items + "! Plats: " + citizen.X + ":" + citizen.Y + "       ");
                }
            }

            foreach (var citizen in citizens)
            {
                if (!citizen.Items.Any() && !citizen.Poor)
                {
                    citizen.Poor = true;
                    citizen.X = jailStartX + 5;
                    citizen.Y = jailStartY + 15;
                }
            }

            //  Logic for when a cop run into a robber.
            foreach (var cop in cops)
            {
                var robber = robbers.FirstOrDefault(robber => robber.X == cop.X && robber.Y == cop.Y && robber.Items.Any());
                if (robber != null)
                {
                    arrestMade++;
                    inJail++;

                    foreach(var item in robber.Items)
                    {
                        robber.PrisonTime += 200;
                    }

                    cop.Items.AddRange(robber.Items);
                    robber.Items.Clear();
                    robber.Prison = true;
                    Console.Beep();//presic som att bli tagen av polisen i verkligheten så är detta ljud lika iriteande
                    Thread.Sleep(500);
                    news.Enqueue(DateTime.Now.ToString("HH:mm:ss") + " Tjuven " + robber.Name + " blev tagen av polisen " + cop.Name + "! Plats: " + robber.X + ":" + robber.Y + "                        ");
                    robber.X = jailStartX + 5;
                    robber.Y = jailStartY + 5;
                }

            }
            News newsFeed = new News();
            newsFeed.ShowNews(news, robberyCount, arrestMade, inJail, citizens, cops, robbers, x, y);
        }
    }
}
