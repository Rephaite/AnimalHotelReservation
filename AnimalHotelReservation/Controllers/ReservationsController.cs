using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

public class ReservationsController : Controller
{
    private readonly HotelContext _context;

    public ReservationsController(HotelContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetReservations()
    {
        var reservations = await _context.Reservations
            .Select(r => new
            {
                id = r.Id,
                title = r.Name,
                start = r.CheckIn.ToString("yyyy-MM-dd"),
                end = r.CheckOut.ToString("yyyy-MM-dd")
            })
            .ToListAsync();

        return Json(reservations);
    }

    [HttpPost]
    public async Task<IActionResult> CreateReservation([FromBody] Reservation reservation)
    {
        if (ModelState.IsValid)
        {
            var room = await _context.Rooms.FindAsync(reservation.RoomId);
            if (room == null || !room.IsAvailable)
            {
                return Json(new { success = false, message = "Room is not available." });
            }

            _context.Reservations.Add(reservation);
            await _context.SaveChangesAsync();

            // room.IsAvailable = false;
            // await _context.SaveChangesAsync();

            return Json(new { success = true });
        }

        return Json(new { success = false, message = "Invalid data." });
    }
}
