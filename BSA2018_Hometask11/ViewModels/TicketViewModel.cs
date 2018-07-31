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
    public class TicketViewModel 
    {
        private TicketService service;
        private FlightService Fservice;
        public TicketViewModel()
        {
            this.service = new TicketService(ApiService.GetInstance());
            Fservice = new FlightService(ApiService.GetInstance());
            Tickets = new ObservableCollection<Ticket>();
            Flights = new ObservableCollection<Flight>();
            FillTicketsCollection();
        }


        public Ticket SelectedTicket { get; set; }

        public async void UpdateTicket()
        {
            if (await service.UpdateEntity(SelectedTicket.Id, SelectedTicket))
            {
                var tempTicket = Tickets.FirstOrDefault(c => c.Id == SelectedTicket.Id);
                tempTicket.Price = SelectedTicket.Price;
                tempTicket.Number = SelectedTicket.Number;
            }
        }

        public void AddTicket()
        {
            service.CreateEntity(SelectedTicket);
            FillTicketsCollection();
        }

        public async void DeleteTicket()
        {
            if (await service.DeleteEntity(SelectedTicket.Id))
                Tickets.Remove(Tickets.FirstOrDefault(c => c.Id == SelectedTicket.Id));
        }



        private async void FillTicketsCollection()
        {
            var temp = await service.GetEntities();
            foreach (var item in temp)
                Tickets.Add(item);
        }

        private async void FillAdditionalCollection()
        {
            var temp = await Fservice.GetEntities();
            foreach (var item in temp)
                Flights.Add(item);
        }

        public ObservableCollection<Ticket> Tickets { get; private set; }
        public ObservableCollection<Flight> Flights { get; private set; }
     }
}
