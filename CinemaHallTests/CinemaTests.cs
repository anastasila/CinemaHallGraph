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
        public void CreateAndSortAllSessionsTest(Cinema cinema, List<CinemaHallSessions> expected)
        {
            List<CinemaHallSessions> actual = cinema.CreateAndSortAllSessions();
            CollectionAssert.AreEqual(expected, actual);
        }

        public class CreateNodeDataSource : IEnumerable
        {
            CinemaMocks cinemaMocks = new CinemaMocks();
            CinemaHallSessionsMocks sessionsMocks = new CinemaHallSessionsMocks();

            public IEnumerator GetEnumerator()
            {
                Cinema cinema = cinemaMocks.FirstTest();
                List<CinemaHallSessions> sessions = sessionsMocks.FirstTest();
                yield return new object[] { cinema, sessions };
            }
        }
    }
}
