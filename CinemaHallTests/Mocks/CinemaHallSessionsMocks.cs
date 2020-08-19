using CinemaHall;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace CinemaHallTests.Mocks
{
    public class CinemaHallSessionsMocks
    { 
        public List<CinemaHallSessions> FirstTest()
        {
            List<CinemaHallSessions> sessions = new List<CinemaHallSessions>();

            List<Film> films = new List<Film>();
            films.Add(new Film(4, "Война и мир", 300));
            films.Add(new Film(5, "Война и мир 2", 300));
            sessions.Add(new CinemaHallSessions(0, films));

            List<Film> films2 = new List<Film>();
            films2.Add(new Film(5, "Война и мир 2", 300));
            films2.Add(new Film(4, "Война и мир", 300));
            sessions.Add(new CinemaHallSessions(0, films2));

            List<Film> films3 = new List<Film>();
            films3.Add(new Film(4, "Война и мир", 300));
            films3.Add(new Film(4, "Война и мир", 300));
            sessions.Add(new CinemaHallSessions(0, films3));

            List<Film> films4 = new List<Film>();
            films4.Add(new Film(5, "Война и мир 2", 300));
            films4.Add(new Film(5, "Война и мир 2", 300));
            sessions.Add(new CinemaHallSessions(0, films4));

            List<Film> films5 = new List<Film>();
            films5.Add(new Film(3, "Титаник", 590));
            sessions.Add(new CinemaHallSessions(10, films5));

            List<Film> films6 = new List<Film>();
            films6.Add(new Film(2, "Властелин колец", 580));
            sessions.Add(new CinemaHallSessions(20, films6));

            List<Film> films7 = new List<Film>();
            films7.Add(new Film(6, "Война и мир 3", 575));
            sessions.Add(new CinemaHallSessions(25, films7));

            List<Film> films8 = new List<Film>();
            films8.Add(new Film(1, "Человек паук", 550));
            sessions.Add(new CinemaHallSessions(50, films8));

            return sessions;
        }
    }
}
