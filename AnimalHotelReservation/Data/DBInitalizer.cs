using AnimalHotelReservation.Models;

public class DBInitializer
{
    public static void Initialize(HotelContext context)
    {
        if (context.Rooms.Any())
        {
            return;   // DB has been seeded
        }

        var rooms = new Room[]
        {
            new Room{Number="101", Type="Indoor", Price=50, IsAvailable=true},
            new Room{Number="102", Type="Indoor", Price=75, IsAvailable=true},
            new Room{Number="103", Type="Outdoor", Price=75, IsAvailable=true},
        };
        context.Rooms.AddRange(rooms);
        context.SaveChanges();

        var reservations = new Reservation[]
        {
            new Reservation{Name="John Doe", CheckIn=DateTime.Now.AddDays(1), CheckOut=DateTime.Now.AddDays(5), RoomId=rooms[0].Id},
            new Reservation{Name="Jane Smith", CheckIn=DateTime.Now.AddDays(3), CheckOut=DateTime.Now.AddDays(6), RoomId=rooms[1].Id},
        };
        context.Reservations.AddRange(reservations);
        context.SaveChanges();
    }
}

