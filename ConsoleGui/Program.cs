using ConsoleGuiLib.Container;
using System;
using System.Threading.Tasks;

namespace ConsoleGUI_CS
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();

            Console.WindowWidth = 150;
            Console.WindowHeight = Console.LargestWindowHeight;
            //Console.WindowHeight = 50;

            // DrawRainbow();
            int Width = Console.WindowWidth;
            int Height = Console.WindowHeight;

            int centerW = Width / 2;
            int centerH = Height / 2;


            var container = new SimpleContainer(centerW - 40, centerH - 10, 80, 20);
            container.BackgroundColor = ConsoleColor.Blue;
            container.Color = ConsoleColor.White;
            container.Draw();

            Console.ReadLine();
            Console.ResetColor();
        }

        private static void DrawRainbow()
        {
            var RainbowLoading = new RainbowLoading(MaxWidth: 50, Left: 25, Top: Console.WindowHeight / 2);
            var x = new Task(() =>
            {
                Console.WriteLine("hii");

                while (true)
                {
                    RainbowLoading.createRainbowLine();
                }
            });
            x.Start();
        }
    }
}
