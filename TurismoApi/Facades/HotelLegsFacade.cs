using System;
using TurismoApi.HttpClients;
using TurismoApi.HttpClients.Interfaces;
using TurismoApi.Interfaces;
using TurismoApi.Requests;
using TurismoApi.Responses;

namespace TurismoApi.Facades
{
	public class HotelLegsFacade : IServiceFacade<HotelLegsFacade>
	{

        private readonly IServiceAdapter<HubRequest, HotelLegsRequest, HotelLegsResponse, HubResponse> _adapter;
        private readonly IHotelLegsClient _hotelLegsClient;

        public HotelLegsFacade(IServiceAdapter<HubRequest, HotelLegsRequest, HotelLegsResponse, HubResponse> adapter, IHotelLegsClient hotelLegsClient)
        {
            _adapter = adapter;
            _hotelLegsClient = hotelLegsClient;
        }

        public async Task<HubResponse> Search(HubRequest request)
        {
            var serviceRequest = _adapter.ConvertToServiceRequest(request);
            var serviceResponse = await CallService(serviceRequest);
            return _adapter.ConvertToHubResponse(serviceResponse);
        }

        private async Task<HotelLegsResponse> CallService(HotelLegsRequest request)
        {

            // Here you can inject the HotelLegsHttpClient which will make the call to the service.

            //var response = await _hotelLegsClient.Search(); (Pseudocode)

            var hotelLegsResponse = new HotelLegsResponse
            {
                HotelLegsRooms = new List<RoomRate>
                {
                    new RoomRate {
                    Room = 1,
                    Meal = 1,
                    CanCancel = false,
                    Price = 123.48
                },
                new RoomRate {
                    Room = 2,
                    Meal = 1,
                    CanCancel = true,
                    Price = 148.25
                }
            }};

            return hotelLegsResponse;
        }

    }

    
}

