namespace Event_Management.Model
{
    public class GuestAttendance
    {
        public string? EventName { get; set; }
        public double Invited { get; set; }
        public int Confirmed { get; set; }
        public int Declined { get; set; }
        public int Pending { get; set; }
        public double ResponseRate
        {
            get
            {
                if(Invited == 0) return 0;
                return ((Confirmed + Declined) / Invited) * 100;
            }
        }
    }
}
