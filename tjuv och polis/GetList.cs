using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tjuv_och_polis
{
    internal class GetList
    {
        public static void Get_List(int Width, int Height) 
        { 
            List<Citizen> citizens = new List<Citizen>();

            List<Robber> robbers = new List<Robber>();

            List<Cop> cops = new List<Cop>();

            Random rnd = new Random();


            for (int i = 0; i <= 10; i++)
            {
                citizens.Add(new Citizen(rnd.Next(1, Width -1), rnd.Next(1, Height -1), rnd.Next(-1,2), rnd.Next(-1,2), 
                    new List<Inventory> {new Inventory("Watch") }));
            }
        }
    }
}
