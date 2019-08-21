using System.Threading.Tasks;

namespace PrismRxApi.Model.Api
{
    public interface ApiPut<T>
    {
        Task PutDataAsync(T t);
    }
}
