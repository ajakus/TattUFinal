using System.ComponentModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using TattUFinal.View;

namespace TattUFinal.ViewModel;

public partial class MainPageViewModel : ObservableObject
{
    [ObservableProperty]
    string text;
    
    // public string Text
    // {
    //     get => text;
    //     set => text = value;
    // }
    //
    // public event PropertyChangedEventHandler PropertyChanged;
    // void OnPropertyChanged(string name) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        
    [RelayCommand]
    async Task Tap(string s)
    {
        // await DisplayAlert("Alert", "OK");
        await Shell.Current.GoToAsync("View/MyCollection");
    }
}