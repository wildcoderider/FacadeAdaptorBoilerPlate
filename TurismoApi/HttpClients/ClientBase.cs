using TurismoApi.HttpClients.Interfaces;

namespace TurismoApi.HttpClients
{
	public class ClientBase : IDefaultApiClient
	{
        protected readonly HttpClient Client;

        protected ClientBase(IHttpContextAccessor? context = null)
        {
            Client = new HttpClient();
        }

        public Task<T> GetData<T>(string url)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetDataAsString<T>(string url)
        {
            throw new NotImplementedException();
        }

        public Task<TResponse> PostData<TInput, TResponse>(string url, TInput request)
        {
            throw new NotImplementedException();
        }

        public Task<TResponse> PostData<TResponse>(string url)
        {
            throw new NotImplementedException();
        }

        public Task<(Stream, string)> PostDataStream<TInput, Tuple>(string url, TInput request)
        {
            throw new NotImplementedException();
        }
    }
}

