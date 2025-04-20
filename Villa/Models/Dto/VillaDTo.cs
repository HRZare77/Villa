using System.ComponentModel.DataAnnotations;

namespace Villa.Models.Dto
{
    public class VillaDTo
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }
    }
}
