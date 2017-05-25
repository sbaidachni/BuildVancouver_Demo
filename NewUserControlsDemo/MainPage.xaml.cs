using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace NewUserControlsDemo
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();

            NavView.MenuItems.Add(new NavigationMenuItem()
            { Text = "Apps", Icon = new SymbolIcon(Symbol.AllApps), Tag = "apps" });
            NavView.MenuItems.Add(new NavigationMenuItem()
            { Text = "Games", Icon = new SymbolIcon(Symbol.Video), Tag = "games" });
            NavView.MenuItems.Add(new NavigationMenuItem()
            { Text = "Music", Icon = new SymbolIcon(Symbol.Audio), Tag = "music" });
            NavView.MenuItems.Add(new NavigationMenuItemSeparator());
            NavView.MenuItems.Add(new NavigationMenuItem()
            { Text = "My content", Icon = new SymbolIcon(Symbol.Folder), Tag = "content" });

            ContentFrame.Navigate(typeof(NewUIPage));
        }
    }
}
