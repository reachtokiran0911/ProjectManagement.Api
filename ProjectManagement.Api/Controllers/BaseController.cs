using Microsoft.AspNetCore.Mvc;
using ProjectManagement.Data.Implementation;
using ProjectManagement.Entities;
using System.Collections.Generic;


namespace ProjectManagement.Api.Controllers
{
    public class BaseController<T> : ControllerBase where T : class
    {
        private Sprint1TestStorage<T> _storage;

        public BaseController(Sprint1TestStorage<T> storage)
        {
            _storage = storage;
        }

        [Route("details")]
        [HttpGet]
        public IEnumerable<T> Get()
        {
            return _storage.GetAll();
        }

        [Route("detailsById")]
        [HttpGet]
        public IEnumerable<T> Get(long id)
        {
            return (IEnumerable<T>)_storage.GetById(id);
        }

        [Route("includeItem")]
        [HttpPost]
        public void Post(long id, [FromBody] T value)
        {
            _storage.AddOrUpdate(id, value);
        }

        [Route("changeItem")]
        [HttpPut]
        public void Put(long id, [FromBody] T value)
        {
            _storage.AddOrUpdate(id, value);
        }
    }
}
