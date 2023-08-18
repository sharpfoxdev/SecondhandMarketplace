namespace Marketplace.API.Models.Domain.Categories.CommonProperties
{
    /// <summary>
    /// State of the item - new, used, good, ...
    /// 
    /// Columns for the czech mutation
    /// </summary>
    public class StateOfItem
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
