using AnimalHotelReservation.Models;

internal class HomeViewModel
{
    public List<Room> AvailableRooms { get; set; }
    public List<Reservation> UpcomingReservations { get; set; }
}