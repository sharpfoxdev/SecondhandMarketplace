using Domain.Common;

namespace Domain.Entities.Listings.CommonProperties
{
    /// <summary>
    /// State of the item - new, used, good, ...
    /// 
    /// Columns for the czech mutation
    /// </summary>
    public class StateOfItem : IEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
