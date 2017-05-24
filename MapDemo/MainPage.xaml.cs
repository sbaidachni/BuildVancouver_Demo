using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Devices.Geolocation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Services.Maps;
using Windows.Services.Maps.OfflineMaps;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace MapDemo
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private Geopoint point= new Geopoint(new BasicGeoposition() { Latitude = 49.2993025, Longitude = -123.1525091 });
        //private Geopoint point = new Geopoint(new BasicGeoposition() { Latitude = 50.4021702, Longitude = 30.3926084 });
       

        public MainPage()
        {
            this.InitializeComponent();

            map.Center = point;
        }

        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            myButton.Visibility = Visibility.Collapsed;
            myText.Visibility = Visibility.Visible;

            var queryResult = await OfflineMapPackage.FindPackagesAsync(point);

            if (queryResult.Status == OfflineMapPackageQueryStatus.Success)
            {
                foreach (OfflineMapPackage package in queryResult.Packages)
                {
                    if (package.Status != OfflineMapPackageStatus.Downloaded)
                    {
                        myButton.Visibility = Visibility.Visible;
                        myText.Visibility = Visibility.Collapsed;
                    }
                }
            }

            base.OnNavigatedTo(e);
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            bool anyProblem = false;
            var queryResult = await OfflineMapPackage.FindPackagesAsync(point);

            if (queryResult.Status == OfflineMapPackageQueryStatus.Success)
            {
                foreach (OfflineMapPackage package in queryResult.Packages)
                {
                    if (package.Status != OfflineMapPackageStatus.Downloaded)
                    {
                        var downloadRequestResult = await package.RequestStartDownloadAsync();
                        if (downloadRequestResult.Status!=OfflineMapPackageStartDownloadStatus.Success)
                        {
                            anyProblem = true;
                        }
                    }
                }
                if (!anyProblem)
                {
                    myButton.Visibility = Visibility.Collapsed;
                    myText.Visibility = Visibility.Visible;
                }
            }
        }
    }
}
