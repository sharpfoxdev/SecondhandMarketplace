﻿namespace Marketplace.API.Models.Domain.Categories.Clothes
{
    /// <summary>
    /// Different clothes sizes - S, M, L, XL, ...
    /// </summary>
    public class ClothesSize
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
