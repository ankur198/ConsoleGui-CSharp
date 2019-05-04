using System;
using System.Threading.Tasks;

namespace ConsoleGUI_CS
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.BackgroundColor = ConsoleColor.Blue;

            Console.Clear();
            var RainbowLoading = new RainbowLoading(MaxWidth: 50, Left: 25, Top: Console.WindowHeight / 2);

            Console.SetCursorPosition(0, 0);
            Console.WriteLine("hehehe");

            //  while (true)
            //  {
            //      RainbowLoading.createRainbowLine();
            //  }

            var x = new Task(() =>
            {
                Console.WriteLine("hii");

                while (true)
                {
                    RainbowLoading.createRainbowLine();
                }
            });

            x.Start();

            Console.WriteLine("yooo");
            Console.ReadLine();
        }
    }
}
