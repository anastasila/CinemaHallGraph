using CinemaHall;
using CinemaHallTests.Mocks;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace CinemaHallTests.DataSource
{
    public class RelevantSessionsWithOptimalTimeDataSource : IEnumerable
    {
        CinemaMocks cinemaMocks = new CinemaMocks();
        CinemaHallSessionsMocks sessionsMocks = new CinemaHallSessionsMocks();

        public IEnumerator GetEnumerator()
        {
            Cinema cinema1 = cinemaMocks.First();
            List<CinemaHallSessions> sessions1 = sessionsMocks.RelevantSessionsWithTimeTest1();

            Cinema cinema2 = cinemaMocks.Second();
            List<CinemaHallSessions> sessions2 = sessionsMocks.RelevantSessionsWithTimeTest2();

            yield return new object[] { cinema1, sessions1 };
            yield return new object[] { cinema2, sessions2 };
        }
    }
}
