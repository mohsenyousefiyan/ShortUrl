using ShortUrlAddress.Core.Entities.Dtos.UserInfo.InputDtos;
using ShortUrlAddress.Core.Entities.Dtos.UserInfo.OutPutDtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ShortUrlAddress.Core.Contracts.Services
{
    public interface IShortUrlAddressService
    {      
        Task<Out_ShortUrlAddressDto> ConvertUrlToShortUrl(AddShortUrlDto model);
        Task<string> GetCompleteAddress(int ShortUrlCode);
    }
}
