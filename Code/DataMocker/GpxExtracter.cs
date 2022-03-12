using Domain;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DataMocker
{
    public class GpxExtracter
    {
        private string GPXFilePath;
        public GpxExtracter(string GPXFilePath)
        {
            this.GPXFilePath = GPXFilePath;
        }

        public static string[] FilePaths()
        {
            return Directory.GetFiles(@"GPX");
        }

        public List<Coordinates> GetCoordinates()
        {
            var coordinates = new List<Coordinates>();

            var FileContent = File.ReadAllText(this.GPXFilePath);

            Regex rg = new Regex("<trkpt[^>]*>");

            var matches = rg.Matches(FileContent);

            foreach (Match match in matches)
            {
                var v = match.Value;

                Regex latitudeRg = new Regex("lat=\"(\\d*.\\d*)\"");
                Regex longRg = new Regex("lon=\"(\\d*.\\d*)\"");

                var latitudeMatch = latitudeRg.Match(v);

                double latitude = parseToDouble(latitudeMatch);

                var longMatch = longRg.Match(v);

                double longitude = parseToDouble(longMatch);

                coordinates.Add(new Coordinates(latitude, longitude));
            }

            return coordinates;
        }

        private double parseToDouble(Match match, int groupIndex = 1)
        {
            if (!match.Success)
            {
                return 0;
            }

            var item = match.Groups.Values.ElementAt(groupIndex).Value;

            return double.Parse(item, CultureInfo.InvariantCulture);
        }
    }
}
