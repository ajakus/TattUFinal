using Microsoft.Maui.Storage;
using System.Net.Http.Json;

namespace TattUFinal.View;

public partial class Create : ContentPage
{
    // UploadImage uploadImage { get; set; }
    
    public Create()
    {
        InitializeComponent();
        
    }

    // private async void UploadImage_Clicked(Object sender, EventArgs e)
    // {
    //     var img = await uploadImage.OpenMediaPickerAsync();
    //
    //     var imagefile = await uploadImage.Upload(img);
    //
    //     Image_Upload.Source = ImageSource.FromStream(() =>
    //         uploadImage.ByteArrayToStream(uploadImage.stringToByteBase64(imagefile.byteBase64)));
    // }
    
    // public async Task<FileResult> UploadImage(PickOptions options)
    // {
    //     try
    //     {
    //         var result = await FilePicker.Default.PickAsync(options);
    //         if (result != null)
    //         {
    //             if (result.FileName.EndsWith("jpg", StringComparison.OrdinalIgnoreCase) ||
    //                 result.FileName.EndsWith("png", StringComparison.OrdinalIgnoreCase))
    //             {
    //                 using var stream = await result.OpenReadAsync();
    //                 var image = ImageSource.FromStream(() => stream);
    //             }
    //         }
    //
    //         return result;
    //     }
    //     catch (Exception ex)
    //     {
    //         // The user canceled or something went wrong
    //     }
    //
    //     return null;
    // }
    private async void OnUploaded(object sender, EventArgs e)
    {
        var uploadFile = await MediaPicker.PickPhotoAsync();
        
        if (uploadFile is null) return;
        var stream = await uploadFile.OpenReadAsync();
        var httpContent = new MultipartFormDataContent();
        httpContent.Add(new StreamContent(await uploadFile.OpenReadAsync()), "file", uploadFile.FileName);
        
        var httpClient = new HttpClient();
        var result = await httpClient.PostAsync("http://localhost:5237/api/UploadFile", httpContent);
        var response = await result.Content.ReadAsStringAsync();
        
        Image_Upload.Source = ImageSource.FromStream(() => stream);
        ImgLabel.Text = uploadFile.FileName;
        
        await Shell.Current.DisplayAlert("Response From Server", response, "Ok");
        
        
        
        // var result = await FilePicker.PickAsync(new PickOptions
        // {
        //     PickerTitle = "Select an image to upload...",
        //     FileTypes = FilePickerFileType.Images
        // });
        //
        // if (result == null)
        //     return;
        //
        // var stream = await uploadFile.OpenReadAsync();
        
        // Image_Upload.Source = ImageSource.FromStream(() => stream);
    }
    void TapCollection(object sender, EventArgs e)
    {
        
        Shell.Current.GoToAsync("MyCollection");
    }
    
    
}