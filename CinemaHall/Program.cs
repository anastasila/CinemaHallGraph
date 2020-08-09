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
            films.Add(new Film(2, "Властелин колец", 90));
            films.Add(new Film(3, "Титаник", 550));

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

            Node rute = new Node() { Length = cinemaWorkTime };

            rute.Create(films);
            cinema.FindAllPossibleSessions(rute);
            cinema.ShowRelevantSessions();          

        }
    }
}
