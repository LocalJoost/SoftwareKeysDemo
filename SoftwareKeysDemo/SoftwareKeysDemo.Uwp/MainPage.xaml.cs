using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Devices.Geolocation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Core;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Maps;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace SoftwareKeysDemo.Uwp
{
  /// <summary>
  /// An empty page that can be used on its own or navigated to within a Frame.
  /// </summary>
  public sealed partial class MainPage : Page
  {
    public MainPage()
    {
      this.InitializeComponent();
      this.Loaded += MainPage_Loaded;
      this.NavigationCacheMode = NavigationCacheMode.Required;
    }

    private void MainPage_Loaded(object sender, RoutedEventArgs e)
    {
      MyMap.TrySetViewAsync(new Geopoint(new BasicGeoposition { Latitude = 52.181427, Longitude = 5.399780 }),
                            16, 0, 0, MapAnimationKind.Bow);
    }

    private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
    {
      Frame.Navigate(typeof(Page2));
    }

    protected override void OnNavigatedTo(NavigationEventArgs e)
    {
      base.OnNavigatedTo(e);
      var rootFrame = Window.Current.Content as Frame;
      if (rootFrame != null)
      {
        SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = rootFrame.CanGoBack
          ? AppViewBackButtonVisibility.Visible
          : AppViewBackButtonVisibility.Collapsed;
      }
    }

    private void ButtonBase1_OnClick(object sender, RoutedEventArgs e)
    {
      BottomAppBar.ClosedDisplayMode = BottomAppBar.ClosedDisplayMode == AppBarClosedDisplayMode.Compact
        ? AppBarClosedDisplayMode.Minimal
        : AppBarClosedDisplayMode.Compact;
    }
  }
}
