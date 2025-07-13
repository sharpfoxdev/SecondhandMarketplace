using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Review : IEntity
    {
        public Guid Id { get; set; }
        public Guid ReviewerId { get; set; }
        public Guid RevieweeId { get; set; }
        public string ReviewText { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
