namespace Marketplace.API.Models.Domain.Categories.Sleeping.SleepingBags
{
    /// <summary>
    /// Season of usage - summer, winter, etc.
    /// 
    /// Column for czech localisation
    /// </summary>
    public class SleepingBagSeason
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
