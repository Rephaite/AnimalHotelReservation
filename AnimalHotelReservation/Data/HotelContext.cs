using AnimalHotelReservation.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

public class HotelContext : DbContext
{
    public HotelContext(DbContextOptions<HotelContext> options) : base(options) { }

    public DbSet<Room> Rooms { get; set; }
    public DbSet<Reservation> Reservations { get; set; }
}
