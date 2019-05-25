using System;
using System.Text;

namespace ConsoleGuiLib
{
    public abstract class GuiElement : IGuiElement
    {

        private static bool isPrinting;
        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public ConsoleColor Color { get; set; }
        public ConsoleColor BackgroundColor { get; set; }

        public GuiElement(int X, int Y, int Width, int Height)
        {
            this.X = X;
            this.Y = Y;
            this.Width = Width;
            this.Height = Height;
            BackgroundColor = ConsoleColor.Black;
            Color = ConsoleColor.White;
        }

        internal int[] CurrentPointerPosition = new int[] { 0, 0 };

        protected void Print(int posX, int posY, object value)
        {
            // Todo something so that only one element can execute print at one time


            if (posX + X < Width + X && posY + Y < Height + Y)
            {

                // all settings are correct and we can now print
                Console.BackgroundColor = BackgroundColor;
                Console.ForegroundColor = Color;
                Console.SetCursorPosition(posX + X, posY + Y);
                Console.Write(value);
            }

            else
            {
                // posx or posy are outside the boundry of element

                throw new Exception("Printing outside boundary of element");

            }

            Console.ResetColor();

        }

        public void PaintBackground()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < Width; i++)
            {
                sb.Append(' ');
            }
            var s = sb.ToString();
            for (int i = 0; i < Height - 1; i++)
            {
                Print(0, i, s);
            }
        }

        public abstract void Draw();

    }
}
