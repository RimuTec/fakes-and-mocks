using System;
using System.Collections.Generic;
using FakesAndMocks.Repositories;
using FakesAndMocks.Services.Domain;
using Moq;
using NUnit.Framework;

namespace FakesAndMocks.Tests
{
   public class WeatherServiceTestsWithMock
   {
      [Test]
      public void AverageTemperature()
      {
         var observations = new List<Observation>{
             new Observation { Date = new DateTime(2021,01,15), Temperature = 17.0 },
             new Observation { Date = new DateTime(2021,01,15), Temperature = 19.0 }
            };
         var mock = new Mock<IObservationRepository>();
         mock.Setup(repo => repo.GetByDate(It.IsAny<DateTime>())).Returns(observations);
         var observationRepository = mock.Object;
         var service = new WeatherService(observationRepository);
         Assert.AreEqual(18.0, service.AverageTemperature(new DateTime(2021, 01, 15)));
      }
   }
}
