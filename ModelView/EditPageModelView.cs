using _23._03._10_MAUI_BierApp.Model;
using _23._03._10_MAUI_BierApp.Service;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Maui.Controls.Shapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _23._03._10_MAUI_BierApp.ModelView
{
    [QueryProperty(nameof(EditBier), nameof(EditBier))]
    internal partial class EditPageModelView : ObservableObject
    {
        [ObservableProperty]
        Bier editBier;

        [ObservableProperty]
        string biername;

        [ObservableProperty]
        double biercount;

        [ObservableProperty]
        double bierliter;

        [ObservableProperty]
        string bierimage;

        partial void OnEditBierChanged(Bier value)
        {
            Biername = value.Name;
            Biercount = value.Count;
            Bierliter = value.Liter;

            if (value.Image == "beer_no_photo.svg") Bierimage = "beer_need_photo.svg";
            else Bierimage = value.Image;
        }

        [RelayCommand]
        async Task TakePhoto()
        {
            if (MediaPicker.Default.IsCaptureSupported)
            {
                FileResult photo = await MediaPicker.Default.CapturePhotoAsync();

                if (photo != null)
                {
                    // save the file into local storage
                    string localFilePath = System.IO.Path.Combine(FileSystem.CacheDirectory, photo.FileName);

                    using Stream sourceStream = await photo.OpenReadAsync();
                    using FileStream localFileStream = File.OpenWrite(localFilePath);

                    await sourceStream.CopyToAsync(localFileStream);

                    Bierimage = localFilePath;
                }
            }
        }

        [RelayCommand]
        async Task Save()
        {
            EditBier.Name = Biername;
            EditBier.Count = Biercount;
            EditBier.Liter = Bierliter;

            if (Bierimage == "beer_need_photo.svg") Bierimage = "beer_no_photo.svg";

            EditBier.Image = Bierimage;

            await BierService.UpdateBier(EditBier);
            await CloseUpdate();
        }

        async Task CloseUpdate() => await Shell.Current.GoToAsync("..?EditBier=true");

        [RelayCommand]
        async Task Close() => await Shell.Current.GoToAsync("..");

        [RelayCommand]
        async Task Delete()
        {
            await BierService.RemoveBier(EditBier.Id);
            await CloseUpdate();
        }
    }
}
