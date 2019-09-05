using ShortUrlAddress.Core.Contracts.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace ShortUrlAddress.Core.Services
{
    public class UrlValidationService : IUrlValidationService
    {
        public bool IsValidateUrl(string url)
        {
            if (url != null && url.Trim().Length > 0)
                return true;

            return false;

            //string Pattern = @"/(http|ftp|https)://[\w-]+(\.[\w-]+)+([\w.,@?^=%&:/~+#-]*[\w@?^=%&/~+#-])?/";
            //if (!Regex.IsMatch(url, Pattern))
            //    return false ;
            //return true;
        }
    }
}
