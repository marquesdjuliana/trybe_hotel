using Microsoft.AspNetCore.Mvc;
using TrybeHotel.Models;
using TrybeHotel.Repository;
using TrybeHotel.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace TrybeHotel.Controllers
{
    [ApiController]
    [Route("hotel")]
    public class HotelController : Controller
    {
        private readonly IHotelRepository _repository;

        public HotelController(IHotelRepository repository)
        {
            _repository = repository;
        }
        
        [HttpGet]
        public IActionResult GetHotels(){
            try
            {
                var hotels = _repository.GetHotels();
                return Ok(hotels);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno: {ex.Message}");
            }
        }

        [HttpPost]
        [Authorize(Policy = "Admin")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public IActionResult PostHotel([FromBody] Hotel hotel){
            try
            {
                var addedHotelDto = _repository.AddHotel(hotel);
                return CreatedAtAction(nameof(PostHotel), addedHotelDto);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "Erro ao adicionar hotel", error = ex.Message });
            }
        }


    }
}