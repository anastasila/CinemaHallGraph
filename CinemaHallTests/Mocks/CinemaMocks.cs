using CinemaHall;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace CinemaHallTests.Mocks
{
    public class CinemaMocks
    { 
        public Cinema FirstTest()
        {
            int cinemaWorkTime = 600;
            int hallNumber = 5;
            List<Film> films = new List<Film>();

            films.Add(new Film(1, "Человек паук", 550));
            films.Add(new Film(2, "Властелин колец", 580));
            films.Add(new Film(3, "Титаник", 590));
            films.Add(new Film(4, "Война и мир", 300));
            films.Add(new Film(5, "Война и мир 2", 300));
            films.Add(new Film(6, "Война и мир 3", 575));

            return new Cinema(hallNumber, cinemaWorkTime, films);
        }

    }
}
