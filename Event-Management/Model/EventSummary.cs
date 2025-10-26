namespace Event_Management.Model
{
    public class EventSummary
    {
        public string EventName { get; set; }
        public string Status { get; set; }
        public int Guests { get; set; }
        public double Budget { get; set; }
        public double Spent { get; set; }
        public double Remaining => Budget - Spent;
    }
}
