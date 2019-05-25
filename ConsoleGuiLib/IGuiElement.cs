using System;

namespace ConsoleGuiLib
{
    public interface IGuiElement
    {
        ConsoleColor BackgroundColor { get; set; }
        ConsoleColor Color { get; set; }
        int Height { get; set; }
        int Width { get; set; }
        int X { get; set; }
        int Y { get; set; }
        void PaintBackground();
        void Draw();
    }
}