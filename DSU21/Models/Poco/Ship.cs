using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DSU21.Models
{
    public class Ship
    {
        public int Id { get; set; }
        public string Name { get; set; }

        // navigation property
        // captain
        public int? PirateId { get; set; }
        public virtual Pirate Captain { get; set; }

        // navigation properties
        public virtual ICollection<Pirate> Pirates { get; set; } = new List<Pirate>();
       
    }
}
