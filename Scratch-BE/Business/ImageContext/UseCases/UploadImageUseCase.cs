using System.Threading.Tasks;
using Boundary.ImageContext.Request;
using Boundary.ImageContext.Response;
using Business.ImageContext.Settings;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Kernel;

namespace Business.ImageContext.UseCases
{
    public class UploadImageUseCase : IHandle<UploadImageRequest, UploadImageResponse>
    {
        private Cloudinary _cloudinary;
        private string _imageFolderName;
        public UploadImageUseCase(CloudinaryAccountConfiguration settings)
        {
            Account account = new Account(
                settings.CloudName,
                settings.ApiKey,
                settings.ApiSicret
            );
            _cloudinary = new Cloudinary(account);
            _imageFolderName = settings.ImageFolder;
        }
        public async Task<UploadImageResponse> HandleAsync(UploadImageRequest request)
        {
            var imageId = System.Guid.NewGuid().ToString();
            var uploadParams = new ImageUploadParams
            {
                File = new FileDescription(imageId,request.fileStream),
                PublicId = _imageFolderName + imageId,
                Overwrite = true,
            };
            var uploadResult = _cloudinary.Upload(uploadParams);
            return new UploadImageResponse{
                ImageId = uploadResult.Uri.ToString()
            };
        }
    }
}