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
    public class PlaneViewModel 
    {
        private PlaneService service;
        private PlaneTypeService TService;
        public PlaneViewModel()
        {
            this.service = new PlaneService(ApiService.GetInstance());
            TService = new PlaneTypeService(ApiService.GetInstance());
            Planes = new ObservableCollection<Plane>();
            Types = new ObservableCollection<PlaneType>();

            FillPlanesCollection();
            FillAdditionalCollections();
        }


        public Plane SelectedPlane { get; set; }

        public async void UpdatePlane()
        {
            if (await service.UpdateEntity(SelectedPlane.Id, SelectedPlane))
            {
                var tempPlane = Planes.FirstOrDefault(c => c.Id == SelectedPlane.Id);
                tempPlane.Name = SelectedPlane.Name;
                tempPlane.Type = SelectedPlane.Type;
                tempPlane.Created = SelectedPlane.Created;
                tempPlane.Expired = SelectedPlane.Expired;
            }
        }

        public void AddPlane()
        {
            service.CreateEntity(SelectedPlane);
            FillPlanesCollection();
        }

        public async void DeletePlane()
        {
            if (await service.DeleteEntity(SelectedPlane.Id))
                Planes.Remove(Planes.FirstOrDefault(c => c.Id == SelectedPlane.Id));
        }



        private async void FillPlanesCollection()
        {
            var temp = await service.GetEntities();
            foreach (var item in temp)
                Planes.Add(item);
        }

        private async void FillAdditionalCollections()
        {
            
            var types = await TService.GetEntities();
            foreach (var item in types)
                Types.Add(item);            
        }

        public ObservableCollection<Plane> Planes { get; private set; }
        public ObservableCollection<PlaneType> Types { get; private set; }
    }
}
