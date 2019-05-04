using System;
using System.Threading.Tasks;

namespace ConsoleGUI_CS
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();
            var RainbowLoading = new RainbowLoading(MaxWidth: 10, Left: 25, Top: Console.WindowHeight / 2);

            Console.SetCursorPosition(0, 0);

            new Task(() =>
            {
                while (true)
                {
                    RainbowLoading.createRainbowLine();
                }
            }).Start();


            Console.WriteLine("hehehe");
            Console.ReadLine();
        }
    }
}
