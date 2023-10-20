namespace TurismoApi.Responses
{
	public class HubResponse
	{

        public List<Room>? Rooms { get; set; }

        public class Rate
        {
            public int MealPlanId { get; set; }
            public bool IsCancellable { get; set; }
            public double Price { get; set; }
        }

        public class Room
        {
            public int RoomId { get; set; }
            public List<Rate>? Rates { get; set; }
        }

    }
}

