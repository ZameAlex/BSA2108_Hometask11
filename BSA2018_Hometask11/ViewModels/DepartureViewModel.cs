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
    public class DepartureViewModel 
    {
        private DepartureService service;
        private FlightService FService;
        private CrewService CService;
        private PlaneService PService;
        public DepartureViewModel()
        {
            this.service = new DepartureService(ApiService.GetInstance());
            FService = new FlightService(ApiService.GetInstance());
            CService = new CrewService(ApiService.GetInstance());
            PService = new PlaneService(ApiService.GetInstance());

            Departures = new ObservableCollection<Departure>();
            Flights = new ObservableCollection<Flight>();
            Crews = new ObservableCollection<Crew>();
            Planes = new ObservableCollection<Plane>();

            FillDeparturesCollection();
            FillAdditionalCollections();
        }


        public Departure SelectedDeparture { get; set; }

        public async void UpdateDeparture()
        {
            if (await service.UpdateEntity(SelectedDeparture.Id, SelectedDeparture))
            {
                var tempDeparture = Departures.FirstOrDefault(c => c.Id == SelectedDeparture.Id);
                tempDeparture.Crew = SelectedDeparture.Crew;
                tempDeparture.Date = SelectedDeparture.Date;
                tempDeparture.Flight = SelectedDeparture.Flight;
                tempDeparture.Plane = SelectedDeparture.Plane;
            }
        }

        public void AddDeparture()
        {
            service.CreateEntity(SelectedDeparture);
            FillDeparturesCollection();
        }

        public async void DeleteDeparture()
        {
            if (await service.DeleteEntity(SelectedDeparture.Id))
                Departures.Remove(Departures.FirstOrDefault(c => c.Id == SelectedDeparture.Id));
        }



        private async void FillDeparturesCollection()
        {
            var temp = await service.GetEntities();
            foreach (var item in temp)
                Departures.Add(item);
        }

        private async void FillAdditionalCollections()
        {
            
            var flights = await FService.GetEntities();
            foreach (var item in flights)
                Flights.Add(item);

            var crews = await CService.GetEntities();
            foreach (var item in crews)
                Crews.Add(item);

            var planes = await PService.GetEntities();
            foreach (var item in planes)
                Planes.Add(item);
        }

        public ObservableCollection<Departure> Departures { get; private set; }
        public ObservableCollection<Flight> Flights { get; private set; }
        public ObservableCollection<Crew> Crews { get; private set; }
        public ObservableCollection<Plane> Planes { get; private set; }
    }
}
