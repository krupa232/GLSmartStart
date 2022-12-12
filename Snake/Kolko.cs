using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    internal class Kolko //sledzi polozenie weza
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Kolko() //konstruktor
        {
            X = 0;
            Y = 0;
        }
    }
}
