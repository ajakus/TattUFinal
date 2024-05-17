using Microsoft.Maui.Storage;

using TattUFinal.ViewModel;

namespace TattUFinal.View;

public partial class MyCollection : ContentPage
{
    public MyCollection(MyCollectionViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
    
    void FillCollection(object sender, EventArgs e)
    {
        var ImgSource = "../../TattUServer/ImagesUploadFolder";
        //trying to get images to populate a grid with foreach and file folder or api
        // foreach (Image in )
        // {
        //     
        // }
    }
}