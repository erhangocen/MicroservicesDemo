using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Product: Entity<Guid>
    {
        public String Name { get; set; }
        public String Description { get; set; }
        public double Amount { get; set; }
        public String CategoryId { get; set; }
    }
}
