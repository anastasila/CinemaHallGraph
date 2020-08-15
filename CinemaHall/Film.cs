using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace CinemaHall
{
    public class Film : IEquatable<Film>
    {        
        public int Number { get; set; }

        public string Name { get; set; }

        public int Duration { get; set; }

        public Film()
        {

        }

        public Film(int number, string name, int duration)
        {
            this.Number = number;
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

        public bool Equals([AllowNull] Film other)
        {
            if (Object.ReferenceEquals(other, null)) return false;

            if (Object.ReferenceEquals(this, other)) return true;

            return Number.Equals(other.Number) && Name.Equals(other.Name);
        }
    }
}
