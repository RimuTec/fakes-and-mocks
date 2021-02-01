using System;
using System.Collections.Generic;
using FakesAndMocks.Services.Domain;

namespace FakesAndMocks.Repositories
{
   /// <summary>
   /// Provides storage functionality for Observation objects.
   /// </summary>
   /// <remarks>
   /// Mediates between the domain and data mapping layers using a collection-like
   /// interface for accessing domain objects. For more info please see
   /// https://www.martinfowler.com/eaaCatalog/repository.html
   /// </remarks>
   public interface IObservationRepository
   {
      IList<Observation> GetByDate(DateTime date);
      Observation GetById(Guid observationId);
      Guid Save(Observation observation);
   }
}
