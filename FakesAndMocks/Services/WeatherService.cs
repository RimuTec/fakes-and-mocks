using System;
using System.Linq;
using FakesAndMocks.Repositories;
using FakesAndMocks.Services.Domain;

namespace FakesAndMocks
{
   public class WeatherService
   {
      public WeatherService(IObservationRepository observationRepository)
      {
         _observationRepository = observationRepository;
      }

      public double AverageTemperature(DateTime date)
      {
         var observations = _observationRepository.GetByDate(date);
         var average = observations.Aggregate<Observation, double>(0, (total, observation) => total + observation.Temperature) / observations.Count;
         return average;
      }

      private readonly IObservationRepository _observationRepository;
   }
}
