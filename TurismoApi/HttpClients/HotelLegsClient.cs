using TurismoApi.HttpClients.Interfaces;

namespace TurismoApi.HttpClients
{
	public class HotelLegsClient : DefaultApiClient, IHotelLegsClient
	{
        public HotelLegsClient(IConfiguration config, IHttpContextAccessor? context = null) : base(config, context) {

            Client.BaseAddress = new Uri("http://api.hotellegs.com");
        }
    }
}

