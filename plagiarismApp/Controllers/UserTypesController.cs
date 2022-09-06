using Microsoft.AspNetCore.Mvc;
using plagiarismApp.Services;
using System.Collections.Generic;

namespace plagiarismApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserTypesController : ControllerBase
    {
        private readonly IUserTypesService _service;

        public UserTypesController(IUserTypesService service)
        {
            _service = service;
        }

        [HttpGet]
        public List<plagiarismModel.UserTypes> Get()
        {
            return _service.Get();
        }
        [HttpGet("{id}")]
        public plagiarismModel.UserTypes GetById(int id)
        {
            return _service.GetById(id);
        }
        [HttpGet]
        [Route("isAdmin/{userTypeId}")]
        public plagiarismModel.UserTypes isAdmin(int userTypeId)
        {
            return _service.isAdmin(userTypeId);
        }

    }
}
