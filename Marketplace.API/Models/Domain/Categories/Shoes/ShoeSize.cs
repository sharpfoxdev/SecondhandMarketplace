namespace Marketplace.API.Models.Domain.Categories.Shoes
{
    /// <summary>
    /// Shoe size, will probably use different sizing types (EU, US etc.), because
    /// the sizes are different for different manufacturers
    /// </summary>
    public class ShoeSize
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
