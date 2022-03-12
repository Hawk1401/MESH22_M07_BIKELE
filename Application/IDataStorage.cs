using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public interface IDataStorage
    {
        public IEnumerable<User> GetAllUser();
        public IEnumerable<Ride> GetAllRides();
    }
}
