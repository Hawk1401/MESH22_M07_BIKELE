namespace Domain
{
    public class Coordinates
    {
        public double Latitude { get; set; } // Breitengrad
        public double Longitude { get; set; } // Längengrad

        public Coordinates(double latitude, double longitude)
        {
            Latitude = latitude;
            Longitude = longitude;
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