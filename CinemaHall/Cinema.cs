using System;
using System.Collections.Generic;
using System.Text;

namespace CinemaHall
{
    public class Cinema
    {
        public Cinema()
        {

        }

        //Количество залов
        private int _hallNumber { get; set; }

        //Продолжительность работы
        private int _workTime { get; set; }

        //Список фильмов
        private List<Film> _films;

        public List<CinemaHallSessions> _cinemaHallSessions;

        public Cinema(int hallNumber, int workTime, List<Film> films)
        {
            _hallNumber = hallNumber;
            _workTime = workTime;
            _films = films;
            _cinemaHallSessions = new List<CinemaHallSessions>();
        }

        public void FindAllPossibleSessions(Node node)
        {
            //Если есть следующие ноды, не лист - ищи, пока не найдешь лист
            if (node._nexts.Count != 0)
            {
                foreach (Node n in node._nexts)
                {
                    FindAllPossibleSessions(n);
                }
            }
            //Если нашли лист - сохраняем оставшееся время и сеанс
            else
            {
                CinemaHallSessions currentSession = new CinemaHallSessions(node.Length, node._cinemaSessions);
                _cinemaHallSessions.Add(currentSession);
            }
        }

        public void ShowRelevantSessions()
        {
            _cinemaHallSessions.Sort();

            if(_cinemaHallSessions.Count < _hallNumber)
            {
                throw new Exception
                    ($"Количество уникальных расписаний для этого списка фильмов ({_cinemaHallSessions.Count}) меньше, чем количество залов ({_hallNumber}). " +
                    $"Увеличьте количество фильмов или уменьшите количество залов.");
            }
            else
            {
                for (int i = 0; i < _hallNumber; i++)
                {
                    Console.WriteLine();
                    Console.WriteLine($"Зал {i + 1}");
                    _cinemaHallSessions[i].PrintAllSessionsInThisHall();
                }

                Console.WriteLine();
            }            
        }        
    }
}
