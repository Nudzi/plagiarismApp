using Microsoft.AspNetCore.Mvc;
using plagiarismApp.Services;
using plagiarismModel.TableRequests.Documents;
using System.Collections.Generic;

namespace plagiarismApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentsController : ControllerBase
    {
        private readonly IDocumentsService _service;
        public DocumentsController(IDocumentsService service)
        {
            _service = service;
        }
        [HttpGet]
        public List<plagiarismModel.Documents> Get([FromQuery] DocumentsSearchRequest request)
        {
            return _service.Get(request);
        }
        [HttpGet("{id}")]
        public plagiarismModel.Documents GetById(int id)
        {
            return _service.GetById(id);
        }

        [HttpPost]
        public plagiarismModel.Documents Insert(DocumentsUpsertRequest request)
        {
            return _service.Insert(request);
        }
        [HttpPut("{id}")]
        public void Update(int id, [FromBody] DocumentsUpsertRequest request)
        {
            _service.Update(id, request);
        }
        [HttpGet]
        [Route("plagiarism")]
        public List<plagiarismModel.Documents> Plagiarism([FromQuery] DocumentsSearchRequest request)
        {
            return _service.Plagiarism(request);
        }
    }
}
