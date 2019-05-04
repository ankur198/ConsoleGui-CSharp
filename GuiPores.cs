using System;
using System.Threading;

namespace ConsoleGUI_CS
{
    class RainbowLoading
    {
        int maxWidth;
        int top;
        int left;
        int numOfColors = 7;
        int currentWidth = 0;
        private int delay;

        public RainbowLoading(int? MaxWidth = null, int? Delay = null, int? Left = null, int? Top = null)
        {
            this.maxWidth = MaxWidth.HasValue ? MaxWidth.Value : Console.WindowWidth;
            this.delay = (Delay.HasValue ? Delay.Value : 1000) / maxWidth;

            left = Left.HasValue ? Left.Value : Console.CursorLeft;
            top = Top.HasValue ? Top.Value : Console.CursorTop;
        }
        public void createRainbowLine()
        {
            var toriginalColor = Console.BackgroundColor;
            //var tcursor = Console.CursorVisible;
            var tleft = Console.CursorLeft;
            var ttop = Console.CursorTop;

            //Console.CursorVisible = false;
            Console.SetCursorPosition(left+currentWidth, top);

            for (int i = 0; i < numOfColors + 1; i++)
            {
                NextRainbowColor(Console.BackgroundColor);
                PrintThatColor(i == numOfColors - 1);
            }
            Console.BackgroundColor = toriginalColor;
            //Console.CursorVisible = tcursor;
            Console.SetCursorPosition(tleft, ttop);
        }

        private void NextRainbowColor(ConsoleColor color)
        {
            // WARNING:: UPDATE numOfColors IF CHANGING THIS FUNCTION
            switch (color)
            {
                case ConsoleColor.DarkBlue:
                    color = ConsoleColor.Blue;
                    break;
                case ConsoleColor.Blue:
                    color = ConsoleColor.Green;
                    break;
                case ConsoleColor.Green:
                    color = ConsoleColor.Yellow;
                    break;
                case ConsoleColor.Yellow:
                    color = ConsoleColor.DarkYellow;
                    break;
                case ConsoleColor.DarkYellow:
                    color = ConsoleColor.Red;
                    break;
                case ConsoleColor.Red:
                    color = ConsoleColor.Magenta;
                    break;
                case ConsoleColor.Magenta:
                    color = ConsoleColor.DarkMagenta;
                    break;
                case ConsoleColor.DarkMagenta:
                    color = ConsoleColor.DarkBlue;
                    break;
                default:
                    color = ConsoleColor.DarkBlue;
                    break;
            }
            Console.BackgroundColor = color;
        }


        private void PrintThatColor(bool last = true)
        {
            int charToPrint = maxWidth / numOfColors;

            for (int i = 0; i < charToPrint; i++)
            {
                currentWidth++;
                if (currentWidth >= maxWidth)
                {
                    Console.SetCursorPosition(left, top);
                    currentWidth = 0;
                }

                Console.Write(" ");
                Thread.Sleep(delay);
            }
        }
    }
}
