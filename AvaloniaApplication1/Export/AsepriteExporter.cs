using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Avalonia.Media;
using AvaloniaApplication1.ViewModels;
using SkiaSharp;

namespace AvaloniaApplication1.Export
{
    class AsepriteExporter : IExporter
    {
        public SKSurface Export(PalleteItemViewModel[] palletes)
        {
            var info = new SKImageInfo(palletes.Length, 1);
            var surface = SKSurface.Create(info);

            for (int i = 0; i < palletes.Length; i++) 
            {
                surface.Canvas.DrawPoint(new SKPoint(i, 0), palletes[i].pColor.ToSkColor());
            }
            return surface;
        }
    }
}
