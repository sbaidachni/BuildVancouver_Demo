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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace NewUserControlsDemo
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class NewUIPage : Page
    {
        public NewUIPage()
        {
            this.InitializeComponent();

            TreeViewNode workFolder = new TreeViewNode() { Data = "Work Documents" };
            workFolder.IsExpanded = true;
            workFolder.Add(new TreeViewNode() { Data = "Feature Schedule" });
            workFolder.Add(new TreeViewNode() { Data = "Overall Project Plan" });
            workFolder.Add(new TreeViewNode() { Data = "Feature Rsource Allocation" });

            TreeViewNode remodelFolder = new TreeViewNode() { Data = "Home Remodel" };
            remodelFolder.IsExpanded = true;
            remodelFolder.Add(new TreeViewNode() { Data = "Contractor Contact Info" });
            remodelFolder.Add(new TreeViewNode() { Data = "Paint Color Scheme" });
            remodelFolder.Add(new TreeViewNode() { Data = "Flooring woodgrain type" });
            remodelFolder.Add(new TreeViewNode() { Data = "Kitchen cabinet style" });

            TreeViewNode personalFolder = new TreeViewNode() { Data = "Personal Documents" };
            personalFolder.IsExpanded = true;

            personalFolder.Add(remodelFolder);
            workFolder.Add(personalFolder);
            simpleTreeView.RootNode = workFolder;
        }
    }
}
