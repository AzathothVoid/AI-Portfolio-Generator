using System;
using System.Collections.Generic;
using System.Text;

namespace Nauman.AIPortfolioGenerator.Application.Responses
{
    public class CustomQueryResponse<T> : BaseResponse where T : class
    {
        public T Data { get; set; }
    }
}
