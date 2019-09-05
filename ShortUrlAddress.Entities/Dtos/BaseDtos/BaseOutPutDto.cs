using System;
using System.Collections.Generic;
using System.Text;

namespace ShortUrlAddress.Core.Entities.Dtos.BaseDtos
{
    public class BaseOutPutDto
    {
        public Boolean IsSuccess { get; set; }
        public string ErrorMessage { get; set; }
    }
}
