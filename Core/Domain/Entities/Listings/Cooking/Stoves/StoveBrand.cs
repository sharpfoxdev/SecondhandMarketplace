﻿using Domain.Common;

namespace Domain.Entities.Listings.Cooking.Stoves
{
    /// <summary>
    /// Coleman, Esbit, Jetboil, ...
    /// </summary>
    public class StoveBrand : IEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}