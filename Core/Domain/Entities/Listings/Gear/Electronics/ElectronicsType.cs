using Domain.Common;

namespace Domain.Entities.Listings
{
    /// <summary>
    /// Watch, gps, camera, powerbank, ...
    /// </summary>
    public class ElectronicsType : IEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
