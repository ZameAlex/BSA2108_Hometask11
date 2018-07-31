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
    public class CrewViewModel 
    {
        private CrewService service;
        private PilotService pilotService;
        private StewardessService stewardessService;
        public CrewViewModel()
        {
            this.service = new CrewService(ApiService.GetInstance());
            pilotService = new PilotService(ApiService.GetInstance());
            stewardessService = new StewardessService(ApiService.GetInstance());
            Crews = new ObservableCollection<Crew>();
            Pilots = new ObservableCollection<Pilot>();
            Stewardesses = new ObservableCollection<Stewardess>();
            FillCrewsCollection();
            FillAdditionalCollections();
        }


        public Crew SelectedCrew { get; set; }

        public async void UpdateCrew()
        {
            if (await service.UpdateEntity(SelectedCrew.Id, SelectedCrew))
            {
                var tempCrew = Crews.FirstOrDefault(c => c.Id == SelectedCrew.Id);
                tempCrew.Pilot = SelectedCrew.Pilot;
                tempCrew.Stewardess = SelectedCrew.Stewardess;
            }
        }

        public void AddCrew()
        {
            service.CreateEntity(SelectedCrew);
            FillCrewsCollection();
        }

        public async void DeleteCrew()
        {
            if (await service.DeleteEntity(SelectedCrew.Id))
                Crews.Remove(Crews.FirstOrDefault(c => c.Id == SelectedCrew.Id));
        }



        private async void FillCrewsCollection()
        {
            var temp = await service.GetEntities();
            foreach (var item in temp)
                Crews.Add(item);
        }

        private async void FillAdditionalCollections()
        {
            
            var pilots = await pilotService.GetEntities();
            foreach (var item in pilots)
                Pilots.Add(item);

            
            var stewardesses = await stewardessService.GetEntities();
            foreach (var item in stewardesses)
                Stewardesses.Add(item);
        }

        public ObservableCollection<Crew> Crews { get; private set; }
        public ObservableCollection<Pilot> Pilots { get; private set; }
        public ObservableCollection<Stewardess> Stewardesses {get; private set;}
     }
}
