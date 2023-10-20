using TurismoApi.Requests;
using TurismoApi.Responses;

namespace TurismoApi.Interfaces
{

    public interface IServiceFacade<T>
    {
        Task<HubResponse> Search(HubRequest request);
    }
}

