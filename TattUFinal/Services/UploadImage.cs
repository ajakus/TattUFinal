
using TattUFinal.Model;

namespace TattUFinal.Services;

public class UploadImage
{
    
    public async Task<FileResult> OpenMediaPickerAsync()
    {
        
        try
        {
            var result = await MediaPicker.PickPhotoAsync(new MediaPickerOptions
            {
                Title = "Please Pick an image"
            });
            if (result.ContentType == "image/png" ||
                result.ContentType == "image/jpeg" ||
                result.ContentType == "image/jpg")
                return result;
            else
                await App.Current.MainPage.DisplayAlert("error with image type, ", "Please try again", "Ok");

            return null;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return null;
        }
    }
    

    public async Task<Stream> FileResultToStream(FileResult fileResult)
    {
        if (fileResult == null)
            return null;

        return await fileResult.OpenReadAsync();

    }

    public Stream ByteArrayToStream(byte[] bytes)
    {
        return new MemoryStream(bytes);
    }
    
    public string ByteBase64ToString(byte[] bytes)
    {
        return Convert.ToBase64String(bytes);
    }

    public byte[] stringToByteBase64(string text)
    {
        return Convert.FromBase64String(text);
    }

    public async Task<ImageFile> Upload(FileResult fileResult)
    {
        byte[] bytes;

        try
        {
            
            using (var ms = new MemoryStream())
            {
                var stream = await FileResultToStream(fileResult);
                stream.CopyTo(ms);
                bytes = ms.ToArray();
            }

            return new ImageFile
            {
                byteBase64 = ByteBase64ToString(bytes),
                ContentType = fileResult.ContentType,
                Filename = fileResult.FileName
            };
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return null;
        }
    }
    
    public async Task<FileResult> PickAndShow(PickOptions options)
    {
        try
        {
            var result = await FilePicker.Default.PickAsync(options);
            if (result != null)
            {
                if (result.FileName.EndsWith("jpg", StringComparison.OrdinalIgnoreCase) ||
                    result.FileName.EndsWith("png", StringComparison.OrdinalIgnoreCase))
                {
                    using var stream = await result.OpenReadAsync();
                    var image = ImageSource.FromStream(() => stream);
                }
            }

            return result;
        }
        catch (Exception ex)
        {
            // The user canceled or something went wrong
        }

        return null;
    }
    
}

