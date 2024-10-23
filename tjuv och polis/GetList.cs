using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tjuv_och_polis
{
    internal class GetList
    {
        public static List<Citizen> Get_List(int Width, int Height) 
        { 
            List<Citizen> citizens = new List<Citizen>();

            List<Robber> robbers = new List<Robber>();

            List<Cop> cops = new List<Cop>();

            Random rnd = new Random();

            int x = 0;
            int y = 0;


            for (int i = 0; i <= 10; i++)
            {
                x = rnd.Next(-1, 2);
                y = rnd.Next(-1, 2);

                while (x == 0 && y == 0)
                {
                    x = rnd.Next(-1, 2);
                    y = rnd.Next(-1, 2);
                }

                citizens.Add(new Citizen(rnd.Next(1, Width -1), rnd.Next(1, Height -1), x, y, 
                    new List<Inventory> {new Inventory("Watch") }));
            }

            return citizens;
        }
    }
}
