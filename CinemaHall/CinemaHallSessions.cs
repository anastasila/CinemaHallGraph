using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CinemaHall
{
    //Зал кинотеатра со всеми сеансами
    public class CinemaHallSessions : IComparable<CinemaHallSessions>
    {
        public List<Film> sessions;
        public int remainingTime { get; set; }
        public int differentFilms { get; set; }

        public CinemaHallSessions()
        {

        }

        public CinemaHallSessions(int remainingTime, List<Film> sessions)
        {
            this.remainingTime = remainingTime;
            this.sessions = sessions;
            IEnumerable<Film> differentFilms = sessions.Distinct(new FilmComparer());
            this.differentFilms = differentFilms.Count();
        }

        public void PrintAllSessionsInThisHall()
        {
            DateTime timeStart = new DateTime(2020, 1, 1, 14, 00, 00);
            foreach (var i in sessions)
            {
                DateTime timeEnd = timeStart.AddMinutes(i.Duration);
                Console.WriteLine($"{timeStart.ToShortTimeString()} - {timeEnd.ToShortTimeString()} \t {i.Name}");
                timeStart = timeEnd;
            }
        }

        public int CompareTo(CinemaHallSessions compareCinemaHall)
        {
            if (compareCinemaHall == null)
                return 1;

            if (this.remainingTime == compareCinemaHall.remainingTime)
            {
                if (this.differentFilms == compareCinemaHall.differentFilms)
                {
                    return 0;
                }
                else if (this.differentFilms > compareCinemaHall.differentFilms)
                {
                    return -1;
                }
                else
                {
                    return 1;
                }
            }
            else
                return this.remainingTime.CompareTo(compareCinemaHall.remainingTime);
        }

        public override bool Equals(object obj)
        {
            if (obj.GetType() != this.GetType()) return false;

            CinemaHallSessions compare = (CinemaHallSessions)obj;           

            return (sessions.SequenceEqual(compare.sessions)
                && this.remainingTime == compare.remainingTime
                && this.differentFilms == compare.differentFilms);
        }
    }
}
