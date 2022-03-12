using DataMocker;
using Domain;
using FileSupplier;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Application
{
    public class DBMocker : IDataStorage
    {
        private List<Ride> positions { get; set; } = new List<Ride>();
        
        public IEnumerable<Ride> GetAllRides()
        {
            if(positions.Count == 0)
            {
                positions = CalcAllRides().ToList();    
            }

            return positions;
        }


        private IEnumerable<Ride> CalcAllRides()
        {

            foreach (var pos in posList())
            {
                yield return new Ride
                {
                    TrackedInfos = TrackedInfos(pos)
                };
            }

            foreach (var pos in rides())
            {
                yield return new Ride
                {
                    TrackedInfos = TrackedInfos(pos.ToList())
                };
            }

            foreach (var pos in posListv2())
            {
                yield return new Ride
                {
                    TrackedInfos = TrackedInfos(pos.ToList())
                };
            }

        }
        public List<TrackedInfo> TrackedInfos(List<Coordinates> coordinates)
        {
            return coordinates.Select(x => new TrackedInfo() { Position = x}).ToList();
        }
        public List<Coordinates> pos1()
        {
            var steps = 100;
            var startLat = 49.01468047;
            var startLong = 8.36111605;
            var EndLat = 49.01301978;
            var EndLong = 8.38212848;

            return pos(steps, startLat, startLong, EndLat, EndLong);
        }

        private static List<Coordinates> pos(int steps, double startLat, double startLong, double EndLat, double EndLong)
        {
            List<Coordinates> result = new List<Coordinates>();
            var stepLat = (EndLat - startLat) / steps;
            var stepLong = (EndLong - startLong) / steps;

            var currentlat = startLat;
            var currentlong = startLong;
            for (int i = 0; i < steps; i++)
            {
                result.Add(new Coordinates(currentlat, currentlong));

                currentlat += stepLat;
                currentlong += stepLong;
            }

            return result;
        }

        public IEnumerable<List<Coordinates>> posList()
        {
            var files = GPXFiles.GetAllGPXFiles();
            var count = 10;
            foreach (var file in files)
            {
                GpxExtracter gpxExtracter = new GpxExtracter(file);

                if(count > 0)
                {
                    var start = gpxExtracter.GetCoordinates();
                    var result = AddMisingGPSPorints(start);
                    count--;
                    yield return result;

                }
                else
                {
                    yield return gpxExtracter.GetCoordinates();
                    break;
                }
            }


            //yield return pos(100, 49.01468047, 8.36111605, 49.01301978, 8.38212848);
            //yield return pos(100, 49.00857226, 8.37360442, 49.00811482, 8.37597549);
            //yield return pos(5000, 49.00811482, 8.37597549, 49.00751662, 8.38959038);
            //yield return pos(100, 49.00811482, 8.37597549, 49.00751662, 8.38959038);
        }

        public IEnumerable<List<Coordinates>> posListv2()
        {
            var files = GPXFiles.GetAllGPXFiles(); 
            foreach (var file in files)
            {
                GpxExtracter gpxExtracter = new GpxExtracter(file);

                yield return gpxExtracter.GetCoordinates();
            }


            //yield return pos(100, 49.01468047, 8.36111605, 49.01301978, 8.38212848);
            //yield return pos(100, 49.00857226, 8.37360442, 49.00811482, 8.37597549);
            //yield return pos(5000, 49.00811482, 8.37597549, 49.00751662, 8.38959038);
            //yield return pos(100, 49.00811482, 8.37597549, 49.00751662, 8.38959038);
        }

        public IEnumerable<IEnumerable<Coordinates>> rides()
        {
            yield return AddMisingGPSPorints(new Coordinates(49.01468047, 8.36111605), new Coordinates(49.01301978, 8.38212848));
            yield return AddMisingGPSPorints(new Coordinates(49.00857226, 8.37360442), new Coordinates(49.00811482, 8.37597549));
            yield return AddMisingGPSPorints(new Coordinates(49.00811482, 8.37597549), new Coordinates(49.00751662, 8.38959038));
            yield return AddMisingGPSPorints(new Coordinates(49.00811482, 8.37597549), new Coordinates(49.00751662, 8.38959038));
            yield return AddMisingGPSPorints(new Coordinates(49.014101, 8.398218), new Coordinates(49.013820, 8.405992));
            yield return AddMisingGPSPorints(new Coordinates(49.013820, 8.405992), new Coordinates(49.011258, 8.412648));
            yield return AddMisingGPSPorints(new Coordinates(49.013820, 8.405992), new Coordinates(49.013510, 8.418703));
            yield return AddMisingGPSPorints(new Coordinates(49.014214, 8.398257), new Coordinates(49.011315, 8.400148));
            yield return AddMisingGPSPorints(new Coordinates(49.011315, 8.400148), new Coordinates(49.010020, 8.404099));
            yield return AddMisingGPSPorints(new Coordinates(49.010020, 8.404099), new Coordinates(49.000870, 8.402898));
            yield return AddMisingGPSPorints(new Coordinates(49.00811482, 8.37597549), new Coordinates(49.00751662, 8.38959038));


            for (int i = 0; i < 1; i++)
            {

                yield return AddMisingGPSPorints(new Coordinates(49.013820, 8.405992), new Coordinates(49.013510, 8.418703));
                yield return AddMisingGPSPorints(new Coordinates(49.014214, 8.398257), new Coordinates(49.011315, 8.400148));
                yield return AddMisingGPSPorints(new Coordinates(49.011315, 8.400148), new Coordinates(49.010020, 8.404099));
                yield return AddMisingGPSPorints(new Coordinates(49.013820, 8.405992), new Coordinates(49.013510, 8.418703));
                yield return AddMisingGPSPorints(new Coordinates(49.014214, 8.398257), new Coordinates(49.011315, 8.400148));
                yield return AddMisingGPSPorints(new Coordinates(49.011315, 8.400148), new Coordinates(49.010020, 8.404099));
            }
        }


        public List<Coordinates> AddMisingGPSPorints(List<Coordinates> coordinates)
        {
            var result = new List<Coordinates>();

            for (int i = 0; i < coordinates.Count - 1; i++)
            {
                result.AddRange(
                    AddMisingGPSPorints(coordinates.ElementAt(i), coordinates.ElementAt(i + 1))
                    );
            }

            return result;
        }

        public IEnumerable<Coordinates> AddMisingGPSPorints(Coordinates start, Coordinates end)
        {
            var distMeter = start.GetDistanceTo(end);

            var CoordinatesCount = (int)(distMeter / 1.5);

            var LatitudeOffset = (end.Latitude - start.Latitude) / CoordinatesCount;
            var LongitudeOffset = (end.Longitude - start.Longitude) / CoordinatesCount;

            var currentLatitude = start.Latitude;
            var currentLongitude = start.Longitude;

            for (int i = 0; i < CoordinatesCount; i++)
            {
                yield return new Coordinates(currentLatitude, currentLongitude);

                currentLatitude += LatitudeOffset;
                currentLongitude += LongitudeOffset;
            }

            yield return new Coordinates(currentLatitude, currentLongitude);

        }
        public IEnumerable<User> GetAllUser()
        {
            throw new NotImplementedException();
        }
    }
}
