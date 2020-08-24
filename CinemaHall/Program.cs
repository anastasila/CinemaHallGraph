using System;
using System.Collections.Generic;

namespace CinemaHall
{
    class Program
    {
        static void Main(string[] args)
        {
            int cinemaWorkTime = 600;

            Console.WriteLine("Введите количество залов в кинотеатре:");
            int hallNumber = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Введите количество фильмов в прокате:");
            int filmNumber = Convert.ToInt32(Console.ReadLine());

            List<Film> films = new List<Film>();
            int count = 1;
            while (count <= filmNumber)
            {
                Console.WriteLine($"Введите название фильма {count}:");
                string filmName = Convert.ToString(Console.ReadLine());

                Console.WriteLine($"Введите продолжительность фильма в минутах:");
                int filmDuration = Convert.ToInt32(Console.ReadLine());

                films.Add(new Film(count, filmName, filmDuration));

                count++;
            }

            Cinema cinema = new Cinema(hallNumber, cinemaWorkTime, films);
            Schedule schedule = new Schedule();

            Console.WriteLine("Расписание сеансов с оптимальным временем:");
            schedule.ShowSessions(cinema.RelevantSessionsWithOptimalTime);
            Console.WriteLine();

            Console.WriteLine("Расписание сеансов с оптимальным временем и показом всех фильмов:");
            schedule.ShowSessions(cinema.RelevantSessionsWithAllFilms);

        }
    }
}
