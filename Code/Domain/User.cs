using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class User
    {
        public string ID { get; set; }

        public IEnumerable<Ride> Rides { get; set; }
    }
}
