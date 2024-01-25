namespace TrybeHotel.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Booking {
        [Key]
        public int BookingId { get; set; }

        [Required]
        public DateTime CheckIn { get; set; }

        [Required]
        public DateTime CheckOut { get; set; }

        [Required]
        public int GuestQuant { get; set; }

        [ForeignKey("UserId")]
        public int UserId { get; set; }

        [ForeignKey("RoomId")]
        public int RoomId { get; set; }

        public virtual User? User { get; set; }
        public virtual Room? Room { get; set; }
}
