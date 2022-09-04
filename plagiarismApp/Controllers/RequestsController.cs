using plagiarismApp.Services;
using plagiarismModel.TableRequests.Requests;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace plagiarismApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestsController : ControllerBase
    {
        private readonly IRequestsService _service;
        public RequestsController(IRequestsService service)
        {
            _service = service;
        }
        [HttpGet]
        public List<plagiarismModel.Requests> Get([FromQuery] RequestsSearchRequest request)
        {
            return _service.Get(request);
        }
        [HttpGet("{id}")]
        public plagiarismModel.Requests GetById(int id)
        {
            return _service.GetById(id);
        }

        [HttpPost]
        public plagiarismModel.Requests Insert(RequestsUpsertRequest request)
        {
            return _service.Insert(request);
        }
        [HttpPut("{id}")]
        public void Update(int id, [FromBody]RequestsUpsertRequest request)
        {
             _service.Update(id, request);
        }
        [HttpDelete("{id}")]
        public plagiarismModel.Requests Delete(int id)
        {
            return _service.Delete(id);
        }
    }
}
