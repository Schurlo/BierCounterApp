using _23._03._10_MAUI_BierApp.Model;
using _23._03._10_MAUI_BierApp.Service;
using _23._03._10_MAUI_BierApp.View;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _23._03._10_MAUI_BierApp.ModelView
{
    [QueryProperty(nameof(NewBier), nameof(NewBier))]
    [QueryProperty(nameof(EditBier), nameof(EditBier))]
    public partial class CounterModelView : ObservableObject
    {
        public ObservableCollection<Bier> BierList { get; set; } = new();

        [ObservableProperty]
        Bier newBier;

        [ObservableProperty]
        bool editBier;

        [ObservableProperty]
        double gesamtLiter;

        public CounterModelView() 
        {
            Load();
        }

        async partial void OnNewBierChanged(Bier value)
        {
            BierList.Add(value);
            await BierService.AddBier(value);
        }

        partial void OnEditBierChanged(bool value)
        {
            if (value)
            {
                Load();
                EditBier = false;
            }
        }

        async void Load()
        {
            BierList.Clear();
            GesamtLiter = 0;
            var biere = await BierService.GetBier();
            
            foreach(var item in biere)
            {
                BierList.Add(item);
                GesamtLiter += item.Liter;
            }
        }

        async void Update(Bier bier)
        {
            await BierService.UpdateBier(bier);
        }

        [RelayCommand]
        public void PlusBier(Bier bier)
        {   //IsBusy Property einfügen
            bier.Liter += bier.Count; 
            GesamtLiter += bier.Count;
            Update(bier);
            //bier.RaisePropertyChanged(nameof(bier.Liter));
        }

        [RelayCommand]
        public void MinusBier(Bier bier)
        {
            bier.Liter -= bier.Count;
            GesamtLiter -= bier.Count;
            Update(bier);
            //bier.RaisePropertyChanged(nameof(bier.Liter));
        }

        [RelayCommand]
        async Task EditPage(Bier bier)
        {
            await Shell.Current.GoToAsync($"{nameof(EditPageView)}",
                new Dictionary<string, object>
                {
                    ["EditBier"] = bier
                });
        }

        [RelayCommand]
        async Task NewPage() => await Shell.Current.GoToAsync(nameof(NewPageView));
    }
}
