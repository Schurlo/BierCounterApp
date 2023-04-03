using _23._03._10_MAUI_BierApp.Model;
using _23._03._10_MAUI_BierApp.Service;
using _23._03._10_MAUI_BierApp.View;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _23._03._10_MAUI_BierApp.ModelView
{
    public partial class NewPageModelView : ObservableObject
    {
        [ObservableProperty]
        string biername;

        [ObservableProperty]
        double biercount;

        [ObservableProperty]
        string bierimage = "beer_need_photo.svg";

        [RelayCommand]
        async Task TakePhoto()
        {
            if (MediaPicker.Default.IsCaptureSupported)
            {
                FileResult photo = await MediaPicker.Default.CapturePhotoAsync();

                if (photo != null)
                {
                    // save the file into local storage
                    string localFilePath = Path.Combine(FileSystem.CacheDirectory, photo.FileName);


                    using Stream sourceStream = await photo.OpenReadAsync();
                    using FileStream localFileStream = File.OpenWrite(localFilePath);

                    await sourceStream.CopyToAsync(localFileStream);

                    Bierimage = localFilePath;
                }
            }
        }

        [RelayCommand]
        async Task Submit()
        {
            Bier bier = new Bier
            {
                Name = Biername,
                Count = Biercount,
                Liter = 0,
            };

            if (Bierimage != "beer_need_photo.svg") bier.Image = Bierimage;
            else bier.Image = "beer_no_photo.svg";
            

            await Shell.Current.GoToAsync("..",
            new Dictionary<string, object>
            {
                ["NewBier"] = bier
            });
        }

        [RelayCommand]
        async Task Close() => await Shell.Current.GoToAsync("..");

    }
}
