namespace TurismoApi.Responses
{
	public class HotelLegsResponse
	{
		public IEnumerable<RoomRate>? HotelLegsRooms { get; set; }
	}

	public class RoomRate
	{
        public int Room { get; set; }
        public int Meal { get; set; }
        public bool CanCancel { get; set; }
        public double Price { get; set; }
    }
}

