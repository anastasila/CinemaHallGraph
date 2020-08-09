using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace CinemaHall
{
    public class Node
    {
        //Лист других нод
        public List<Node> _nexts = new List<Node>();
        
        //Сколько пустого места осталось
        public int Length {get; set;}

        //Делают проект тяжелее //Список сеансов
        public List<Film> _cinemaSessions;

        
        public void Create(List<Film> films, List<Film> sessions = null)
        {
            // Сохраняем предыдущие сеансы, которые нам передались
            _cinemaSessions = sessions;

            foreach (Film i in films)
            {
                if (Length >= i.duration)
                {
                    Node node = new Node() { Length = Length - i.duration };
                    // Кладем в список созданную ноду - благодаря этому будет ссылка на нижнюю ноду
                    _nexts.Add(node);
                    // Копируем предыдущие сеансы
                    List<Film> newSessions = Copy(sessions);
                    // Добавляем в сеанс текущий фильм
                    newSessions.Add(i);
                    // Рекурсия
                    node.Create(films, newSessions);
                }
            }
        } 

        //Копирование списка
        public List<Film> Copy(List<Film> sessions)
        {
            List<Film> newSessions = new List<Film>();
            if (sessions != null)
            {
                foreach (var i in sessions)
                {
                    newSessions.Add(i);
                }
            }
            return newSessions;
        }
          
    }
}
