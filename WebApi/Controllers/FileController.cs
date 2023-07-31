using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class FileController : ControllerBase
{
    private readonly IWebHostEnvironment _hostEnvironment;

    public FileController(IWebHostEnvironment hostEnvironment)
    {
        _hostEnvironment = hostEnvironment;
    }

    [HttpPost("upload-image")]
    public string Upload(IFormFile image)
    {
        var fullPath = Path.Combine(_hostEnvironment.WebRootPath, "images", image.FileName);
        
        using (var stream = new FileStream(fullPath, FileMode.Create))
        {
            image.CopyTo(stream);
        }

        return image.FileName;
    }
    
    [HttpPost("delete-image")]
    public string Upload(string imagename)
    {
        var fullPath = Path.Combine(_hostEnvironment.WebRootPath, "images", imagename);

        System.IO.File.Delete(fullPath);
        return "done";
    }
    
    
}