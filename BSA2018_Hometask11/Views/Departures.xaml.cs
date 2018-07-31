using BSA2018_Hometask11.Models;
using BSA2018_Hometask11.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace BSA2018_Hometask11.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Departures : Page
    {

        public Departures()
        {
            ViewModel = new DepartureViewModel();
            this.InitializeComponent();
        }

        public DepartureViewModel ViewModel;

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (List.SelectedItem == null)
            {
                Del.IsEnabled = false;
                return;
            }
            ViewModel.SelectedDeparture = (sender as ListView).SelectedItem as Departure;
            var planes = Planes.Items.SingleOrDefault(p => p.ToString() == ViewModel.SelectedDeparture.Plane.ToString());
            Planes.SelectedItem = planes;

            var crews = Crews.Items.SingleOrDefault(p => p.ToString() == ViewModel.SelectedDeparture.Crew.ToString());
            Crews.SelectedItem = crews;

            var flight = Flights.Items.SingleOrDefault(p => p.ToString() == ViewModel.SelectedDeparture.Flight.ToString());
            Flights.SelectedItem = flight;

            Date.Text = ViewModel.SelectedDeparture.Date.ToString("yyyy-MM-dd");

            Edit.Visibility = Visibility.Visible;
            Del.IsEnabled = true;
        }

        private void AddElement(object sender, RoutedEventArgs e)
        {
            Edit.Visibility = Visibility.Visible;
            ViewModel.SelectedDeparture = null;
            List.SelectedItem = null;
            Planes.SelectedItem = null;
            Crews.SelectedItem = null;
            Flights.SelectedItem = null;
            Date.Text = "";
        }

        private async void SaveChangesAsync(object sender, RoutedEventArgs e)
        {
            var dialog = new MessageDialog("Are you sure?");
            dialog.Title = "Really?";
            dialog.Commands.Add(new UICommand { Label = "Ok", Id = 0 });
            dialog.Commands.Add(new UICommand { Label = "Cancel", Id = 1 });
            var res = await dialog.ShowAsync();

            if ((int)res.Id == 1)
                return;
            if (ViewModel.SelectedDeparture == null)
                ViewModel.SelectedDeparture = new Departure();
            ViewModel.SelectedDeparture.Crew = ViewModel.Crews.SingleOrDefault(c => c.ToString() == Crews.SelectedItem.ToString());
            ViewModel.SelectedDeparture.Plane = ViewModel.Planes.SingleOrDefault(c => c.ToString() == Planes.SelectedItem.ToString());
            ViewModel.SelectedDeparture.Flight = ViewModel.Flights.SingleOrDefault(c => c.ToString() == Flights.SelectedItem.ToString());
            try
            {
                ViewModel.SelectedDeparture.Date = DateTime.Parse(Date.ToString());
            }
            catch (Exception)
            { }

            if (ViewModel.SelectedDeparture != null)
                ViewModel.UpdateDeparture();
            else
                ViewModel.AddDeparture();
        }

        private void Cancel(object sender, RoutedEventArgs e)
        {
            ViewModel.SelectedDeparture = null;
            List.SelectedItem = null;
            Edit.Visibility = Visibility.Collapsed;

        }

        private async void Delete(object sender, RoutedEventArgs e)
        {
            var dialog = new MessageDialog("Are you sure?");
            dialog.Title = "Really?";
            dialog.Commands.Add(new UICommand { Label = "Ok", Id = 0 });
            dialog.Commands.Add(new UICommand { Label = "Cancel", Id = 1 });
            var res = await dialog.ShowAsync();

            if ((int)res.Id == 0)
            {
                if (ViewModel.SelectedDeparture != null)
                    ViewModel.DeleteDeparture();
                Edit.Visibility = Visibility.Collapsed;
            }
            else
                return;
        }

        private void Date_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(String.IsNullOrWhiteSpace(Date.Text) && Crews.SelectedItem!= null && Planes.SelectedItem != null && Flights.SelectedItem != null)
                Save.IsEnabled = true;
            else
                Save.IsEnabled = false;
        }

        private void SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (String.IsNullOrWhiteSpace(Date.Text) && Crews.SelectedItem != null && Planes.SelectedItem != null && Flights.SelectedItem != null)
                Save.IsEnabled = true;
            else
                Save.IsEnabled = false;
        }

    }
}
