using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Square
    {
        public int Count { get; private set; } = 0;

        public Square(double latitude, double longitude)
        {

        }

        public Square(Coordinates coordinates) : this(coordinates.Latitude, coordinates.Longitude) { }

        public void Add()
        {
            Count++;
        }
    }
}
