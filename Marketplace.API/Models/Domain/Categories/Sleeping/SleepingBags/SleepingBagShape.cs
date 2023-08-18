namespace Marketplace.API.Models.Domain.Categories.Sleeping.SleepingBags
{
    /// <summary>
    /// Shape of sleeping bag - mummy, rectangular, underquilt, overquilt, etc.
    ///
    /// Column for czech localisation. 
    /// </summary>
    public class SleepingBagShape
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
