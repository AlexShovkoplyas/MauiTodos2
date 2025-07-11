using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiTodos2.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {
        [RelayCommand]
        private async Task CreateFile()
        {
            //var x = FileSaver.Default;
            //var y = FolderPicker.Default;

            //IFilePicker filePicker = FilePicker.Default;

            //var options = PickOptions.Images;

            //var result = await filePicker.PickAsync(options);
        }

    }
}
