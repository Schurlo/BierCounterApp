using CommunityToolkit.Mvvm.ComponentModel;
using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _23._03._10_MAUI_BierApp.Model
{
    public partial class Bier : ObservableObject
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [ObservableProperty]
        string name;
        [ObservableProperty]
        string image;
        [ObservableProperty]
        double liter;
        [ObservableProperty]
        double count;

        //public int Id { get; set; }
        //public string Name { get; set; }
        //public string Image { get; set; }
        //public double Liter { get; set; }
        //public double Count { get; set; }

        //public event PropertyChangedEventHandler PropertyChanged;

        //public void RaisePropertyChanged(string propertyName)
        //{
        //    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        //}
    }
}
