using Nest;

namespace ElasticsearchApi.Services
{
    public interface IElasticsearchService
    {
        Task<object> GetDocument(string id);
        Task<ISearchResponse<object>> SearchDocuments(SearchRequest searchRequest);
        Task<object> GetDocumentByQuery(string id);
    }

}
