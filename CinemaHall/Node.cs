using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace CinemaHall
{
    public class Node
    {
        public List<Node> _nexts = new List<Node>();
        
        public int Length {get; set;}

        public List<Film> CinemaSessions { get; set; }

        public void Create(List<Film> films, List<Film> filmSessions = null)
        {
            CinemaSessions = filmSessions;
            Film film = new Film();

            foreach (Film i in films)
            {
                if (Length >= i.Duration)
                {
                    Node node = new Node() { Length = Length - i.Duration };                    
                    _nexts.Add(node);
                    List<Film> newSessions = film.Copy(filmSessions);
                    newSessions.Add(i);
                    node.Create(films, newSessions);
                }
            }
        }          
    }
}
