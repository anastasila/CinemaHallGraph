using System;
using System.Collections.Generic;

namespace CinemaHall
{
    class Program
    {
        static void Main(string[] args)
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

            //films.Add(new Film(1, "Человек паук", 550));
            //films.Add(new Film(2, "Властелин колец", 580));
            //films.Add(new Film(3, "Титаник", 590));
            //films.Add(new Film(4, "Война и мир", 300));
            //films.Add(new Film(5, "Война и мир 2", 300));
            //films.Add(new Film(6, "Война и мир 3", 575));

            //Console.WriteLine("Введите количество залов в кинотеатре:");
            //int hallNumber = Convert.ToInt32(Console.ReadLine());

            //Console.WriteLine("Введите количество фильмов в прокате:");
            //int filmNumber = Convert.ToInt32(Console.ReadLine());

            //List<Film> films = new List<Film>();
            //int count = 1;
            //while (count < filmNumber)
            //{
            //    Console.WriteLine($"Введите название фильма {count}:");
            //    string filmName = Convert.ToString(Console.ReadLine());

            //    Console.WriteLine($"Введите продолжительность фильма в минутах:");
            //    int filmDuration = Convert.ToInt32(Console.ReadLine());

            //    films.Add(new Film(count, filmName, filmDuration));

            //    count++;
            //}

            Cinema cinema = new Cinema(hallNumber, cinemaWorkTime, films);

            //cinema.ShowAllPossibleSessions();
            //Console.WriteLine();

            Console.WriteLine("Расписание сеансов с оптимальным временем:");
            cinema.ShowRelevantSessionsWithOptimalTime();
            Console.WriteLine();

            Console.WriteLine("Расписание сеансов с оптимальным временем и показом всех фильмов:");
            cinema.ShowRelevantSessionsWithAllFilms();
            
        }
    }
}
