namespace Domain.Entities.Listings.Cooking.Stoves
{
    public class Stove : Cooking
    {
        public StoveBrand StoveBrand { get; set; }
        public Guid StoveBrandId { get; set; }
        public StoveFuelType StoveFuelType { get; set; }
        public Guid StoveFuelTypeId { get; set; }
    }
}
