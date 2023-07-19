using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AvaloniaApplication1.ViewModels;
using SkiaSharp;

namespace AvaloniaApplication1.Export
{
    interface IExporter
    {
        SKSurface Export(PalleteItemViewModel[] palletes);
    }
}
