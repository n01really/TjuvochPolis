namespace Tjuv_och_polis
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int Width = 110;
            int Heigth = 40;
            List<Citizen> citizens = GetList.Get_List(Width, Heigth);
            DrawMap.DrawBorder(Width, Heigth);
            foreach (var Citizens in GetList.citizens )
                {
                    Console.SetCursorPosition(marker.X, marker.Y);
                    Console.Write(" ");

                    marker.X += 1;
                    marker.Y += 1;

                    if (marker.X >= width - 1) marker.X = 1;
                    if (marker.Y >= height - 1) marker.Y = 1;
                }

                foreach (var marker in markers)
                {
                    Console.SetCursorPosition(marker.X, marker.Y);
                    Console.Write("M");
                }
            
        }
    }
}
