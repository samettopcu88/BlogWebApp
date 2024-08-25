using ENTITY.Enums;
using ENTITY.Models.Images;
using Microsoft.AspNetCore.Http;

namespace SERVICE.Helpers.Images
{
    public interface IImageHelper
    {
        Task<ImageUploadedModel> Upload(string name, IFormFile imageFile,ImageType imageType, string folderName = null);
        void Delete(string imageName);
        Task Upload(string title, IFormFile photo, ImageType post);
    }
}
