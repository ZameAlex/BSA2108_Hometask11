﻿using BSA2018_Hometask11.Models;
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
    public sealed partial class Types : Page
    {
        public Types()
        {
            this.InitializeComponent();
            ViewModel = new PlaneTypeViewModel();
        }

        public PlaneTypeViewModel ViewModel;

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (List.SelectedItem == null)
            {
                Del.IsEnabled = false;
                return;
            }
            ViewModel.SelectedPlaneType = (sender as ListView).SelectedItem as PlaneType;
            Model.Text = ViewModel.SelectedPlaneType.Model;
            Places.Text = ViewModel.SelectedPlaneType.Places.ToString();
            MaxHeight.Text = ViewModel.SelectedPlaneType.MaxHeight.ToString();
            MaxMass.Text = ViewModel.SelectedPlaneType.MaxMass.ToString();
            FleightLength.Text = ViewModel.SelectedPlaneType.FleightLength.ToString();
            Speed.Text = ViewModel.SelectedPlaneType.Speed.ToString();
            Edit.Visibility = Visibility.Visible;
            Del.IsEnabled = true;
        }

        private void AddElement(object sender, RoutedEventArgs e)
        {
            Edit.Visibility = Visibility.Visible;
            ViewModel.SelectedPlaneType = null;
            List.SelectedItem = null;
            Model.Text = "";
            Places.Text = "";
            MaxHeight.Text = "";
            MaxMass.Text = "";
            FleightLength.Text = "";
            Speed.Text = "";
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
            if (ViewModel.SelectedPlaneType == null)
                ViewModel.SelectedPlaneType = new PlaneType();
            ViewModel.SelectedPlaneType.Model = Model.Text;
            
            try
            {
                ViewModel.SelectedPlaneType.Places = Int32.Parse(Places.Text);
            }
            catch (Exception)
            { }


            try
            {
                ViewModel.SelectedPlaneType.MaxHeight = Int32.Parse(MaxHeight.Text);
            }
            catch (Exception)
            { }

            try
            {
                ViewModel.SelectedPlaneType.MaxMass = Int32.Parse(MaxMass.Text);
            }
            catch (Exception)
            { }

            try
            {
                ViewModel.SelectedPlaneType.FleightLength = Int32.Parse(FleightLength.Text);
            }
            catch (Exception)
            { }

            try
            {
                ViewModel.SelectedPlaneType.Speed = Int32.Parse(Speed.Text);
            }
            catch (Exception)
            { }

            if (ViewModel.SelectedPlaneType != null)
                ViewModel.UpdatePlaneType();
            else
                ViewModel.AddPlaneType();
        }

        private void Cancel(object sender, RoutedEventArgs e)
        {
            ViewModel.SelectedPlaneType = null;
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
                if (ViewModel.SelectedPlaneType != null)
                    ViewModel.DeletePlaneType();
                Edit.Visibility = Visibility.Collapsed;
            }
            else
                return;
        }

        private void Model_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Model.Text != "" && Places.Text != "")
                Save.IsEnabled = true;
            else
                Save.IsEnabled = false;
        }

        private void Places_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Model.Text != "" && Places.Text != "")
                Save.IsEnabled = true;
            else
                Save.IsEnabled = false;
        }

    }
}
