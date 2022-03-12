using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public class TrafficLoad
    {
        private IDataStorage dataStorage;
        public TrafficLoad(IDataStorage dataStorage)
        {
            this.dataStorage = dataStorage;
        }

        public IEnumerable<Square> GetTotalTrafficLoad()
        {
            SquareManager squareManager = new SquareManager();

            foreach (var Ride in dataStorage.GetAllRides())
            {
                foreach (var trackedInfo in Ride.TrackedInfos)
                {
                    squareManager.AddCoordinates(trackedInfo.Position);
                }
            }

            return squareManager.GetAllSquares();

        }
    }
}
