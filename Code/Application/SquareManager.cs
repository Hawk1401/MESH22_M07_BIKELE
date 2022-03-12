using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public class SquareManager
    {
        //5 = .00001 - 1.1132 m
        public Dictionary<Coordinates, Square> squares { get; set; }
        public int accuracy { get; set; } = 5;

        public const double MinLatitude = 48.989099;
        public const double MaxLatitude = 49.032786;

        public const double Minlongitude = 8.348789;
        public const double Maxlongitude = 8.442922;

        public SquareManager()
        {
            squares = new Dictionary<Coordinates, Square>();
        }

        public void AddCoordinates(Coordinates Coordinates)
        {
            if (!IsInGrid(Coordinates))
            {
                return;
            }

            var SquareCoordinates = GetSquareCoordinates(Coordinates);
            if (!squares.ContainsKey(SquareCoordinates))
            {
                var newSquares = new Square(SquareCoordinates);
                squares.Add(SquareCoordinates, newSquares);
            }

            var CurrentSquare = squares[SquareCoordinates];
            CurrentSquare.Add();
        }

        public Coordinates GetSquareCoordinates(Coordinates Coordinates)
        {
            double centerOffSet = CenterOffSet();


            var latitude = Math.Round(Coordinates.Latitude, 5) + centerOffSet;
            var longitude = Math.Round(Coordinates.Longitude, 5) + centerOffSet;

            var result = new Coordinates(latitude, longitude);
            return result;
        }

        private double CenterOffSet()
        {
            double centerOfeset = 5;

            for (int i = 0; i < accuracy; i++)
            {
                centerOfeset *= 0.1;
            }
            return centerOfeset;
        }

        public IEnumerable<Square> GetAllSquares()
        {
            return squares.Values;
        }

        private bool IsInGrid(Coordinates Coordinates)
        {
            if(Coordinates.Longitude < Minlongitude || Coordinates.Longitude > Maxlongitude)
            {
                return false;
            }

            if (Coordinates.Latitude < MinLatitude || Coordinates.Latitude > MaxLatitude)
            {
                return false;
            }

            return true;
        }
    }
}
