using Microsoft.Extensions.Logging;
using TattUFinal.View;
using TattUFinal.ViewModel;


namespace TattUFinal;

public static class MauiProgram
{
    //This app only works in windows and http rn and android seems to break the app when connecting to API so that is a WIP
    public static MauiApp CreateMauiApp()
    {
        //you may need to configure the localhost to whatever you need
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });
        
        builder.Services.AddSingleton<MainPage>();
        builder.Services.AddSingleton<MainPageViewModel>();
            
        builder.Services.AddTransient<MyCollection>();
        builder.Services.AddTransient<MyCollectionViewModel>();
        
        builder.Services.AddTransient<Create>();
        builder.Services.AddTransient<Create>();
        
        

#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}