using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Notifications;
using Avalonia.Input.Platform;

namespace AvaloniaApplication1.Views;

public partial class MainView : UserControl
{
    public static IClipboard? clipboard;
    public static WindowNotificationManager? manager;

    public MainView()
    {
        InitializeComponent();
    }

    protected override void OnAttachedToVisualTree(VisualTreeAttachmentEventArgs e)
    {
        base.OnAttachedToVisualTree(e);
        var topLevel = TopLevel.GetTopLevel(this);
        clipboard = topLevel.Clipboard;
        manager = new WindowNotificationManager(topLevel) { MaxItems = 3 };
    }
}
