using ECommerceApp.Application.Abstractions.Storage;
using Microsoft.AspNetCore.Http;

namespace ECommerceApp.Infrastructure.Services.Storage.Azure
{
    public class AzureStorage : IStorage
    {
        public Task DeleteAsync(string pathOrContainerName, string fileName)
        {
            throw new NotImplementedException();
        }

        public Task<List<string>> GetFiles(string fileName)
        {
            throw new NotImplementedException();
        }

        public bool HasFile(string pathOrContainerName, string fileName)
        {
            throw new NotImplementedException();
        }

        public Task<List<(string fileName, string pathOrContainer)>> UploadAsync(string pathOrContainerName, IFormFileCollection formFiles)
        {
            throw new NotImplementedException();
        }
    }
}
