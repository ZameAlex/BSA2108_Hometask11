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
    public sealed partial class Planes : Page
    {
        public Planes()
        {
            this.InitializeComponent();
            ViewModel = new PlaneViewModel();
        }

        public PlaneViewModel ViewModel;

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (List.SelectedItem == null)
            {
                Del.IsEnabled = false;
                return;
            }
            ViewModel.SelectedPlane = (sender as ListView).SelectedItem as Plane;
            Name.Text = ViewModel.SelectedPlane.Name;
            Created.Text = ViewModel.SelectedPlane.Created.ToString("yyyy-MM-dd");
            Expires.Text = ViewModel.SelectedPlane.Created.ToString();
            Types.SelectedItem = Types.Items.SingleOrDefault(t=>(t as PlaneType).Id==ViewModel.SelectedPlane.Type.Id);
            Edit.Visibility = Visibility.Visible;
            Del.IsEnabled = true;
        }

        private void AddElement(object sender, RoutedEventArgs e)
        {
            Edit.Visibility = Visibility.Visible;
            ViewModel.SelectedPlane = null;
            List.SelectedItem = null;
            Name.Text = "";
            Created.Text = "";
            Expires.Text = "";
            Types.SelectedItem = null;
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
            if (ViewModel.SelectedPlane == null)
                ViewModel.SelectedPlane = new Plane();
            ViewModel.SelectedPlane.Name = Name.Text;
            try
            {
                ViewModel.SelectedPlane.Created = DateTime.Parse(Created.Text);
            }
            catch (Exception)
            { }
            try
            {
                ViewModel.SelectedPlane.Expired = TimeSpan.Parse(Expires.Text);
            }
            catch (Exception)
            { }
            ViewModel.SelectedPlane.Type = ViewModel.Types.SingleOrDefault(t => t.ToString() == Types.SelectedItem.ToString());
            if (ViewModel.SelectedPlane != null)
                ViewModel.UpdatePlane();
            else
                ViewModel.AddPlane();
        }

        private void Cancel(object sender, RoutedEventArgs e)
        {
            ViewModel.SelectedPlane = null;
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
                if (ViewModel.SelectedPlane != null)
                    ViewModel.DeletePlane();
                Edit.Visibility = Visibility.Collapsed;
            }
            else
                return;
        }


        private void Name_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(Name.Text!="" && Created.Text!="" && Expires.Text!="" && Types.SelectedItem!=null)
                Save.IsEnabled = true;
            else
                Save.IsEnabled = false;
        }

        private void Created_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Name.Text != "" && Created.Text != "" && Expires.Text != "" && Types.SelectedItem != null)
                Save.IsEnabled = true;
            else
                Save.IsEnabled = false;
        }

        private void Expires_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Name.Text != "" && Created.Text != "" && Expires.Text != "" && Types.SelectedItem != null)
                Save.IsEnabled = true;
            else
                Save.IsEnabled = false;
        }

        private void Types_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Name.Text != "" && Created.Text != "" && Expires.Text != "" && Types.SelectedItem != null)
                Save.IsEnabled = true;
            else
                Save.IsEnabled = false;
        }
    }
}
