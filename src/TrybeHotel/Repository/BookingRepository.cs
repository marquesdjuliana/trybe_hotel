using TrybeHotel.Models;
using TrybeHotel.Dto;
using Microsoft.EntityFrameworkCore;

namespace TrybeHotel.Repository
{
    public class BookingRepository : IBookingRepository
    {
        protected readonly ITrybeHotelContext _context;
        public BookingRepository(ITrybeHotelContext context)
        {
            _context = context;
        }

        public BookingResponse Add(BookingDtoInsert booking, string email)
        {
            var user = _context.Users.FirstOrDefault(u => u.Email == email)
               ?? throw new InvalidDataException("User not found!");

            var newBooking = new Booking
            {
                CheckIn = booking.CheckIn,
                CheckOut = booking.CheckOut,
                GuestQuant = booking.GuestQuant,
                UserId = user.UserId,
                RoomId = booking.RoomId,
            };

            _context.Bookings.Add(newBooking);
            _context.SaveChanges();

            var savedBooking = _context.Bookings
                .Include(b => b.Room)
                    .ThenInclude(r => r.Hotel)
                        .ThenInclude(h => h.City)
                .FirstOrDefault(b => b.BookingId == newBooking.BookingId);

            return MapBookingToResponse(savedBooking);
            
        }

        public BookingResponse GetBooking(int bookingId, string email)
        {
            var booking = _context.Bookings
                .Where(b => b.BookingId == bookingId && b.User.Email == email)
                .Select(b => new BookingResponse
                {
                    BookingId = b.BookingId,
                    CheckIn = b.CheckIn,
                    CheckOut = b.CheckOut,
                    GuestQuant = b.GuestQuant,
                    Room = new RoomDto
                    {
                        RoomId = b.Room.RoomId,
                        Name = b.Room.Name,
                        Capacity = b.Room.Capacity,
                        Image = b.Room.Image,
                        Hotel = new HotelDto
                        {
                            HotelId = b.Room.HotelId,
                            Name = b.Room.Hotel.Name,
                            Address = b.Room.Hotel.Address,
                            CityId = b.Room.Hotel.CityId,
                            CityName = b.Room.Hotel.City.Name,
                            State = b.Room.Hotel.City.State
                        }
                    }
                })
                .FirstOrDefault();

            if (booking == null)
            {
                return null;
            }

            return booking;
        }

        public Room GetRoomById(int RoomId)
        {
            throw new NotImplementedException();
        }


        private static BookingResponse MapBookingToResponse(Booking booking)
        {
            return new BookingResponse
            {
                BookingId = booking.BookingId,
                CheckIn = booking.CheckIn,
                CheckOut = booking.CheckOut,
                GuestQuant = booking.GuestQuant,
                Room = new RoomDto
                {
                    RoomId = booking.Room.RoomId,
                    Name = booking.Room.Name,
                    Capacity = booking.Room.Capacity,
                    Image = booking.Room.Image,
                    Hotel = new HotelDto
                    {
                        HotelId = booking.Room.Hotel.HotelId,
                        Name = booking.Room.Hotel.Name,
                        Address = booking.Room.Hotel.Address,
                        CityId = booking.Room.Hotel.CityId,
                        CityName = booking.Room.Hotel.City.Name,
                        State = booking.Room.Hotel.City.State
                    }
                }
            };

    }

}
}