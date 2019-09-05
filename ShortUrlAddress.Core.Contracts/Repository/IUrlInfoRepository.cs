using ShortUrlAddress.Core.Entities.Dtos.UserInfo.InputDtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ShortUrlAddress.Core.Contracts.Repository
{
    public interface IUrlInfoRepository
    {
        Task<int> AddUrlInfo(AddShortUrlDto urlDto);
        Task<int> GetLastShortCode();
        Task<string> GetCompeteUrl(int shorcode);
        Task PlusViewCount(int shorcode);
        Task SaveChangesAsync();
    }
}
