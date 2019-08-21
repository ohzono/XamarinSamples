using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PrismRxApi.Model.Api
{
    public interface ApiGet<T>
    {
        Task<T> GetDataAsync();
    }
}
