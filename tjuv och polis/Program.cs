using System.ComponentModel;
using System.Security.Cryptography.X509Certificates;

namespace Tjuv_och_polis
{
    internal class Program
    {
        public static void Main()
        {
            int Width = 80, Height = 20;
            List<Person> persons = new List<Person>();
            Population.Populate(Width, Height, persons);
            Menu.Title();
            Menu.Buttons(persons);
        }
    }
}