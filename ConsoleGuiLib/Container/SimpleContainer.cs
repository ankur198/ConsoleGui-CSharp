using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace ConsoleGuiLib.Container
{
    public class SimpleContainer : GuiElement
    {
        private List<IGuiElement> _InsideElements = new List<IGuiElement>();

        public SimpleContainer(int X, int Y, int Width, int Height) :
            base(X, Y, Width, Height)
        {
        }

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
            for (int i = 0; i < Width; i++)
            {
                Print(i, 0, '=');
                Print(i, Height - 1, '=');
            }

            // column border
            // this loop starts from 1 and end before last row
            for (int i = 1; i < Height - 1; i++)
            {
                Print(0, i, "||");
                Print(Width - 2, i, "||");
            }
        }

        public override void Draw()
        {
            PaintBackground();
            DrawBorder();
        }


    }
}
