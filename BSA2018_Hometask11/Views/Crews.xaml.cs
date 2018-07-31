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
    public sealed partial class Crews : Page
    {

        public Crews()
        {
            ViewModel = new CrewViewModel();
            this.InitializeComponent();
        }

        public CrewViewModel ViewModel;

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (List.SelectedItem == null)
            {
                Del.IsEnabled = false;
                return;
            }
            ViewModel.SelectedCrew = (sender as ListView).SelectedItem as Crew;
            var pilot = Pilots.Items.SingleOrDefault(p => p.ToString() == ViewModel.SelectedCrew.Pilot.ToString());
            Pilots.SelectedItem = pilot;
            var stewardesses = ViewModel.SelectedCrew.Stewardess;
            foreach(var item in stewardesses)
            {
                var select = Stewards.Items.FirstOrDefault(p => p.ToString() == item.ToString());
                Stewards.SelectedItems.Add(select);
            }
            Edit.Visibility = Visibility.Visible;
            Del.IsEnabled = true;
        }

        private void AddElement(object sender, RoutedEventArgs e)
        {
            Edit.Visibility = Visibility.Visible;
            ViewModel.SelectedCrew = null;
            List.SelectedItem = null;
            Pilots.SelectedItem = null;
            Stewards.SelectedItems.Clear();
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
            if (ViewModel.SelectedCrew == null)
                ViewModel.SelectedCrew = new Crew();
            ViewModel.SelectedCrew.Pilot = ViewModel.Pilots.SingleOrDefault(p => p.ToString() == Pilots.SelectedItem.ToString());
            ViewModel.SelectedCrew.Stewardess = new List<Stewardess>();
            var stewardesses = Stewards.SelectedItems;
            foreach (var item in stewardesses)
            {
                var select = ViewModel.Stewardesses.FirstOrDefault(p => p.ToString() == item.ToString());
                ViewModel.SelectedCrew.Stewardess.Add(select);
            }

            if (ViewModel.SelectedCrew != null)
                ViewModel.UpdateCrew();
            else
                ViewModel.AddCrew();
        }

        private void Cancel(object sender, RoutedEventArgs e)
        {
            ViewModel.SelectedCrew = null;
            List.SelectedItem = null;
            Edit.Visibility = Visibility.Collapsed;

        }

        private void SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Pilots.SelectedItem != null && Stewards.SelectedItems != null && Stewards.SelectedItems.Any())
                Save.IsEnabled = true;
            else
                Save.IsEnabled = false;
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
                if (ViewModel.SelectedCrew != null)
                    ViewModel.DeleteCrew();
                Edit.Visibility = Visibility.Collapsed;
            }
            else
                return;
        }
    }
}
