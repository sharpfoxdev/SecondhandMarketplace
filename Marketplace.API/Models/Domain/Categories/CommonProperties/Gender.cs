namespace Marketplace.API.Models.Domain.Categories.CommonProperties
{

    /// <summary>
    /// Male, female, unisex, kids, currently just the czech mutation. 
    /// 
    /// TODO Beware of filtering
    /// </summary>
    public class Gender
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
