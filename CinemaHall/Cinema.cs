﻿using System;
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
            CreateAndSortAllSessions();
        }

        public void ShowRelevantSessionsWithOptimalTime()
        {
            _relevantSessions = new List<CinemaHallSessions>();
            GetRelevantSessionsWithOptimalTime();

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
            GetRelevantSessionsWithAllFilms(copyAllSessions);

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

        public List<CinemaHallSessions> CreateAndSortAllSessions()
        {
            _allPossibleSessions = new List<CinemaHallSessions>();
            Node node = new Node() { Length = _workTime };
            node.Create(_films);
            GetAllPossibleSessions(node);

            if (_allPossibleSessions.Count < _hallNumber)
            {
                Exception();
            }

            _allPossibleSessions.Sort();
            return _allPossibleSessions;
        }        
        
        private void GetAllPossibleSessions(Node node)
        {
            if (node._nexts.Count != 0)
            {
                foreach (Node n in node._nexts)
                {
                    GetAllPossibleSessions(n);
                }
            }
            else
            {
                CinemaHallSessions currentSession = new CinemaHallSessions(node.Length, node.CinemaSessions);
                _allPossibleSessions.Add(currentSession);
            }
        }

        public List<CinemaHallSessions> GetRelevantSessionsWithOptimalTime()
        {
            for (int i = 0; i < _hallNumber; i++)
            {
                _relevantSessions.Add(_allPossibleSessions[i]);
            }

            return _relevantSessions;
        }

        public List<CinemaHallSessions> GetRelevantSessionsWithAllFilms(List<CinemaHallSessions> allSessions)
        {
            Film film = new Film();
            List<Film> filmListCopy = film.Copy(_films);
            List<CinemaHallSessions> allSessionsCopy = Copy(allSessions);
            int removedSessions = 0;

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
                        allSessionsCopy.Remove(allSessionsCopy[i - removedSessions]);
                        removedSessions++;
                    }
                }
                else
                {
                    _relevantSessions.Add(allSessions[i]);
                    allSessionsCopy.Remove(allSessionsCopy[i - removedSessions]);
                    removedSessions++;
                }

                i++;
            }

            if (_relevantSessions.Count < _hallNumber)
            {
                GetRelevantSessionsWithAllFilms(allSessionsCopy);
            }

            return _relevantSessions;
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
