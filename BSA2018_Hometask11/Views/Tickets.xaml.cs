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
    public sealed partial class Tickets : Page
    {
        public Tickets()
        {
            this.InitializeComponent();
            ViewModel = new TicketViewModel();
        }

        public TicketViewModel ViewModel;

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (List.SelectedItem == null)
            {
                Del.IsEnabled = false;
                return;
            }
            ViewModel.SelectedTicket = (sender as ListView).SelectedItem as Ticket;
            Flight.SelectedItem = Flight.Items.SingleOrDefault(f=>f.ToString()==ViewModel.SelectedTicket.Number.ToString());
            Price.Text = ViewModel.SelectedTicket.Price.ToString();
            Edit.Visibility = Visibility.Visible;
            Del.IsEnabled = true;
        }

        private void AddElement(object sender, RoutedEventArgs e)
        {
            Edit.Visibility = Visibility.Visible;
            ViewModel.SelectedTicket = null;
            List.SelectedItem = null;
            Flight.SelectedItem = null;
            Price.Text = "";
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
            if (ViewModel.SelectedTicket == null)
                ViewModel.SelectedTicket = new Ticket();
            try
            {
                ViewModel.SelectedTicket.Number = Guid.Parse(Flight.SelectedItem.ToString());
            }
            catch (Exception)
            { }
            try
            {
                ViewModel.SelectedTicket.Price = Int32.Parse(Price.Text);
            }
            catch (Exception)
            { }

            if (ViewModel.SelectedTicket != null)
                ViewModel.UpdateTicket();
            else
                ViewModel.AddTicket();
        }

        private void Cancel(object sender, RoutedEventArgs e)
        {
            ViewModel.SelectedTicket = null;
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
                if (ViewModel.SelectedTicket != null)
                    ViewModel.DeleteTicket();
                Edit.Visibility = Visibility.Collapsed;
            }
            else
                return;
        }

        private void LName_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Price.Text != null && Flight.SelectedItem!=null)
                Save.IsEnabled = true;
            else
                Save.IsEnabled = false;
        }

        private void Birthday_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Price.Text != null && Flight.SelectedItem != null)
                Save.IsEnabled = true;
            else
                Save.IsEnabled = false;
        }

        private void Flight_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Price.Text != null && Flight.SelectedItem != null)
                Save.IsEnabled = true;
            else
                Save.IsEnabled = false;
        }
    }
}
