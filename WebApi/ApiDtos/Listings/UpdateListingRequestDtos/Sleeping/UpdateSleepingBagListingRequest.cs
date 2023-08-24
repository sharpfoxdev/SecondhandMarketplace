namespace WebApi.ApiDtos.Listings.UpdateListing
{
    public class UpdateSleepingBagListingRequest : UpdateCampingListingRequest
    {
        public Guid ColorId { get; set; }
        public Guid SleepingBagZipSideId { get; set; }
        public Guid SleepingBagShapeId { get; set; }
        public Guid SleepingBagBrandId { get; set; }
        public Guid SleepingBagInsulationTypeId { get; set; }
        public Guid SleepingBagSeasonId { get; set; }
        public Guid GenderId { get; set; }
        public int? ComfortTemperature { get; set; }
        public int? LimitTemperature { get; set; }
        public int? ExtremeTemperature { get; set; }
    }
}
