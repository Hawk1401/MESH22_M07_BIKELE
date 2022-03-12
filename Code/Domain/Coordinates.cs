namespace Domain
{
    public class Coordinates
    {
        public double Latitude { get => Math.Round(_Latitude, 8); set => _Latitude = value; } // Breitengrad
        public double Longitude { get => Math.Round(_Longitude, 8); set => _Longitude = value; } // Längengrad


        public double _Latitude { get; set; } // Breitengrad
        public double _Longitude { get; set; } // Längengrad
        public Coordinates(double latitude, double longitude)
        {
            Latitude = latitude;
            Longitude = longitude;
        }



        public Double GetDistanceTo(Coordinates other)
        {
            //  The Haversine formula according to Dr. Math.
            //  http://mathforum.org/library/drmath/view/51879.html

            //  dlon = lon2 - lon1
            //  dlat = lat2 - lat1
            //  a = (sin(dlat/2))^2 + cos(lat1) * cos(lat2) * (sin(dlon/2))^2
            //  c = 2 * atan2(sqrt(a), sqrt(1-a)) 
            //  d = R * c

            //  Where
            //    * dlon is the change in longitude
            //    * dlat is the change in latitude
            //    * c is the great circle distance in Radians.
            //    * R is the radius of a spherical Earth.
            //    * The locations of the two points in 
            //        spherical coordinates (longitude and 
            //        latitude) are lon1,lat1 and lon2, lat2.

            double dDistance = Double.NaN;

            double dLat1 = this.Latitude * (Math.PI / 180.0);
            double dLon1 = this.Longitude * (Math.PI / 180.0);
            double dLat2 = other.Latitude * (Math.PI / 180.0);
            double dLon2 = other.Longitude * (Math.PI / 180.0);

            double dLon = dLon2 - dLon1;
            double dLat = dLat2 - dLat1;

            // Intermediate result a.
            double a = Math.Pow(Math.Sin(dLat / 2.0), 2.0) +
                       Math.Cos(dLat1) * Math.Cos(dLat2) *
                       Math.Pow(Math.Sin(dLon / 2.0), 2.0);

            // Intermediate result c (great circle distance in Radians).
            double c = 2.0 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1.0 - a));

            // Distance.
            const Double kEarthRadiusMs = 6376500;
            dDistance = kEarthRadiusMs * c;

            return dDistance;
        }

        public override string ToString()
        {
            return $"latitude: {Latitude}, longitude: {Longitude}";
        }

        public override int GetHashCode()
        {
            return Latitude.GetHashCode() ^ Longitude.GetHashCode();
        }

        public override bool Equals(object? obj)
        {
            if (obj is Coordinates other)
            {
                if (this.Latitude != other.Latitude)
                {
                    return false;
                }

                if (this.Longitude != other.Longitude)
                {
                    return false;
                }

                return true;
            }

            return false;
        }
    }
}