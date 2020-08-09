using System;
using System.Collections.Generic;
using System.Text;

namespace CinemaHall
{
    public class Film
    {
        public string Name { get; set; }

        public int Duration { get; set; }

        public Film()
        {

        }

        public Film(string name, int duration)
        {
            this.Name = name;
            this.Duration = duration;
        }

        public List<Film> Copy(List<Film> filmSessions)
        {
            List<Film> newSessions = new List<Film>();
            if (filmSessions != null)
            {
                foreach (var i in filmSessions)
                {
                    newSessions.Add(i);
                }
            }
            return newSessions;
        }
    }
}
