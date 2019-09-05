using Microsoft.EntityFrameworkCore;
using ShortUrlAddress.Core.Contracts.Repository;
using ShortUrlAddress.Core.Entities.Dtos.UserInfo.InputDtos;
using ShortUrlAddress.Core.Entities.Entities;
using ShortUrlAddress.Infrastructures.DAL.EfCore.Context;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

namespace ShortUrlAddress.Infrastructures.DAL.EfCore.Repository
{
    public class UrlInfoRepository : IUrlInfoRepository
    {
        private readonly ApplicationDbContext dbContext;
        
        public UrlInfoRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<int> AddUrlInfo(AddShortUrlDto urlDto)
        {
            var AddedObject = new UrlInfo()
            {
                ClientIPAddress = urlDto.ClientIPAddress,
                ShortUrlCode =await GetLastShortCode(),
                UrlAddress = urlDto.UrlAddress
            };

            dbContext.UrlInfos.Add(AddedObject);
            await SaveChangesAsync();
            return AddedObject.ShortUrlCode;
        }

        public async Task<string> GetCompeteUrl(int shorcode)
        {
            var urladdress=await dbContext.UrlInfos.Where(x => x.ShortUrlCode == shorcode)
                .Select(x => x.UrlAddress)
                .FirstOrDefaultAsync();

            return urladdress;
        }

        public async Task<int> GetLastShortCode()
        {
            int? LastGenerationCode = await dbContext.UrlInfos.MaxAsync(x =>(int?) x.ShortUrlCode);
            if (!LastGenerationCode.HasValue)
                LastGenerationCode = 1000;
            LastGenerationCode++;
            return LastGenerationCode.Value;
        }

        public async Task PlusViewCount(int shorcode)
        {
            var urlitem = await dbContext.UrlInfos.Where(x => x.ShortUrlCode == shorcode).FirstOrDefaultAsync();
            if(urlitem!=null)
            {
                dbContext.Entry(urlitem).Property("ViewCount").CurrentValue = Convert.ToInt32(dbContext.Entry(urlitem).Property("ViewCount").CurrentValue)+1;
                await SaveChangesAsync();
            }
        }

        public async Task SaveChangesAsync()
        {                       
            await dbContext.SaveChangesAsync();
        }
    }
}
