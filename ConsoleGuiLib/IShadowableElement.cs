using System;

namespace ConsoleGuiLib
{
    public interface IShadowableElement
    {
        ConsoleColor ShadowColor { get; set; }
        /// <summary>
        /// Please note that enabling shadow will decrease size of element by 1
        /// </summary>
        bool isShadowEnabled { get; set; }


        void PaintShadow();
    }
}