using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Ride
    {
        public IEnumerable<TrackedInfo> TrackedInfos { get; set; }

        public DateTime Start { get
            {
                return TrackedInfos.First().Time;
            } }

        public DateTime End
        {
            get
            {
                return TrackedInfos.Last().Time;
            }
        }
    }
}
