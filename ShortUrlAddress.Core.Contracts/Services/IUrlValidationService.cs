using System;
using System.Collections.Generic;
using System.Text;

namespace ShortUrlAddress.Core.Contracts.Services
{
   public interface IUrlValidationService
    {
        Boolean IsValidateUrl(string url);
    }
}
