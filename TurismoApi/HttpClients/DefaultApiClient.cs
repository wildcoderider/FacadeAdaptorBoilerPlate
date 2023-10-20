namespace TurismoApi.HttpClients
{
	public class DefaultApiClient : ClientBase
	{
        protected DefaultApiClient(IConfiguration config, IHttpContextAccessor? context = null) : base(context)
        {
            //Client.BaseAddress = new Uri(config.GetValue<string>("Endpoints:Api")); Default generic if you do not provide one.
        }
    }
}

