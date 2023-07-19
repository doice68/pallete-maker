using System;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Notifications;
using Avalonia.Input;
using AvaloniaApplication1.ViewModels;
using AvaloniaApplication1.Views;

namespace AvaloniaApplication1.Controls
{
    public partial class PalleteItem : UserControl
    {

        public PalleteItem()
        {
            InitializeComponent();
        }

        public void Clicked(object sender, PointerPressedEventArgs args) 
        {
            var point = args.GetCurrentPoint(sender as Control);

            if (point.Properties.IsLeftButtonPressed) 
            {
                var viewModel = ((PalleteItemViewModel)DataContext);
                if (viewModel.IsLocked) 
                {
                    MainView.manager.Show(new Notification(
                        "Pallete is locked",
                        "cannot change pallete when it's locked",
                        NotificationType.Warning));
                }
                else
                    viewModel.Randomise();
            }
        }
    }
}
