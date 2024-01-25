using Microsoft.AspNetCore.Mvc;
using TrybeHotel.Models;
using TrybeHotel.Repository;
using Microsoft.AspNetCore.Authorization; 
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace TrybeHotel.Controllers
{
    [ApiController]
    [Route("room")]
    public class RoomController : Controller
    {
        private readonly IRoomRepository _repository;
        public RoomController(IRoomRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("{HotelId}")]
        public IActionResult GetRoom(int HotelId){
            try
            {
                var roomsDto = _repository.GetRooms(HotelId);
                return Ok(roomsDto);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "Erro ao obter quartos", error = ex.Message });
            }
        }

         [HttpPost]
         [Authorize(Policy = "Admin")] 
         [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public IActionResult PostRoom([FromBody] Room room){
            try
            {
                var addedRoomDto = _repository.AddRoom(room);
                return CreatedAtAction(nameof(PostRoom), addedRoomDto);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "Erro ao adicionar quarto", error = ex.Message });
            }
        }

        // 8. Desenvolva o endpoint DELETE /room/:roomId
        [HttpDelete("{RoomId}")]
        [Authorize(Policy = "Admin")] 
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public IActionResult Delete(int RoomId)
        {
            try
            {
                _repository.DeleteRoom(RoomId);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "Erro ao excluir quarto", error = ex.Message });
            }
        }
    }
}