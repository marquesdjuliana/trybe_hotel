using TrybeHotel.Models;
using TrybeHotel.Dto;

namespace TrybeHotel.Repository
{
    public class HotelRepository : IHotelRepository
    {
        protected readonly ITrybeHotelContext _context;
        public HotelRepository(ITrybeHotelContext context)
        {
            _context = context;
        }

        public IEnumerable<HotelDto> GetHotels()
        {
            try
            {
                var hotels = _context.Hotels
                    .Select(h => new HotelDto
                    {
                        HotelId = h.HotelId,
                        Name = h.Name,
                        Address = h.Address,
                        CityId = h.CityId,
                        CityName = h.City.Name,
                        State = h.City.State
                    })
                    .ToList();

                return hotels;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao obter hotéis", ex);
            }
        }
        
        public HotelDto AddHotel(Hotel hotel)
        {
            try
            {
                _context.Hotels.Add(hotel);
                _context.SaveChanges();

                var addedHotelDto = _context.Hotels
                    .Where(h => h.HotelId == hotel.HotelId)
                    .Select(h => new HotelDto
                    {
                        HotelId = h.HotelId,
                        Name = h.Name,
                        Address = h.Address,
                        CityId = h.CityId,
                        CityName = h.City.Name,
                        State = h.City.State,
                    })
                    .FirstOrDefault();

                return addedHotelDto;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao adicionar hotel", ex);
            }
        }
    }
}