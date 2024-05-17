
using TattUFinal.ViewModel;

namespace TattUFinal.View;


public partial class MainPage : ContentPage
{
    
    //this below keeps breaking app
    public MainPage(MainPageViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
    void TapCollection(object sender, TappedEventArgs args)
    {
        
        Shell.Current.GoToAsync("MyCollection");
    }
    void TapCreate(object sender, TappedEventArgs args)
    {
        
        Shell.Current.GoToAsync("Create");
    }
}