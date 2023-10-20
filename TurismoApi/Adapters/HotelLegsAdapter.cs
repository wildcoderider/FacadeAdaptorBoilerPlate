using TurismoApi.Interfaces;
using TurismoApi.Requests;
using TurismoApi.Responses;

namespace TurismoApi.Adapters
{
	public class HotelLegsAdapter : IServiceAdapter<HubRequest, HotelLegsRequest, HotelLegsResponse, HubResponse>
    {
    
        public HotelLegsRequest ConvertToServiceRequest(HubRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(HubRequest));

            //if (request.CheckOut <= request.CheckIn) Disabled rule for testing.
             //   throw new ArgumentException("CheckOut date must be greater than CheckIn date");

            return new HotelLegsRequest
            {
                Hotel = request.HotelId,
                CheckInDate = request.CheckIn,
                NumberOfNights = (request.CheckOut - request.CheckIn).Days,
                Guests = request.NumberOfGuests,
                Rooms = request.NumberOfRooms,
                Currency = request.Currency
            };
            
        }

        public HubResponse ConvertToHubResponse(HotelLegsResponse response)
        {

            if (response == null || response.HotelLegsRooms == null)
                throw new ArgumentNullException(nameof(HotelLegsResponse));

            var rooms = new List<HubResponse.Room>();

            var groupedRoomRates = response.HotelLegsRooms
                .GroupBy(r => r.Room)
                .ToList();

            foreach (var group in groupedRoomRates)
            {
                var rates = group.Select(r => new HubResponse.Rate
                {
                    MealPlanId = r.Meal,
                    IsCancellable = r.CanCancel,
                    Price = r.Price
                }).ToList();

                rooms.Add(new HubResponse.Room
                {
                    RoomId = group.Key,
                    Rates = rates
                });
            }

            return new HubResponse { Rooms = rooms }; 
            
        }
    }
}

