﻿using Domain.Entities.Listings.CommonProperties;

namespace Domain.Entities.Listings.Sleeping.Tarps
{
    public class Tarp : Sleeping
    {
        public TarpBrand TarpBrand { get; set; }
        public Guid TarpBrandId { get; set; }

        public Color Color { get; set; }
        public Guid ColorId { get; set; }

        public TarpShape TarpShape { get; set; }
        public Guid TarpShapeId { get; set; }

        public float? SizeXMetres { get; set; }
        public float? SizeYMetres { get; set; }

    }
}
