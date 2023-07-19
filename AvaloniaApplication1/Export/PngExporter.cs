using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AvaloniaApplication1.ViewModels;
using SkiaSharp;

namespace AvaloniaApplication1.Export
{
    internal class PngExporter : IExporter
    {
        const int width = 1700;
        const int height = 800;
        
        public SKSurface Export(PalleteItemViewModel[] palletes)
        {
            var info = new SKImageInfo(width, height);
            var surface = SKSurface.Create(info);
            var canvas = surface.Canvas;

            for (int i = 0; i < palletes.Length; i++) 
            {
                var paint = new SKPaint() { Color = palletes[i].pColor.ToSkColor() };
                canvas.DrawRect(i * (width / palletes.Length), 0, (width / palletes.Length), height, paint);
            }

            return surface;
        }
    }
}
