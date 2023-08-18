namespace Marketplace.API.Models.Domain.Categories.CommonProperties
{
    /// <summary>
    /// Currently just a czech name of color, might add more columns with different language mutations
    /// and a hex code of color or some other representation. 
    /// </summary>
    public class Color
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
