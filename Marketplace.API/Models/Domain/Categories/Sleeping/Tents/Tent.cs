namespace Marketplace.API.Models.Domain.Categories.Sleeping.Tents
{
    public class Tent : Sleeping
    {
        public int NumberOfPeople { get; set; }
        public int NumberOfDoors { get; set; }
        public TentBrand TentBrand { get; set; }
        public Guid TentBrandId { get; set; }
    }
}
