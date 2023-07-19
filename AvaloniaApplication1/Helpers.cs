using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Avalonia.Media;
using SkiaSharp;

namespace AvaloniaApplication1
{
    public static class Helpers
    {
        public static string RGB2Hex(byte r, byte g, byte b) 
        {
            return $"#{r:X2}{g:X2}{b:X2}";
        }
        public static SKColor ToSkColor(this Color color) 
        {
            return new SKColor(
             color.R,
             color.G,
             color.B);
        }
    }
}
