using CinemaHall;
using CinemaHallTests.Mocks;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace CinemaHallTests.DataSource
{
    public class CreateNodeDataSource : IEnumerable
    {
        CinemaMocks cinemaMocks = new CinemaMocks();
        CinemaHallSessionsMocks sessionsMocks = new CinemaHallSessionsMocks();

        public IEnumerator GetEnumerator()
        {
            Cinema cinema = cinemaMocks.First();
            List<CinemaHallSessions> sessions = sessionsMocks.AllSessionsTest();

            Cinema cinema3 = cinemaMocks.Third();
            Cinema cinema4 = cinemaMocks.Forth();

            yield return new object[] { cinema, sessions };
            yield return new object[] { cinema3, sessions };
            yield return new object[] { cinema4, sessions };
        }
    }
}
