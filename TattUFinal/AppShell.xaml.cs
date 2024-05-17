using TattUFinal.View;
using TattUFinal.ViewModel;

namespace TattUFinal;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();
        Routing.RegisterRoute(nameof(MyCollection), typeof(MyCollection));
        Routing.RegisterRoute(nameof(Create), typeof(Create));
    }
}