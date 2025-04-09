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
                Name = "Royal Villa"
            },
            new VillaDTo
            {
                Id = 2,
                Name = "Luxury Villa"
            },
            new VillaDTo
            {
                Id = 3,
                Name = "Beachfront Villa"
            }
        };
    }
}
