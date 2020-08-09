using System;
using System.Collections.Generic;
using System.Text;

namespace CinemaHall
{
    //Зал кинотеатра со всеми сеансами
    public class CinemaHallSessions: IComparable<CinemaHallSessions>
    {
        public List<Film> sessions;
        public int remainingTime { get; set; }

        public CinemaHallSessions()
        {

        }

        public CinemaHallSessions(int remainingTime, List<Film> sessions)
        {
            this.remainingTime = remainingTime;
            this.sessions = sessions;
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

            else
                return this.remainingTime.CompareTo(compareCinemaHall.remainingTime);
        }
    }
}
