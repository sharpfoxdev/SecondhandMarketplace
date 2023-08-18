namespace Marketplace.API.Models.Domain.Categories.Sleeping.SleepingBags
{
    /// <summary>
    /// Side of zip - left, right, both
    /// 
    /// Has column for czech names of sides. 
    /// </summary>
    public class SleepingBagZipSide
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
