using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetTopologySuite.Geometries;


namespace Domain.Entities
{
    public class City
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; } = default!;
        public string ZipCode { get; set; } = default!;
        public string District { get; set; } = default!;
        public string Region { get; set; } = default!;
        public NetTopologySuite.Geometries.Point Location { get; set; } = default!;
    }
}
