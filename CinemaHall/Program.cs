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

            films.Add(new Film("Человек паук", 60));
            films.Add(new Film("Властелин колец", 90));
            films.Add(new Film("Титаник", 550));
            films.Add(new Film("Война и мир", 500));

            //Console.WriteLine("Введите количество залов в кинотеатре:");
            //int hallNumber = Convert.ToInt32(Console.ReadLine());

            //Console.WriteLine("Введите количество фильмов в прокате:");
            //int filmNumber = Convert.ToInt32(Console.ReadLine());

            //List<Film> films = new List<Film>();
            //int count = 0;
            //while (count < filmNumber)
            //{
            //    Console.WriteLine($"Введите название фильма {count + 1}:");
            //    string filmName = Convert.ToString(Console.ReadLine());

            //    Console.WriteLine($"Введите продолжительность фильма в минутах {count + 1}:");
            //    int filmDuration = Convert.ToInt32(Console.ReadLine());

            //    films.Add(new Film(count, filmName, filmDuration));

            //    count++;
            //}

            Cinema cinema = new Cinema(hallNumber, cinemaWorkTime, films);

            Console.WriteLine("Расписание сеансов с оптимальным временем:");
            cinema.ShowRelevantSessionsWithOptimalTime();
            Console.WriteLine();

            Console.WriteLine("Расписание сеансов с оптимальным временем и показом всех фильмов:");
            cinema.ShowRelevantSessionsWithAllFilms();
            
        }
    }
}
