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
         DateTime date = new(2021, 01, 15);
         // Older C# syntax: DateTime date = new DateTime(2021, 01, 15);
         var observations = new List<Observation>{
             new Observation { Date = date, Temperature = 17.0 },
             new Observation { Date = date, Temperature = 19.0 }
            };
         var mock = new Mock<IObservationRepository>();
         mock.Setup(repo => repo.GetByDate(date)).Returns(observations);
         var observationRepository = mock.Object;
         var service = new WeatherService(observationRepository);
         Assert.AreEqual(18.0, service.AverageTemperature(date));
         mock.Verify(repo => repo.GetByDate(date), Times.Once);
      }
   }
}
