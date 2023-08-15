using NetTopologySuite.Geometries;

namespace Marketplace.API.Models.Domain {

	/// <summary>
	/// Table for cities. MySQL supports spatial data. Connection to database with spatial data is 
	/// done via <code>Pomelo.EntityFrameworkCore.MySql.NetTopologySuite</code> nuget package 
	/// <link>https://www.nuget.org/packages/Pomelo.EntityFrameworkCore.MySql.NetTopologySuite</link>
	/// More info about spatial data is in the EF Core documentation 
	/// <link>https://learn.microsoft.com/en-us/ef/core/modeling/spatial</link>. 
	/// 
	/// Beware, that the <code>Point</code> X value is longitude (E, W) and Y value is latitude (N, S), which
	/// is the other way around, than it is usually written
	/// </summary>
	public class City {
		public Guid Id { get; set; }
		// Bavorov
		public string Name { get; set; }
		// Strakonice
		public string District { get; set; }
		// Jihocesky kraj
		public string Region { get; set; }
		//38773
		public string PostCode { get; set; }
		// 14.079028 (longtitude), 49.121951 (latitude)
		public Point GpsLocation { get; set; }

	}
}
