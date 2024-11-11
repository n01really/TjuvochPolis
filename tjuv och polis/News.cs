using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tjuv_och_polis
{
    internal class News
    {
        public void ShowNews(Queue news, int robberyCount, int arrestMade, int inJail, List<Citizen>citizens, List<Cop>cops, List<Robber>robbers, int x, int y)
        {
            while (news.Count > 5)
            {
                news.Dequeue();
            }

            //  Robbery statistics
            Console.SetCursorPosition(x, y);
            Console.WriteLine($"Antal rån: {robberyCount} | Antal gripna: {arrestMade} | Antal medborgare: {citizens.Count} | Antal poliser: {cops.Count} | Antal fria tjuvar: {robbers.Count - inJail} ");
            Console.SetCursorPosition(x, y + 1);
            Console.WriteLine("----------------------------------------------------------------------------------------------------");

            //  Scrolling newsfeed
            object[] newsArray = news.ToArray();
            Console.SetCursorPosition(x, y + 2);
            Console.WriteLine("Nyheter:");
            if (news.Count > 0)
            {
                for (int i = 0; i < newsArray.Length; i++)
                {
                    if (i > 2)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                    }
                    else if (i > 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Gray;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                    }

                    var newsItem = newsArray[newsArray.Length - 1 - i];
                    Console.SetCursorPosition(x, y + 3 + i);
                    Console.WriteLine(newsItem);
                }
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
    }
}
