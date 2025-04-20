using Villa.Models.Dto;

namespace Villa.Data
{
    public static class VillaStore
    {
        public static List<VillaDTo> villaList = new List<VillaDTo>
        {
            new VillaDTo
            {
                Id = 1,
                Name = "Royal Villa",
                Occupancy = 2,
                Sqft = 500
            },
            new VillaDTo
            {
                Id = 2,
                Name = "Luxury Villa",
                Occupancy = 4,
                Sqft = 800
            },
            new VillaDTo
            {
                Id = 3,
                Name = "Beachfront Villa",
                Occupancy = 6,
                Sqft = 1200
            }
        };
    }
}
