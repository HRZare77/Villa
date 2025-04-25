using System.ComponentModel.DataAnnotations;

namespace Villa.Models.Dto
{
    public class VillVillaNumberDToaDTo
    {
        [Required]
        public int VillaNo { get; set; }
        public string SpecialDetails { get; set; }

    }
}
