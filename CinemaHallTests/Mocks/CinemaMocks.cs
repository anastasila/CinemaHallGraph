using CinemaHall;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace CinemaHallTests.Mocks
{
    public class CinemaMocks
    { 
        public Cinema First()
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

        public Cinema Second()
        {
            int cinemaWorkTime = 600;
            int hallNumber = 5;
            List<Film> films = new List<Film>();

            films.Add(new Film(1, "Человек паук", 60));
            films.Add(new Film(2, "Властелин колец", 30));
            films.Add(new Film(3, "Титаник", 590));
            films.Add(new Film(4, "Война и мир", 90));
            films.Add(new Film(5, "Война и мир 2", 300));
            films.Add(new Film(6, "Война и мир 3", 575));

            return new Cinema(hallNumber, cinemaWorkTime, films);
        }

        public Cinema Third()
        {
            Cinema cinema = new Cinema();
            cinema.WorkTime = 600;
            cinema.HallNumber = 10;
            List<Film> films = new List<Film>();

            films.Add(new Film(3, "Титаник", 590));
            films.Add(new Film(6, "Война и мир 3", 575));
            
            cinema.Films = films;

            return cinema;
        }

        public Cinema Forth()
        {
            Cinema cinema = new Cinema();
            cinema.WorkTime = 600;
            cinema.HallNumber = 1;
            List<Film> films = new List<Film>();

            films.Add(new Film(3, "Титаник", 690));
            films.Add(new Film(6, "Война и мир 3", 675));

            cinema.Films = films;

            return cinema;
        }

    }
}
