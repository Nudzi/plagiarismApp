using System.Collections.Generic;
using plagiarismApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace plagiarismApp.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController<T, TSearch> : ControllerBase
    {
        private readonly IService<T, TSearch> _service;
        public BaseController(IService<T, TSearch> service)
        {
            _service = service;
        } 
        [HttpGet]
        public virtual IList<T> Get([FromQuery]TSearch request = default)//from query  
        {
            return _service.Get(request);
        }
        [HttpGet("{id}")]

        public virtual T GetById(int id)
        {
            return _service.GetById(id);
        }
    }
}