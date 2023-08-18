namespace Marketplace.API.Models.Domain.Categories.Shoes
{
    /// <summary>
    /// Shoe brand - Nike, Adidas, etc.
    /// </summary>
    public class ShoeBrand
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
