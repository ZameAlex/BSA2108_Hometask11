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
    public class FlightViewModel 
    {
        private FlightService service;
        private TicketService TService;
        public FlightViewModel()
        {
            this.service = new FlightService(ApiService.GetInstance());
            TService = new TicketService(ApiService.GetInstance());
            Flights = new ObservableCollection<Flight>();
            Tickets = new ObservableCollection<Ticket>();

            FillFlightsCollection();
            FillAdditionalCollections();
        }


        public Flight SelectedFlight { get; set; }

        public async void UpdateFlight()
        {
            if (await service.UpdateEntity(SelectedFlight.Id, SelectedFlight))
            {
                var tempFlight = Flights.FirstOrDefault(c => c.Id == SelectedFlight.Id);
                tempFlight.DeparturePoint = SelectedFlight.DeparturePoint;
                tempFlight.DepartureTime = SelectedFlight.DepartureTime;
                tempFlight.Destination = SelectedFlight.Destination;
                tempFlight.DestinationTime = SelectedFlight.DestinationTime;
                tempFlight.Number = SelectedFlight.Number;
                tempFlight.Tickets = SelectedFlight.Tickets;
            }
        }

        public void AddFlight()
        {
            service.CreateEntity(SelectedFlight);
            FillFlightsCollection();
        }

        public async void DeleteFlight()
        {
            if (await service.DeleteEntity(SelectedFlight.Id))
                Flights.Remove(Flights.FirstOrDefault(c => c.Id == SelectedFlight.Id));
        }



        private async void FillFlightsCollection()
        {
            var temp = await service.GetEntities();
            foreach (var item in temp)
                Flights.Add(item);
        }

        private async void FillAdditionalCollections()
        {
            
            var tickets = await TService.GetEntities();
            foreach (var item in tickets)
                Tickets.Add(item);            
        }

        public ObservableCollection<Flight> Flights { get; private set; }
        public ObservableCollection<Ticket> Tickets { get; private set; }
    }
}
