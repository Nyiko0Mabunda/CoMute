namespace CoMute.Web.Models
{
    public class CarPoolModel
    {
        public int Id { get; set; }
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }
        public string Origin { get; set; }
        public int DaysAvailabe { get; set; }
        public string Destination { get; set; }
        public string AvailableSeats { get; set; }
        public string OwnerLeader { get; set; }
        public string Notes { get; set; }

        public CarPoolModel()
        {

        }
    }
}
