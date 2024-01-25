namespace TrybeHotel.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class City 
    {

        [Key] 
        public int CityId { get; set; }

        [Required]
        public string? Name { get; set; }

        [Required]
        public string? State { get; set; }

        public ICollection<Hotel>? Hotels { get; set; }
    }
}