namespace TurismoApi.Requests
{
	public class HubRequest
	{
        public int HotelId { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public int NumberOfGuests { get; set; }
        public int NumberOfRooms { get; set; }
        public string? Currency { get; set; }
    }
}

