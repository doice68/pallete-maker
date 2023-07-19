using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Avalonia.Controls.Notifications;
using Avalonia.Media;
using AvaloniaApplication1.Views;
using CommunityToolkit.Mvvm;
using CommunityToolkit.Mvvm.ComponentModel;

namespace AvaloniaApplication1.ViewModels
{
    
    public partial class PalleteItemViewModel : ViewModelBase
    {
        [ObservableProperty]
        bool isLocked;

        public Color pColor;
        public Color PColor
        {
            get => pColor;
            set
            {
                SetProperty(ref pColor, value);
                
                HexColor = Helpers.RGB2Hex(value.R, value.G, value.B);
            }
        }

        [ObservableProperty]
        public string hexColor;
        
        public PalleteItemViewModel(Color pColor)
        {
            PColor = pColor;
        }

        public PalleteItemViewModel() 
        {
            Randomise();
        }

        public void Randomise() 
        {
            if (isLocked) return;

            PColor = new Color(
                255,
                (byte)Random.Shared.Next(0, 255),
                (byte)Random.Shared.Next(0, 255),
                (byte)Random.Shared.Next(0, 255));
        }

        public async void Copy(string format) 
        {
            var clipboard = MainView.clipboard;
            
            if (format == "hex")
                await clipboard?.SetTextAsync(hexColor);
            else if (format == "rgb")
                await clipboard?.SetTextAsync($"{PColor.R}, {PColor.G}, {pColor.B}");

            var text = await clipboard?.GetTextAsync();

            MainView.manager.Show(new Notification("Copied to clipboard", $"{text}", NotificationType.Success));
        }
    }
}
