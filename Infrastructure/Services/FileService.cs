using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace Infrastructure.Services;

public class FileService :IFileService
{
    private readonly IWebHostEnvironment _hostEnvironment;

    public FileService(IWebHostEnvironment hostEnvironment)
    {
        _hostEnvironment = hostEnvironment;
    }
    public string CreateFile(string folder, IFormFile file)
    {
        try
        {
            var fullpath = Path.Combine(_hostEnvironment.WebRootPath, folder, file.FileName);
            using (var stream = new FileStream(fullpath, FileMode.Create))
            {
                file.CopyTo(stream);
            }

            return file.FileName;
        }
        catch (Exception e)
        {
            return null;
        }
    }

    public bool DeleteFile(string folder, string filename)
    {

        try
        {
            var fullpath = Path.Combine(_hostEnvironment.WebRootPath, folder, filename);
            File.Delete(fullpath);
            return true;
        }
        catch (Exception e)
        {
            return false;
        }
    }
}