﻿using System.ComponentModel.DataAnnotations;

namespace Villa.Models.Dto
{
    public class VillaUpdateDTo
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }
        public int Occupancy { get; set; }
        public string ImageUrl { get; set; }
        public string Amenity { get; set; }
        public string Details { get; set; }
        public double Rate { get; set; }
        public int Sqft { get; set; }


    }
}
