using System;
using System.Collections.Generic;
using System.Linq;
using Damienbod.BusinessLayer.Attributes;
using Damienbod.BusinessLayer.DomainModel;
using Damienbod.BusinessLayer.Providers;
using Nest;

namespace Damienbod.ElasticSearchProvider
{
    [TransientLifetime]
    public class SearchProvider : ISearchProvider
    {
        private readonly ILogProvider _logProvider;
        private readonly ElasticClient _elasticsearchClient;

        public SearchProvider(ILogProvider logProvider)
        {
            _logProvider = logProvider;
            var uri = new Uri("http://localhost:9200");
            var settings = new ConnectionSettings(uri).SetDefaultIndex("animals");
            _elasticsearchClient = new ElasticClient(settings);
        }

        public void CreateAnimal(Animal animal)
        {
            _elasticsearchClient.Index(animal, Animal.SearchIndex, animal.AnimalType);
        }

        public void UpdateAnimal(Animal animal)
        {
            _elasticsearchClient.Update<Animal>(u => u
                    .Object(animal)
                    .Script("ctx._source.loc += 10")
                    .RetriesOnConflict(5)
                    .Refresh()
             );
        }

        public IEnumerable<Animal> GetAnimals()
        {
            var result = _elasticsearchClient.Search<Animal>(s => s
                    .Index("animals")
                    .AllTypes()
                    .MatchAll()
                );
            return result.Documents.ToList();
        }
    }
}
