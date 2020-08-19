using CinemaHall;
using CinemaHallTests.Mocks;
using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace CinemaHallTests
{
    [TestFixture]
    public class CinemaTests
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test, TestCaseSource(typeof(CreateNodeDataSource))]
        public void GetAllPossibleSessionsTest(Cinema cinema, List<CinemaHallSessions> expected)
        {
            //try catch
            List<CinemaHallSessions> actual = cinema.AllPossibleSessions;
            CollectionAssert.AreEqual(expected, actual);
        }

        [Test, TestCaseSource(typeof(RelevantSessionsWithOptimalTimeDataSource))]
        public void GetRelevantSessionsWithOptimalTimeTest(Cinema cinema, List<CinemaHallSessions> expected)
        {
            List<CinemaHallSessions> actual = cinema.RelevantSessionsWithOptimalTime;
            CollectionAssert.AreEqual(expected, actual);
        }

        [Test, TestCaseSource(typeof(RelevantSessionsWithAllFilmsDataSource))]
        public void GetRelevantSessionsWithAllFilmsTest(Cinema cinema, List<CinemaHallSessions> expected)
        {
            List<CinemaHallSessions> actual = cinema.RelevantSessionsWithAllFilms;
            CollectionAssert.AreEqual(expected, actual);
        }

        public class CreateNodeDataSource : IEnumerable
        {
            CinemaMocks cinemaMocks = new CinemaMocks();
            CinemaHallSessionsMocks sessionsMocks = new CinemaHallSessionsMocks();

            public IEnumerator GetEnumerator()
            {
                Cinema cinema = cinemaMocks.First();
                List<CinemaHallSessions> sessions = sessionsMocks.AllSessionsTest();
                yield return new object[] { cinema, sessions };
            }
        }

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

        public class RelevantSessionsWithAllFilmsDataSource : IEnumerable
        {
            CinemaMocks cinemaMocks = new CinemaMocks();
            CinemaHallSessionsMocks sessionsMocks = new CinemaHallSessionsMocks();

            public IEnumerator GetEnumerator()
            {
                Cinema cinema1 = cinemaMocks.First();
                List<CinemaHallSessions> sessions1 = sessionsMocks.RelevantSessionsWithAllFilmsTest1();

                Cinema cinema2 = cinemaMocks.Second();
                List<CinemaHallSessions> sessions2 = sessionsMocks.RelevantSessionsWithAllFilmsTest2();

                yield return new object[] { cinema1, sessions1 };
                yield return new object[] { cinema2, sessions2 };
            }
        }
    }
}
