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

            return Number.Equals(other.Number) && Name.Equals(other.Name) && Duration.Equals(other.Duration);
        }
    }

    class FilmComparer : IEqualityComparer<Film>
    {
        public bool Equals([AllowNull] Film x, [AllowNull] Film y)
        {
            if (Object.ReferenceEquals(x, null)) return false;
            if (Object.ReferenceEquals(y, null)) return false;

            return x.Number.Equals(y.Number) && x.Name.Equals(y.Name) && x.Duration.Equals(y.Duration);
        }

        public int GetHashCode([DisallowNull] Film obj)
        {            
            int hashFilmName = obj.Name == null ? 0 : obj.Name.GetHashCode();
            int hashFilmNumber = obj.Number.GetHashCode();
            int hashFilmDuration = obj.Duration.GetHashCode();

            return hashFilmName ^ hashFilmNumber ^ hashFilmDuration;
        }
    }
}
