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
    public sealed partial class Flights : Page
    {
        public Flights()
        {
            this.InitializeComponent();
            ViewModel = new FlightViewModel();
        }

        public FlightViewModel ViewModel;

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (List.SelectedItem == null)
            {
                Del.IsEnabled = false;
                return;
            }
            ViewModel.SelectedFlight = (sender as ListView).SelectedItem as Flight;
            Number.Text =ViewModel.SelectedFlight.Number.ToString();
            DTime.Text= ViewModel.SelectedFlight.DepartureTime.ToString("yyyy-MM-dd");
            DesTime.Text = ViewModel.SelectedFlight.DestinationTime.ToString("yyyy-MM-dd");
            DPoint.Text = ViewModel.SelectedFlight.DeparturePoint.ToString();
            DesPoint.Text = ViewModel.SelectedFlight.Destination.ToString();
            var tickets = ViewModel.SelectedFlight.Tickets;
            foreach (var item in tickets)
            {
                var select = Tickets.Items.FirstOrDefault(p => p.ToString() == item.ToString());
                Tickets.SelectedItems.Add(select);
            }
            Edit.Visibility = Visibility.Visible;
            Del.IsEnabled = true;
        }

        private void AddElement(object sender, RoutedEventArgs e)
        {
            Edit.Visibility = Visibility.Visible;
            ViewModel.SelectedFlight = null;
            List.SelectedItem = null;
            Number.Text = "";
            DTime.Text = "";
            DesTime.Text = "";
            DPoint.Text = "";
            DesPoint.Text = "";
            Tickets.SelectedItem = null;
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
            if (ViewModel.SelectedFlight == null)
                ViewModel.SelectedFlight = new Flight();
            try
            {
                ViewModel.SelectedFlight.Number = Guid.Parse(Number.Text.ToString());
            }
            catch (Exception)
            { }
            try
            {
                ViewModel.SelectedFlight.DepartureTime = DateTime.Parse(DTime.Text);
            }
            catch (Exception)
            { }
            try
            {
                ViewModel.SelectedFlight.DestinationTime = DateTime.Parse(DesTime.Text);
            }
            catch (Exception)
            { }
            ViewModel.SelectedFlight.Destination = DesPoint.Text;
            ViewModel.SelectedFlight.DeparturePoint = DPoint.Text;

            ViewModel.SelectedFlight.Tickets = new List<Ticket>();
            var tickets = Tickets.SelectedItems;
            foreach (var item in tickets)
            {
                var select = ViewModel.Tickets.FirstOrDefault(p => p.ToString() == item.ToString());
                ViewModel.SelectedFlight.Tickets.Add(select);
            }

            if (ViewModel.SelectedFlight != null)
                ViewModel.UpdateFlight();
            else
                ViewModel.AddFlight();
        }

        private void Cancel(object sender, RoutedEventArgs e)
        {
            ViewModel.SelectedFlight = null;
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
                if (ViewModel.SelectedFlight != null)
                    ViewModel.DeleteFlight();
                Edit.Visibility = Visibility.Collapsed;
            }
            else
                return;
        }

        private void Tickets_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(DPoint.Text!="" && DTime.Text!="" && DesPoint.Text!="" && DPoint.Text!="" && Number.Text!="" && Tickets.SelectedItem!=null)
                Save.IsEnabled = true;
            else
                Save.IsEnabled = false;
        }

        private void Number_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (DPoint.Text != "" && DTime.Text != "" && DesPoint.Text != "" && DPoint.Text != "" && Number.Text != "" && Tickets.SelectedItem != null)
                Save.IsEnabled = true;
            else
                Save.IsEnabled = false;
        }

        private void DPoint_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (DPoint.Text != "" && DTime.Text != "" && DesPoint.Text != "" && DPoint.Text != "" && Number.Text != "" && Tickets.SelectedItem != null)
                Save.IsEnabled = true;
            else
                Save.IsEnabled = false;
        }

        private void DTime_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (DPoint.Text != "" && DTime.Text != "" && DesPoint.Text != "" && DPoint.Text != "" && Number.Text != "" && Tickets.SelectedItem != null)
                Save.IsEnabled = true;
            else
                Save.IsEnabled = false;
        }

        private void DesPoint_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (DPoint.Text != "" && DTime.Text != "" && DesPoint.Text != "" && DPoint.Text != "" && Number.Text != "" && Tickets.SelectedItem != null)
                Save.IsEnabled = true;
            else
                Save.IsEnabled = false;
        }

        private void DesTime_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (DPoint.Text != "" && DTime.Text != "" && DesPoint.Text != "" && DPoint.Text != "" && Number.Text != "" && Tickets.SelectedItem != null)
                Save.IsEnabled = true;
            else
                Save.IsEnabled = false;
        }
    }
}
