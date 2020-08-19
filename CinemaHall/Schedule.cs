using System;
using System.Collections.Generic;
using System.Text;

namespace CinemaHall
{
    public class Schedule
    {
        public void ShowSessions(List<CinemaHallSessions> sessions)
        {
            int count = 0;
            foreach (var i in sessions)
            {
                PrintSession(i, count);
                count++;
            }

            Console.WriteLine();
        }

        private void PrintSession(CinemaHallSessions hall, int count)
        {
            Console.WriteLine();
            Console.WriteLine($"Зал {count + 1}, свободное время: {hall.remainingTime}");
            hall.PrintAllSessionsInThisHall();
        }
    }
}
