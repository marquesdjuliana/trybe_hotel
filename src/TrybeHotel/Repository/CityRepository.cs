using TrybeHotel.Models;
using TrybeHotel.Dto;

namespace TrybeHotel.Repository
{
    public class CityRepository : ICityRepository
    {
        protected readonly ITrybeHotelContext _context;
        public CityRepository(ITrybeHotelContext context)
        {
            _context = context;
        }

        public IEnumerable<CityDto> GetCities()
        {
           var cities = _context.Cities.Select(c => new CityDto {
                CityId = c.CityId,
                Name = c.Name
            }).ToList();

            return cities;
        }

        public CityDto AddCity(City city)
        {
            _context.Cities.Add(city);
            _context.SaveChanges();

            var cityDto = new CityDto {
                CityId = city.CityId,
                Name = city.Name,
                 State = city.State
            };

            return cityDto;
        }

        public CityDto UpdateCity(City city)
        {
           throw new NotImplementedException();
        }

    }
}