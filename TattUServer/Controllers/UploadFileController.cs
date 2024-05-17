using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace TattUServer.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UploadFileController : ControllerBase
{
    private readonly ILogger<UploadFileController> logger;
    private readonly IWebHostEnvironment webHostEnvironment;
    // GET
    public UploadFileController(ILogger<UploadFileController> logger, IWebHostEnvironment webHostEnvironment)
    {
        this.logger = logger;
        this.webHostEnvironment = webHostEnvironment;
    }

    [HttpPost]
    public async Task<IActionResult> Post()
    {
        try
        {
            var httpContent = HttpContext.Request;

        if (httpContent is null)
            return BadRequest();

        if (httpContent.Form.Files.Count > 0)
        {
            foreach (var file in httpContent.Form.Files)
            {
                var filePath = Path.Combine(webHostEnvironment.ContentRootPath, "ImagesUploadFolder");
                //check this part because It seems weird according to the tutorial
                if (!Directory.Exists(filePath))
                    Directory.CreateDirectory(filePath);
                
                using (var memoryStream = new MemoryStream())
                {
                    await file.CopyToAsync(memoryStream);
                    System.IO.File.WriteAllBytes(Path.Combine(filePath, file.FileName), memoryStream.ToArray());
                }
            }

            return Ok(httpContent.Form.Files.Count.ToString() + " file has been uploaded");
        }

        return BadRequest("Error: No file selected");
        }
        catch (Exception ex)
        {
            logger.LogError(ex, ex.Message);
            return new StatusCodeResult(500);
        }
        
    }
}