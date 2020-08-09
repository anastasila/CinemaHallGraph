using System;
using System.Collections.Generic;
using System.Text;

namespace CinemaHall
{
    public class Film
    {
        public string name { get; set; }

        public int duration { get; set; }

        public int index { get; set; }

        public Film()
        {

        }

        public Film(int index, string name, int duration)
        {
            this.index = index;
            this.name = name;
            this.duration = duration;
        }
    }
}
