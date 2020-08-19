using System;
using System.Collections.Generic;
using System.Text;

namespace CinemaHall
{
    public class Cinema
    {        
        public int HallNumber { get { return _hallNumber; } set { _hallNumber = value; } }
        public int WorkTime { get { return _workTime; } set { _workTime = value; } }
        public List<Film> Films { get { return _films; } set { _films = value; } }
        public List<CinemaHallSessions> AllPossibleSessions { get { return _allPossibleSessions; } }
        public List<CinemaHallSessions> RelevantSessionsWitnOptimalTime { get { return _relevantSessionsWithOptimalTime; } }
        public List<CinemaHallSessions> RelevantSessionsWitnAllFilms { get { return _relevantSessionsWithAllFilms; } }

        private int _hallNumber;       

        private int _workTime;

        private List<Film> _films;

        private List<CinemaHallSessions> _allPossibleSessions;        

        private List<CinemaHallSessions> _relevantSessionsWithOptimalTime;

        private List<CinemaHallSessions> _relevantSessionsWithAllFilms;

        public Cinema() { }

        public Cinema(int hallNumber, int workTime, List<Film> films)
        {
            _hallNumber = hallNumber;
            _workTime = workTime;
            _films = films;
            _allPossibleSessions = GetAllPossibleSessions();
        }

        public List<CinemaHallSessions> GetAllPossibleSessions()
        {
            _allPossibleSessions = new List<CinemaHallSessions>();
            Node node = new Node() { Length = _workTime };
            node.Create(_films);
            GetAllSessions(node);

            if (_allPossibleSessions.Count < _hallNumber)
            {
                Exception();
            }

            _allPossibleSessions.Sort();
            return _allPossibleSessions;
        } 

        public List<CinemaHallSessions> GetRelevantSessionsWithOptimalTime()
        {
            if(_allPossibleSessions == null)
            {
                GetAllPossibleSessions();
            }

            _relevantSessionsWithOptimalTime = new List<CinemaHallSessions>();

            for (int i = 0; i < _hallNumber; i++)
            {
                _relevantSessionsWithOptimalTime.Add(_allPossibleSessions[i]);
            }

            return _relevantSessionsWithOptimalTime;
        }

        public List<CinemaHallSessions> GetRelevantSessionsWithAllFilms(List<CinemaHallSessions> allSessions)
        {
            Film film = new Film();
            List<Film> filmListCopy = film.Copy(_films);
            List<CinemaHallSessions> allSessionsCopy = Copy(allSessions);
            int removedSessions = 0;

            if(_relevantSessionsWithAllFilms == null)
            {
                _relevantSessionsWithAllFilms = new List<CinemaHallSessions>();
            }

            int i = 0;
            while (i < allSessions.Count && _relevantSessionsWithAllFilms.Count < _hallNumber)
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
                        _relevantSessionsWithAllFilms.Add(allSessions[i]);
                        allSessionsCopy.Remove(allSessionsCopy[i - removedSessions]);
                        removedSessions++;
                    }
                }
                else
                {
                    _relevantSessionsWithAllFilms.Add(allSessions[i]);
                    allSessionsCopy.Remove(allSessionsCopy[i - removedSessions]);
                    removedSessions++;
                }

                i++;
            }

            if (_relevantSessionsWithAllFilms.Count < _hallNumber)
            {
                GetRelevantSessionsWithAllFilms(allSessionsCopy);
            }

            return _relevantSessionsWithAllFilms;
        }               

        private void GetAllSessions(Node node)
        {
            if (node.Nexts.Count != 0)
            {
                foreach (Node n in node.Nexts)
                {
                    GetAllSessions(n);
                }
            }
            else
            {
                CinemaHallSessions currentSession = new CinemaHallSessions(node.Length, node.CinemaSessions);
                _allPossibleSessions.Add(currentSession);
            }
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
