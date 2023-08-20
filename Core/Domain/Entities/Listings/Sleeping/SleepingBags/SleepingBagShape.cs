using Domain.Common;

namespace Domain.Entities.Listings.Sleeping.SleepingBags
{
    /// <summary>
    /// Shape of sleeping bag - mummy, rectangular, underquilt, overquilt, etc.
    ///
    /// Column for czech localisation. 
    /// </summary>
    public class SleepingBagShape : IEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
