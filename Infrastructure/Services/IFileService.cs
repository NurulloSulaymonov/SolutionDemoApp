using Microsoft.AspNetCore.Http;

namespace Infrastructure.Services;

public interface IFileService
{
    string CreateFile(string folder,IFormFile file);
    bool DeleteFile(string folder,string filename);
}