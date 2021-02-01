using System;
using System.Collections.Generic;
using FakesAndMocks.Repositories;
using FakesAndMocks.Services.Domain;
using NUnit.Framework;

namespace FakesAndMocks.Tests
{
   public class WeatherServiceTestsWithFake
   {
      public WeatherServiceTestsWithFake()
      {
         _observationRepository = new ObservationRepositoryFake();
      }

      [Test]
      public void AverageTemperature()
      {
         var service = new WeatherService(_observationRepository);
         Assert.AreEqual(18.0, service.AverageTemperature(new DateTime(2021, 01, 15)));
      }

      private readonly IObservationRepository _observationRepository;
   }

   public class ObservationRepositoryFake : IObservationRepository
   {
      public IList<Observation> GetByDate(DateTime date)
      {
         return new List<Observation>{
             new Observation { Date = new DateTime(2021,01,15), Temperature = 17.0 },
             new Observation { Date = new DateTime(2021,01,15), Temperature = 19.0 }
         };
      }

      public Observation GetById(Guid observationId)
      {
         throw new NotImplementedException();
      }

      public Guid Save(Observation observation)
      {
         throw new NotImplementedException();
      }
   }
}
