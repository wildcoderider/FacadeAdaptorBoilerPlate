namespace TurismoApi.HttpClients.Interfaces
{
	public interface IClientBase
	{
		Task<T> GetData<T>(string url);
        Task<string> GetDataAsString<T>(string url);
        Task<TResponse> PostData<TInput, TResponse>(string url, TInput request);
        Task<TResponse> PostData<TResponse>(string url);
        Task<(Stream, string)> PostDataStream<TInput, Tuple>(string url, TInput request);
    }
}

