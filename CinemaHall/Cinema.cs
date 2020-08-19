using System;
using System.Collections.Generic;
using System.Text;

namespace CinemaHall
{
    public class Cinema
    {
        private int _hallNumber;

        private int _workTime;

        private List<Film> _films;

        private List<CinemaHallSessions> _allPossibleSessions;

        private List<CinemaHallSessions> _relevantSessionsWithOptimalTime;

        private List<CinemaHallSessions> _relevantSessionsWithAllFilms;

        public int HallNumber 
        {
            get 
            { 
                return _hallNumber; 
            } 
            set 
            {
                if(value <= 0)
                {
                    IncorrectValueException();
                }
                else
                {
                    _hallNumber = value;
                    ChangeCinemaParameters();
                }                
            } 
        }
        public int WorkTime 
        { 
            get 
            { 
                return _workTime; 
            } 
            set 
            {
                if (value <= 0)
                {
                    IncorrectValueException();
                }
                else
                {
                    _workTime = value;
                    ChangeCinemaParameters();
                }                
            } 
        }
        public List<Film> Films 
        { 
            get 
            { 
                return _films; 
            } 
            set 
            {
                if (value.Count == 0)
                {
                    IncorrectValueException();
                }
                else
                {
                    _films = value;
                    ChangeCinemaParameters();
                }                
            } 
        }
        public List<CinemaHallSessions> AllPossibleSessions 
        { 
            get 
            { 
                if(_allPossibleSessions == null)
                {
                    GetAllPossibleSessions();
                }
                return _allPossibleSessions; 
            } 
        }
        public List<CinemaHallSessions> RelevantSessionsWithOptimalTime 
        { 
            get 
            {
                if(_relevantSessionsWithOptimalTime == null)
                {
                    GetRelevantSessionsWithOptimalTime();
                }
                return _relevantSessionsWithOptimalTime; 
            } 
        }
        public List<CinemaHallSessions> RelevantSessionsWithAllFilms
        { 
            get 
            {
                if (_relevantSessionsWithAllFilms == null)
                {
                    GetRelevantSessionsWithAllFilms(AllPossibleSessions);
                }
                return _relevantSessionsWithAllFilms; 
            } 
        }                

        public Cinema() { }

        public Cinema(int hallNumber, int workTime, List<Film> films)
        {
            HallNumber = hallNumber;
            WorkTime = workTime;
            Films = films;
            _allPossibleSessions = GetAllPossibleSessions();
        }

        private void ChangeCinemaParameters()
        {
            _allPossibleSessions = null;
            _relevantSessionsWithOptimalTime = null;
            _relevantSessionsWithAllFilms = null;
        }

        private List<CinemaHallSessions> GetAllPossibleSessions()
        {            
            _allPossibleSessions = new List<CinemaHallSessions>();
            Node node = new Node() { Length = _workTime };
            node.Create(_films);
            
            if(node.Nexts.Count != 0)
            {
                CreateAllSessions(node);
            }
            else
            {
                NodeException();
            }

            if (_allPossibleSessions.Count < _hallNumber)
            {
                Exception();
            }

            _allPossibleSessions.Sort();
            return _allPossibleSessions;
        }

        private void CreateAllSessions(Node node)
        {
            if (node.Nexts.Count != 0)
            {
                foreach (Node n in node.Nexts)
                {
                    CreateAllSessions(n);
                }
            }
            else
            {
                CinemaHallSessions currentSession = new CinemaHallSessions(node.Length, node.CinemaSessions);
                _allPossibleSessions.Add(currentSession);
            }
        }

        private void GetRelevantSessionsWithOptimalTime()
        {
            _relevantSessionsWithOptimalTime = new List<CinemaHallSessions>();

            for (int i = 0; i < _hallNumber; i++)
            {
                _relevantSessionsWithOptimalTime.Add(AllPossibleSessions[i]);
            }
        }

        private List<CinemaHallSessions> GetRelevantSessionsWithAllFilms(List<CinemaHallSessions> allSessions)
        {
            Film film = new Film();
            List<Film> filmListCopy = film.Copy(_films);
            List<CinemaHallSessions> allSessionsCopy = Copy(allSessions);

            if (_relevantSessionsWithAllFilms == null)
            {
                _relevantSessionsWithAllFilms = new List<CinemaHallSessions>();
            }
                        
            foreach (var cinemaHall in allSessions)
            {
                if(_relevantSessionsWithAllFilms.Count < _hallNumber)
                {
                    bool match = false;
                    if (filmListCopy.Count != 0)
                    {
                        foreach (var currentFilm in cinemaHall.sessions)
                        {
                            if (filmListCopy.Contains(currentFilm))
                            {
                                filmListCopy.Remove(currentFilm);
                                match = true;
                            }
                        }

                        if (match)
                        {
                            _relevantSessionsWithAllFilms.Add(cinemaHall);
                            allSessionsCopy.Remove(cinemaHall);
                        }
                    }
                    else
                    {
                        _relevantSessionsWithAllFilms.Add(cinemaHall);
                        allSessionsCopy.Remove(cinemaHall);
                    }
                }
                else
                {
                    return _relevantSessionsWithAllFilms;
                }                
            }

            if (_relevantSessionsWithAllFilms.Count < _hallNumber)
            {
                GetRelevantSessionsWithAllFilms(allSessionsCopy);
            }

            return _relevantSessionsWithAllFilms;
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

        private void IncorrectValueException()
        {
            throw new Exception
                    ($"Значение должно быть больше нуля");
        }

        private void NodeException()
        {
            throw new Exception
                    ($"При заданных параметрах невозможно создать ни один сеанс. Измените продолжительность работы кинотеатра или продолжительность фильмов.");
        }
    }
}
