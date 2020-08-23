using CinemaHall;
using CinemaHallTests.DataSource;
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
            try
            {
                List<CinemaHallSessions> actual = cinema.AllPossibleSessions;                
                CollectionAssert.AreEqual(expected, actual);
                
            }
            catch(ArgumentOutOfRangeException)
            {
                Assert.Throws<ArgumentOutOfRangeException>(() =>
                {

                    cinema.CinemaHallException();
                    cinema.NodeException();

                });
                
            }
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
    }
}
