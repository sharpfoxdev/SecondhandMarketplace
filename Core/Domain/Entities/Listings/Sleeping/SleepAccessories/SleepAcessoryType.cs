using Domain.Common;

namespace Domain.Entities.Listings
{
    /// <summary>
    /// Pillow, ground sheet, stakes, cordage, ... 
    /// </summary>
    public class SleepAcessoryType : IEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

    }
}
