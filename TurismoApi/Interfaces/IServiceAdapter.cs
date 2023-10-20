namespace TurismoApi.Interfaces
{
    public interface IServiceAdapter<THubRequest, TServiceRequest, TServiceResponse, THubResponse>
    {
        TServiceRequest ConvertToServiceRequest(THubRequest request);
        THubResponse ConvertToHubResponse(TServiceResponse response);
    }


}

