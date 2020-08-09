using System;
using System.Collections.Generic;
using System.Text;

namespace CinemaHall
{
    public class Cinema
    {
        public Cinema() { }

        private int _hallNumber { get; set; }

        private int _workTime { get; set; }

        private List<Film> _films { get; set; }

        private List<CinemaHallSessions> _allPossibleSessions { get; set; }

        private List<CinemaHallSessions> _relevantSessions { get; set; }

        public Cinema(int hallNumber, int workTime, List<Film> films)
        {
            _hallNumber = hallNumber;
            _workTime = workTime;
            _films = films;
            _allPossibleSessions = new List<CinemaHallSessions>();
            CreateNode();
        }

        public void ShowRelevantSessionsWithOptimalTime()
        {
            _relevantSessions = new List<CinemaHallSessions>();
            FindRelevantSessionsWithOptimalTime();

            int count = 0;
            foreach (var i in _relevantSessions)
            {
                PrintSession(i, count);
                count++;
            }
        }

        public void ShowRelevantSessionsWithAllFilms()
        {
            _relevantSessions = new List<CinemaHallSessions>();
            List<CinemaHallSessions> copyAllSessions = Copy(_allPossibleSessions);
            FindRelevantSessionsWithAllFilms(copyAllSessions);

            int count = 0;
            foreach (var i in _relevantSessions)
            {
                PrintSession(i, count);
                count++;
            }
        }

        public void ShowAllPossibleSessions()
        {
            int count = 0;
            foreach (var i in _allPossibleSessions)
            {
                PrintSession(i, count);
                count++;
            }

            Console.WriteLine();
        }

        private void CreateNode()
        {
            Node node = new Node() { Length = _workTime };
            node.Create(_films);
            FindAllPossibleSessions(node);

            if (_allPossibleSessions.Count < _hallNumber)
            {
                Exception();
            }

            _allPossibleSessions.Sort();
        }        
        
        private void FindAllPossibleSessions(Node node)
        {
            if (node._nexts.Count != 0)
            {
                foreach (Node n in node._nexts)
                {
                    FindAllPossibleSessions(n);
                }
            }
            else
            {
                CinemaHallSessions currentSession = new CinemaHallSessions(node.Length, node.CinemaSessions);
                _allPossibleSessions.Add(currentSession);
            }
        }

        private void FindRelevantSessionsWithOptimalTime()
        {
            for (int i = 0; i < _hallNumber; i++)
            {
                _relevantSessions.Add(_allPossibleSessions[i]);
            }
        }

        private void FindRelevantSessionsWithAllFilms(List<CinemaHallSessions> allSessions)
        {
            Film film = new Film();
            List<Film> filmListCopy = film.Copy(_films);

            int i = 0;
            while (i < allSessions.Count && _relevantSessions.Count < _hallNumber)
            {
                bool match = false;
                if (filmListCopy.Count != 0)
                {
                    foreach (var j in allSessions[i].sessions)
                    {
                        if (filmListCopy.Contains(j))
                        {
                            filmListCopy.Remove(j);
                            match = true;
                        }
                    }

                    if (match)
                    {
                        _relevantSessions.Add(allSessions[i]);
                        allSessions.Remove(allSessions[i]);
                    }
                }
                else
                {
                    _relevantSessions.Add(allSessions[i]);
                    allSessions.Remove(allSessions[i]);
                }

                i++;
            }

            if (_relevantSessions.Count < _hallNumber)
            {
                FindRelevantSessionsWithAllFilms(allSessions);
            }

        }

        private void PrintSession(CinemaHallSessions hall, int count)
        {
            Console.WriteLine();
            Console.WriteLine($"Зал {count + 1}, свободное время: {hall.remainingTime}");
            hall.PrintAllSessionsInThisHall();
        }

        private List<CinemaHallSessions> Copy(List<CinemaHallSessions> cinemaHallSessions)
        {
            List<CinemaHallSessions> newSessions = new List<CinemaHallSessions>();
            if (cinemaHallSessions != null)
            {
                foreach (var i in cinemaHallSessions)
                {
                    newSessions.Add(i);
                }
            }
            return newSessions;
        }

        private void Exception()
        {
            throw new Exception
                    ($"Количество уникальных расписаний для этого списка фильмов ({_allPossibleSessions.Count}) меньше, чем количество залов ({_hallNumber}). " +
                    $"Увеличьте количество фильмов или уменьшите количество залов.");
        }
    }
}
