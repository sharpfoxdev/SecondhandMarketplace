using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities {
	public class Image {
		public Guid Id { get; set; }
		public string ImageUrl { get; set; }
		public string FileName { get; set; }
		public string FileExtension { get; set; }
		public long FileSizeInBytes { get; set; }
		public string FilePath { get; set; }
		public Guid ListingId { get; set; }
		public Listing Listing { get; set; }
	}
}
