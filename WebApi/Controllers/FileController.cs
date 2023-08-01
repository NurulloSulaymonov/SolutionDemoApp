using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class FileController : ControllerBase
{
    private readonly IFileService _fileService;

    public FileController(IFileService fileService)
    {
        _fileService = fileService;
    }

    [HttpPost("upload-image")]
    public string Upload(IFormFile image)
    {
        return _fileService.CreateFile("images",image);
    }
    
    [HttpPost("delete-image")]
    public bool Upload(string imagename)
    {
        var response  = _fileService.DeleteFile("images", imagename);
        return response;
    }
    
    
}