using Microsoft.AspNetCore.Mvc;
using TrainReservationApp.Models;
using TrainReservationApp.ServiceLayer;

namespace TrainReservationApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReservationController : ControllerBase
    {
        private readonly ReservationService _reservationService;

        public ReservationController(ReservationService reservationService)
        {
            _reservationService = reservationService;
        }

        [HttpPost]
        public IActionResult Post([FromBody] ReservationRequest request)
        {
            var result = _reservationService.MakeReservation(request);
            return Ok(result);
        }
    }

}
