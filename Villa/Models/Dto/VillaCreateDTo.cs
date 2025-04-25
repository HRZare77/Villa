using System.ComponentModel.DataAnnotations;

namespace Villa.Models.Dto
{
    public class VillaCreateDTo
    {
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }
        [Required]
        public int Occupancy { get; set; }
        [Required]
        public string ImageUrl { get; set; }
        [Required]
        public string Amenity { get; set; }
        [Required]
        public string Details { get; set; }
        [Required]
        public double Rate { get; set; }
        [Required]
        public int Sqft { get; set; }


    }
}
