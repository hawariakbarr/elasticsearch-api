using Nest;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace ElasticsearchApi.Services
{ 

    public class ElasticsearchService : IElasticsearchService
    {
        private readonly IElasticClient _elasticClient;
        private readonly ILogger<ElasticsearchService> _logger;

        public ElasticsearchService(IElasticClient elasticClient, ILogger<ElasticsearchService> logger)
        {
            _elasticClient = elasticClient;
            _logger = logger;
        }

        public async Task<object> GetDocument(string id)
        {
            try
            {
                var response = await _elasticClient.GetAsync<object>(id);
                if (!response.IsValid)
                {
                    _logger.LogError($"Failed to get document: {response.OriginalException.Message}");
                    return response.Source;
                }
                return response.Source;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error getting document: {ex.Message}");
                return $"Error getting document: {ex.Message}";
            }
        }

        public async Task<ISearchResponse<object>?> SearchDocuments(SearchRequest searchRequest)
        {
            try
            {
                var response = await _elasticClient.SearchAsync<object>(searchRequest);
                if (!response.IsValid)
                {
                    _logger.LogError($"Failed to search documents: {response.OriginalException.Message}");
                }
                return response;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error searching documents: {ex.Message}");
                return null;
            }
        }

        public async Task<object> GetDocumentByQuery(string id)
        {
            try
            {
                var response = await _elasticClient.SearchAsync<object>(s => s
                     //.Index("data_dj_v2") already set in program.cs
                     .Query(q => q
                         .Match(m => m
                             .Field("_id")
                             .Query(id)
                         )
                     )
                 );

                if (!response.IsValid || response.Documents.Count == 0)
                {
                    return response.HitsMetadata.Hits;
                }

                return response.HitsMetadata.Hits;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error getting document: {ex.Message}");
                return $"Error getting document: {ex.Message}";
            }
        }
    }

}
