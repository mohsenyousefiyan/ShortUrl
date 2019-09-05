using ShortUrlAddress.Core.Entities.Dtos.BaseDtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShortUrlAddress.Core.Entities.Dtos.UserInfo.OutPutDtos
{
    public class Out_ShortUrlAddressDto:BaseOutPutDto
    {
        public int ShortUrlCode { get; set; }
    }
}
