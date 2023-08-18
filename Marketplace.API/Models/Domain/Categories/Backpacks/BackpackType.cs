namespace Marketplace.API.Models.Domain.Categories.Backpacks
{
    /// <summary>
    /// Backpack type - backpack, bag, pouch, etc. 
    /// 
    /// Is used as a property in Backpack.cs, instead of making further children for
    /// Backpack, that wouldn't add any new properties.
    /// 
    /// For now there is a column with czech names, but can add more columns 
    /// with different language mutations. 
    /// </summary>
    public class BackpackType
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
