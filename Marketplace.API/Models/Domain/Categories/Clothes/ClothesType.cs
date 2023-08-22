﻿namespace Marketplace.API.Models.Domain.Categories.Clothes
{
    /// <summary>
    /// Type of clothes - t-shirt, pants, shoes, ...
    /// 
    /// Is used as a property in Clothes.cs, instead of making further children for
    /// Clothes, that wouldn't add any new properties.
    /// 
    /// For now there is a column with czech names, but can add more columns 
    /// with different language mutations. 
    /// </summary>
    public class ClothesType
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}