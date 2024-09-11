using AnimalHotelReservation.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

public class RoomsController : Controller
{
    private readonly HotelContext _context;

    public RoomsController(HotelContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        var rooms = _context.Rooms.ToList();
        return View(rooms);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(Room room)
    {
        if (ModelState.IsValid)
        {
            room.IsAvailable = true;
            _context.Rooms.Add(room);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        return View(room);
    }

    [HttpGet]
    public async Task<IActionResult> GetAvailableRooms()
    {
        var rooms = await _context.Rooms
            .Where(r => r.IsAvailable)
            .Select(r => new { r.Id, r.Number, r.Type })
            .ToListAsync();

        return Json(rooms);
    }

}


