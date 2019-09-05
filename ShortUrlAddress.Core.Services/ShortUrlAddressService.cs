using ShortUrlAddress.Core.Contracts.Repository;
using ShortUrlAddress.Core.Contracts.Services;
using ShortUrlAddress.Core.Entities.Dtos.UserInfo.InputDtos;
using ShortUrlAddress.Core.Entities.Dtos.UserInfo.OutPutDtos;
using System;
using System.Threading.Tasks;

namespace ShortUrlAddress.Core.Services
{
    public class ShortUrlAddressService : IShortUrlAddressService
    {
        private readonly IUrlInfoRepository repository;
        private readonly IUrlValidationService urlValidation;

        public ShortUrlAddressService(IUrlInfoRepository repository, IUrlValidationService urlValidation)
        {
            this.repository = repository;
            this.urlValidation = urlValidation;
        }
        public async Task<Out_ShortUrlAddressDto> ConvertUrlToShortUrl(AddShortUrlDto model)
        {
            var Result = new Out_ShortUrlAddressDto();
            if (!urlValidation.IsValidateUrl(model.UrlAddress))
            {
                Result.ErrorMessage = "Url Is Not Valid";
                return Result;
            }

            var ShortCode = await repository.AddUrlInfo(model);
            Result.ShortUrlCode = ShortCode;
            Result.IsSuccess = true;
            return Result;
        }      

        public async Task<string> GetCompleteAddress(int ShortUrlCode)
        {
            var urladdress=await repository.GetCompeteUrl(ShortUrlCode);
            if (urladdress != null && urladdress.Trim().Length > 0)
                await repository.PlusViewCount(ShortUrlCode);
            return urladdress;
        }
    }
}
