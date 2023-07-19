using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Controls.Notifications;
using Avalonia.Media;
using AvaloniaApplication1.Export;
using AvaloniaApplication1.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using SkiaSharp;

namespace AvaloniaApplication1.ViewModels;

public partial class MainViewModel : ViewModelBase
{
    [ObservableProperty]
    public ObservableCollection<PalleteItemViewModel> palleteItems;
    
    Dictionary<string, IExporter> exporters = new()
    {
        { "aseprite", new AsepriteExporter() },
        { "png", new PngExporter() }
    };

    public MainViewModel()
    {
        if (Avalonia.Controls.Design.IsDesignMode) 
        {
            palleteItems = new ObservableCollection<PalleteItemViewModel>()
            {
                new PalleteItemViewModel(Colors.Aquamarine),
                new PalleteItemViewModel(Colors.PeachPuff)
            };
        }
        else 
        {
            palleteItems = new ObservableCollection<PalleteItemViewModel>()
            {
                new PalleteItemViewModel(),
                new PalleteItemViewModel()
            };
        }
        
    }

    public void AddItem() 
    {
        PalleteItems.Add(new PalleteItemViewModel());
    }

    public void RemoveItem() 
    {
        if (PalleteItems.Count > 1)
            PalleteItems.RemoveAt(PalleteItems.Count - 1);
    }

    public void RandomiseAll() 
    {
        for (int i = 0; i < palleteItems.Count; i++)
        {
            palleteItems[i].Randomise();
        }
    }

    public async void Export(string format) 
    {
        if (exporters.TryGetValue(format, out var exporter)) 
        {
            if (Application.Current?.ApplicationLifetime is not IClassicDesktopStyleApplicationLifetime desktop ||
                desktop.MainWindow?.StorageProvider is not { } provider)
                throw new NullReferenceException("Missing StorageProvider instance.");

            var path = await provider.SaveFilePickerAsync(new() { Title = "Save as"});

            if (path == null)
                return;

            var surface = exporter.Export(palleteItems.ToArray());

            using (var image = surface.Snapshot())
            using (var data = image.Encode(SKEncodedImageFormat.Png, 100))
            using (var stream = File.OpenWrite(path.Path.AbsolutePath + ".png"))
            {
                data.SaveTo(stream);
            }
            surface.Dispose();
            MainView.manager.Show(new Notification("Exported", "exporting was successful!", NotificationType.Success));
        }
    }
}
