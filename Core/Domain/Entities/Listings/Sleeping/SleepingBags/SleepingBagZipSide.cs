using Domain.Common;

namespace Domain.Entities.Listings.Sleeping.SleepingBags
{
    /// <summary>
    /// Side of zip - left, right, both
    /// 
    /// Has column for czech names of sides. 
    /// </summary>
    public class SleepingBagZipSide : IEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
