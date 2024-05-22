using Microsoft.AspNetCore.Http;

namespace ECommerceApp.Application.Services
{
    public interface IFileService
    {
        Task UploadAsync(IFormFile file, string folderName);
    }
}
