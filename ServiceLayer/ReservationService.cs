using TrainReservationApp.Models;

namespace TrainReservationApp.ServiceLayer
{
    public class ReservationService
    {
        public ReservationResponse MakeReservation(ReservationRequest request)
        {
            var response = new ReservationResponse { YerlesimAyrinti = new List<VagonYerlesim>() };
            int kisiSayisi = request.RezervasyonYapilacakKisiSayisi;

            foreach (var vagon in request.Tren.Vagonlar)
            {
                int mevcutKoltukSayisi = vagon.Kapasite - vagon.DoluKoltukAdet;
                int maxKoltukSayisi = (int)(vagon.Kapasite * 0.7);  // %70 kuralı
                int kullanilabilirKoltukSayisi = maxKoltukSayisi - vagon.DoluKoltukAdet;

                if (kisiSayisi <= 0)
                    break;

                if (kullanilabilirKoltukSayisi > 0)
                {
                    int yerlesecekKisiSayisi = Math.Min(kisiSayisi, kullanilabilirKoltukSayisi);
                    response.YerlesimAyrinti.Add(new VagonYerlesim { VagonAdi = vagon.Ad, KisiSayisi = yerlesecekKisiSayisi });
                    kisiSayisi -= yerlesecekKisiSayisi;
                }
            }

            response.RezervasyonYapilabilir = kisiSayisi == 0;

            if (!response.RezervasyonYapilabilir)
            {
                response.YerlesimAyrinti.Clear();  // Rezervasyon mümkün değilse listeyi boşalt
            }

            return response;
        }
    }

}
