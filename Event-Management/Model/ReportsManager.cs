using System.Collections.ObjectModel;

namespace Event_Management.Model
{
    public class ReportsManager
    {
        public IObservable<EventSummary> Events { get; set; }

        public ReportsManager() { }

        //public async Task<ObservableCollection<EventSummary>> GetAllEventSummary()
        //{
        //    var events = new ObservableCollection<EventSummary>();
        //    var db = DatabaseManager.Instance;

        //    var query = "SELECT event_name, status, "
        //}
    }
}
