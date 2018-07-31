using BSA2018_Hometask11.Models;
using BSA2018_Hometask11.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace BSA2018_Hometask11.ViewModels
{
    public class PlaneTypeViewModel 
    {
        private PlaneTypeService service;
        public PlaneTypeViewModel()
        {
            this.service = new PlaneTypeService(ApiService.GetInstance());
            PlaneTypes = new ObservableCollection<PlaneType>();

            FillPlaneTypesCollection();
        }


        public PlaneType SelectedPlaneType { get; set; }

        public async void UpdatePlaneType()
        {
            if (await service.UpdateEntity(SelectedPlaneType.Id, SelectedPlaneType))
            {
                var tempPlaneType = PlaneTypes.FirstOrDefault(c => c.Id == SelectedPlaneType.Id);
                tempPlaneType.Model = SelectedPlaneType.Model;
                tempPlaneType.MaxHeight = SelectedPlaneType.MaxHeight;
                tempPlaneType.MaxMass = SelectedPlaneType.MaxMass;
                tempPlaneType.Places = SelectedPlaneType.Places;
                tempPlaneType.Speed = SelectedPlaneType.Speed;
                tempPlaneType.FleightLength = SelectedPlaneType.FleightLength;
            }
        }

        public void AddPlaneType()
        {
            service.CreateEntity(SelectedPlaneType);
            FillPlaneTypesCollection();
        }

        public async void DeletePlaneType()
        {
            if (await service.DeleteEntity(SelectedPlaneType.Id))
                PlaneTypes.Remove(PlaneTypes.FirstOrDefault(c => c.Id == SelectedPlaneType.Id));
        }



        private async void FillPlaneTypesCollection()
        {
            var temp = await service.GetEntities();
            foreach (var item in temp)
                PlaneTypes.Add(item);
        }

        public ObservableCollection<PlaneType> PlaneTypes { get; private set; }

    }
}
