using Microsoft.AspNetCore.Http;

namespace ECommerceApp.Application.Abstractions.Storage
{
    public interface IStorage
    {
        Task<List<(string fileName, string pathOrContainer)>> UploadAsync(string pathOrContainerName, IFormFileCollection formFiles);
        Task DeleteAsync(string pathOrContainerName, string fileName);
        Task<List<string>> GetFiles(string fileName);
        bool HasFile(string pathOrContainerName, string fileName);
    }
}
