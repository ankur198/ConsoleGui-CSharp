using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace ConsoleGuiLib.Container
{
    /// <summary>
    /// Simple Container with shadow, can contain items within itself
    /// </summary>
    public class SimpleContainer : GuiElement, IShadowableElement
    {
        private List<IGuiElement> _InsideElements = new List<IGuiElement>();

        public SimpleContainer(int X, int Y, int Width, int Height) :
            base(X, Y, Width, Height)
        {
        }

        public ConsoleColor ShadowColor { get; set; }
        public bool isShadowEnabled { get; set; }

        public IGuiElement this[int index]
        {
            get
            {
                return _InsideElements[index];
            }

            set
            {

                if (index == _InsideElements.Count)
                {
                    _InsideElements.Add(value);
                }

                if (index < _InsideElements.Count)
                {
                    /// shifting each element for new element 

                    _InsideElements.Add(null);

                    for (int i = _InsideElements.Count - 1; i >= index; i--)
                    {
                        _InsideElements[i] = _InsideElements[i - 1];
                    }
                    _InsideElements.Insert(index, value);
                }
            }
        }

        private void DrawBorder()
        {
            // row border
            for (int i = 0; i < WorkableArea.MaxX - 1; i++)
            {
                Print(i, 0, '=');
                Print(i, WorkableArea.MaxY, '=');
            }

            // column border
            // this loop starts from 1 and end before last row
            for (int i = 0; i < WorkableArea.MaxY + 1; i++)
            {
                Print(0, i, "||");
                Print(WorkableArea.MaxX - 1, i, "||");
            }
        }

        public override void Draw()
        {
            PaintBackground();
            if (isShadowEnabled)
            {
                PaintShadow();
            }
            DrawBorder();

            AddText();
        }

        private void AddText()
        {
            var s = "Yoo bro kesi ho?";
            Print(WorkableArea.MinX + 4, WorkableArea.MinY + 4, s);
        }

        public void PaintShadow()
        {
            for (int i = 0; i < WorkableArea.MaxY; i++)
            {
                Print(WorkableArea.MaxX, i, ' ', ShadowColor, ShadowColor);
            }
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < WorkableArea.MaxX + 1; i++)
            {
                sb.Append(' ');
            }
            Print(0, WorkableArea.MaxY, sb, ShadowColor, ShadowColor);

            WorkableArea.MaxX -= 1;
            WorkableArea.MaxY -= 1;
        }
    }
}
