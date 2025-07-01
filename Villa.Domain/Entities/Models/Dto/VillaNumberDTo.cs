using System.ComponentModel.DataAnnotations;

namespace Villa.Models.Dto
{
    public class VillaNumberDTo
    {
        [Required]
        public int VillaNo { get; set; }
        public int VillaId { get; set; }
        public string SpecialDetails { get; set; }
        public VillaDTo Villa { get; set; }

    }
}
