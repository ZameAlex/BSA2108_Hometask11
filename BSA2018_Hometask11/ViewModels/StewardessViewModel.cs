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
    public class StewardessViewModel 
    {
        private StewardessService service;
        public StewardessViewModel()
        {
            this.service = new StewardessService(ApiService.GetInstance());
            Stewardesses = new ObservableCollection<Stewardess>();
            FillStewardesssCollection();
        }


        public Stewardess SelectedStewardess { get; set; }

        public async void UpdateStewardess()
        {
            if (await service.UpdateEntity(SelectedStewardess.Id, SelectedStewardess))
            {
                var tempStewardess = Stewardesses.FirstOrDefault(c => c.Id == SelectedStewardess.Id);
                tempStewardess.FirstName = SelectedStewardess.FirstName;
                tempStewardess.LastName = SelectedStewardess.LastName;
                tempStewardess.Birthday = SelectedStewardess.Birthday;
            }
        }

        public void AddStewardess()
        {
            service.CreateEntity(SelectedStewardess);
            FillStewardesssCollection();
        }

        public async void DeleteStewardess()
        {
            if (await service.DeleteEntity(SelectedStewardess.Id))
                Stewardesses.Remove(Stewardesses.FirstOrDefault(c => c.Id == SelectedStewardess.Id));
        }



        private async void FillStewardesssCollection()
        {
            var temp = await service.GetEntities();
            foreach (var item in temp)
                Stewardesses.Add(item);
        }

        public ObservableCollection<Stewardess> Stewardesses { get; private set; }
     }
}
