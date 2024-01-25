using TrybeHotel.Models;
using TrybeHotel.Dto;
using Microsoft.EntityFrameworkCore;


namespace TrybeHotel.Repository
{
    public class RoomRepository : IRoomRepository
    {
        protected readonly ITrybeHotelContext _context;
        public RoomRepository(ITrybeHotelContext context)
        {
            _context = context;
        }

        public IEnumerable<RoomDto> GetRooms(int HotelId)
        {
            try
            {
                var roomsDto = _context.Rooms
                    .Where(r => r.HotelId == HotelId)
                    .Select(r => new RoomDto
                    {
                        RoomId = r.RoomId,
                        Name = r.Name,
                        Capacity = r.Capacity,
                        Image = r.Image,
                        Hotel = new HotelDto
                        {
                            HotelId = r.Hotel.HotelId,
                            Name = r.Hotel.Name,
                            Address = r.Hotel.Address,
                            CityId = r.Hotel.CityId,
                            CityName = r.Hotel.City.Name
                        }
                    })
                    .ToList();

                return roomsDto;
            }
                catch (Exception ex)
            {
                throw new Exception("Erro ao obter quartos", ex);
            }
        }

        public RoomDto AddRoom(Room room) {
             try
            {
                _context.Rooms.Add(room);
                _context.SaveChanges();

                var addedRoom = _context.Rooms
                    .Include(r => r.Hotel)
                    .ThenInclude(h => h.City)
                    .FirstOrDefault(r => r.RoomId == room.RoomId);

                var roomDto = addedRoom ?? throw new Exception("Quarto não localizado após a adição");

                return new RoomDto
                {
                    RoomId = roomDto.RoomId,
                    Name = roomDto.Name,
                    Capacity = roomDto.Capacity,
                    Image = roomDto.Image,
                    Hotel = new HotelDto
                    {
                        HotelId = roomDto.Hotel.HotelId,
                        Name = roomDto.Hotel.Name,
                        Address = roomDto.Hotel.Address,
                        CityId = roomDto.Hotel.CityId,
                        CityName = roomDto.Hotel.City.Name
                    }
                };
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao adicionar quarto", ex);
            }
        }

        public void DeleteRoom(int RoomId) {
            try
            {
                var roomToDelete = _context.Rooms.Find(RoomId);
                if (roomToDelete != null)
                {
                    _context.Rooms.Remove(roomToDelete);
                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao excluir quarto", ex);
            }

        }
    }
}