using AnimalHotelReservation.Models;
using System.ComponentModel.DataAnnotations;

public class Reservation
{
    public int Id { get; set; }

    [Required]
    public string Name { get; set; }

    [Required]
    [DataType(DataType.Date)]
    public DateTime CheckIn { get; set; }

    [Required]
    [DataType(DataType.Date)]
    public DateTime CheckOut { get; set; }

    [Required]
    public int RoomId { get; set; }
    public Room Room { get; set; }
}
