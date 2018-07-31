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
    public class PilotViewModel 
    {
        private PilotService service;
        public PilotViewModel()
        {
            this.service = new PilotService(ApiService.GetInstance());
            Pilots = new ObservableCollection<Pilot>();
            FillPilotsCollection();
        }


        public Pilot SelectedPilot { get; set; }

        public async void UpdatePilot()
        {
            if (await service.UpdateEntity(SelectedPilot.Id, SelectedPilot))
            {
                var tempPilot = Pilots.FirstOrDefault(c => c.Id == SelectedPilot.Id);
                tempPilot.FirstName = SelectedPilot.FirstName;
                tempPilot.LastName = SelectedPilot.LastName;
                tempPilot.Birthday = SelectedPilot.Birthday;
                tempPilot.Experience = SelectedPilot.Experience;
            }
        }

        public void AddPilot()
        {
            service.CreateEntity(SelectedPilot);
            FillPilotsCollection();
        }

        public async void DeletePilot()
        {
            if (await service.DeleteEntity(SelectedPilot.Id))
                Pilots.Remove(Pilots.FirstOrDefault(c => c.Id == SelectedPilot.Id));
        }



        private async void FillPilotsCollection()
        {
            var temp = await service.GetEntities();
            foreach (var item in temp)
                Pilots.Add(item);
        }

        public ObservableCollection<Pilot> Pilots { get; private set; }
     }
}
