namespace TrainReservationApp.Models
{
    public class ReservationResponse
    {
        public bool RezervasyonYapilabilir { get; set; }
        public List<VagonYerlesim> YerlesimAyrinti { get; set; }
    }

    public class VagonYerlesim
    {
        public string VagonAdi { get; set; }
        public int KisiSayisi { get; set; }
    }
}
