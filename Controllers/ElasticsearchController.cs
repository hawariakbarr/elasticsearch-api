using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Nest;
using ElasticsearchApi.Services;
using ElasticsearchApi.Models;

namespace ElasticsearchApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ElasticsearchController : ControllerBase
    {
        private readonly IElasticsearchService _elasticsearchService;

        public ElasticsearchController(IElasticsearchService elasticsearchService)
        {
            _elasticsearchService = elasticsearchService;
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetDocumentByIdParam(string id)
        {
            var document = await _elasticsearchService.GetDocument(id);
            if (document == null)
            {
                return NotFound();
            }
            return Ok(document);
        }


        [HttpPost("search")]
        public async Task<IActionResult> SearchDocuments([FromBody] SearchRequestModel searchRequestModel)
        {
            var searchRequest = new SearchRequest("data_dj_v2")
            {
                Query = new BoolQuery
                {
                    Must = new QueryContainer[]
                    {
                        new MatchQuery { Field = "first_name", Query = searchRequestModel.Data[0].FirstName },
                        new MatchQuery { Field = "last_name", Query = searchRequestModel.Data[0].LastName },
                        new MatchQuery { Field = "birthdate", Query = searchRequestModel.Data[0].Birthdate }
                    }
                }
            };

            var response = await _elasticsearchService.SearchDocuments(searchRequest);
            if (response == null || !response.IsValid)
            {
                return StatusCode(500, "Error occurred while searching documents.");
            }
            return Ok(response.Documents);
        }

        [HttpPost("searchbyid")]
        public async Task<IActionResult> GetDocumentByQuery([FromBody] SearchQuery query)
        {

            var response = await _elasticsearchService.GetDocumentByQuery(query.Id);

            if (response == null)
            {
                return StatusCode(500, "Error occurred while searching documents.");
            }
            return Ok(response);
        }
    }
}
