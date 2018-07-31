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
    public sealed partial class Stewardesses : Page
    {
        public Stewardesses()
        {
            this.InitializeComponent();
            ViewModel = new StewardessViewModel();
        }

        public StewardessViewModel ViewModel;

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (List.SelectedItem == null)
            {
                Del.IsEnabled = false;
                return;
            }
            ViewModel.SelectedStewardess = (sender as ListView).SelectedItem as Stewardess;
            FName.Text = ViewModel.SelectedStewardess.FirstName;
            LName.Text = ViewModel.SelectedStewardess.LastName;
            Birthday.Text = ViewModel.SelectedStewardess.Birthday.ToString("yyyy-MM-dd");
            Edit.Visibility = Visibility.Visible;
            Del.IsEnabled = true;
        }

        private void AddElement(object sender, RoutedEventArgs e)
        {
            Edit.Visibility = Visibility.Visible;
            ViewModel.SelectedStewardess = null;
            List.SelectedItem = null;
            FName.Text = "";
            LName.Text = "";
            Birthday.Text = "";
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
            if (ViewModel.SelectedStewardess == null)
                ViewModel.SelectedStewardess = new Stewardess();
            ViewModel.SelectedStewardess.FirstName = FName.Text;
            ViewModel.SelectedStewardess.LastName = LName.Text;
            try
            {
                ViewModel.SelectedStewardess.Birthday = DateTime.Parse(Birthday.Text);
            }
            catch (Exception)
            { }

            if (ViewModel.SelectedStewardess != null)
                ViewModel.UpdateStewardess();
            else
                ViewModel.AddStewardess();
        }

        private void Cancel(object sender, RoutedEventArgs e)
        {
            ViewModel.SelectedStewardess = null;
            List.SelectedItem = null;
            Edit.Visibility = Visibility.Collapsed;

        }

        private void FName_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (FName.Text != null && LName != null && Birthday.Text != null)
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
                if (ViewModel.SelectedStewardess != null)
                    ViewModel.DeleteStewardess();
                Edit.Visibility = Visibility.Collapsed;
            }
            else
                return;
        }

        private void LName_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (FName.Text != null && LName != null && Birthday.Text != null)
                Save.IsEnabled = true;
            else
                Save.IsEnabled = false;
        }

        private void Birthday_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (FName.Text != null && LName != null && Birthday.Text != null )
                Save.IsEnabled = true;
            else
                Save.IsEnabled = false;
        }

    }
}
