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
    public class CrewViewModel:BaseViewModel
    {
        private CrewService service;
        public CrewViewModel()
        {
            this.service = new CrewService(ApiService.GetInstance());
            Crews = new ObservableCollection<Crew>();
            var temp = service.GetEntities();
            foreach (var item in temp)
                Crews.Add(item);
        }

        private Crew selectedCrew;

        public Crew SelectedCrew
        {
            get { return selectedCrew; }
            set
            {
                selectedCrew = value;
                
            }
        }

        public ObservableCollection<Crew> Crews { get; private set; }
    }
}
