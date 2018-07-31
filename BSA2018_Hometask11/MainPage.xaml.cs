using BSA2018_Hometask11.Views;
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

namespace BSA2018_Hometask11
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (crews.IsSelected)
                myFrame.Navigate(typeof(Crews));
            if (pilots.IsSelected)
                myFrame.Navigate(typeof(Pilots));
            if (tickets.IsSelected)
                myFrame.Navigate(typeof(Tickets));
            if (stewardesses.IsSelected)
                myFrame.Navigate(typeof(Stewardesses));
            if (flights.IsSelected)
                myFrame.Navigate(typeof(Flights));
        }

    }
}
