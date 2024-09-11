using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

public class HomeController : Controller
{
    private readonly HotelContext _context;

    public HomeController(HotelContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {

        var availableRooms = await _context.Rooms
            .Where(r => r.IsAvailable)
            .ToListAsync();

        var upcomingReservations = await _context.Reservations
            .Include(r => r.Room)
            .Where(r => r.CheckIn >= DateTime.Now)
            .OrderBy(r => r.CheckIn)
            .ToListAsync();

        var model = new HomeViewModel
        {
            AvailableRooms = availableRooms,
            UpcomingReservations = upcomingReservations
        };

        return View(model);
    }
}
