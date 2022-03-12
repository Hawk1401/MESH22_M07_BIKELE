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

        public Coordinates Pos { get; private set; }

        public Square(double latitude, double longitude) : this(new Coordinates(latitude, longitude))
        {
        }

        public Square(Coordinates coordinates) {
            Pos = coordinates;
        }

        public void Add()
        {
            Count++;
        }
    }
}
