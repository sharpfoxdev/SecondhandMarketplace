﻿using Domain.Entities;
using WebApi.ApiDtos.Listings;

namespace WebApi.ApiDtos.Images {
	public class ImageDto {
		public Guid Id { get; set; }
		public string ImageUrl { get; set; }
		public string FileName { get; set; }
		public string FileExtension { get; set; }
		public long FileSizeInBytes { get; set; }
	}
}
