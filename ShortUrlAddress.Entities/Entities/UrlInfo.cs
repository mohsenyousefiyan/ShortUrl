using System;
using System.Collections.Generic;
using System.Text;

namespace ShortUrlAddress.Core.Entities.Entities
{
    public class UrlInfo
    {
        public int Id { get; set; }
        public int ShortUrlCode { get; set; }
        public string ClientIPAddress { get; set; }
        public string UrlAddress { get; set; }
    }
}
