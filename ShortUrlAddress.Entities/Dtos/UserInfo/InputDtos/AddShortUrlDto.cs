using System;
using System.Collections.Generic;
using System.Text;

namespace ShortUrlAddress.Core.Entities.Dtos.UserInfo.InputDtos
{
    public class AddShortUrlDto
    {
        public string UrlAddress { get; set; }
        public string ClientIPAddress { get; set; }
    }
}
