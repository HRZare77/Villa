﻿using System.ComponentModel.DataAnnotations;

namespace Villa.Models.Dto
{
    public class VillaNumberUpdateDTo
    {
        [Required]
        public int VillaNo { get; set; }
        [Required]
        public int VillaId { get; set; }
        public string? SpecialDetails { get; set; }

    }
}
