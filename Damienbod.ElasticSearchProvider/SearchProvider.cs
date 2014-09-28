using System;
using System.Collections.Generic;
using System.Globalization;
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
			_logProvider.ElasticSearchProviderVerbose("SearchProvider construction");
		}

		public void CreateAnimal(Animal animal)
		{
			ValidateIfIdIsAlreadyUsedForIndex(animal.Id.ToString(CultureInfo.InvariantCulture));
			var index = _elasticsearchClient.Index(animal, i => i
			   .Index("Animal.SearchIndex")
			   .Type("animal")
			   .Id(animal.Id)
			   .Refresh()
			   .Ttl("1m")
			   );
			_logProvider.ElasticSearchProviderVerbose(string.Format("Created animal: {0}, {1}", animal.Id, animal.AnimalType));
		}

		private void ValidateIfIdIsAlreadyUsedForIndex(string id)
		{
			var idsList = new List<string> { id };
			var result = _elasticsearchClient.Search<Animal>(s => s
				.Index("animals")
				.AllTypes()
				.Query(p => p.Ids(idsList)));
			if (result.Documents.Any()) throw new ArgumentException("Id already exists in store");
		}

		public void UpdateAnimal(Animal animal)
		{

			var index = _elasticsearchClient.Index(animal, i => i
				.Index("Animal.SearchIndex")
				.Type("animal")
				.Id(animal.Id)
				.Refresh()
				.Ttl("1m")
				);

			_logProvider.ElasticSearchProviderVerbose(string.Format("Updated animal: {0}, {1}", animal.Id, animal.AnimalType));
		}

		public IEnumerable<Animal> GetAnimals()
		{
			var result = _elasticsearchClient.Search<Animal>(s => s
					.Index("animals")
					.AllTypes()
					.MatchAll().Size(250)
				);
			return result.Documents.ToList();
		}

		public void DeleteById(int id)
		{
			_logProvider.ElasticSearchProviderVerbose(string.Format("Sending DELETE animal type from animals index with id: {0}", id));
			_elasticsearchClient.Delete<Animal>(id);
		}

		public void DeleteIndex(string index)
		{
			_logProvider.ElasticSearchProviderWarning(string.Format("Sending DELETE index: {0}", index));
			_elasticsearchClient.DeleteIndex(s => s.Index(index));
		}

		public Animal GetAnimal(int id)
		{
			var idsList = new List<string> { id.ToString(CultureInfo.InvariantCulture) };
			var result = _elasticsearchClient.Search<Animal>(s => s
				.Index("animals")
				.AllTypes()
				.Query(p => p.Ids(idsList)));

			return result.Documents.First();
		}
	}
}
