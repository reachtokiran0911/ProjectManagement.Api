using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;


namespace ProjectManagement.Api.Controllers
{
    public class BaseController<T> : ControllerBase 
    {
        [HttpGet]
        public IEnumerable<T> Get()
        {
            return GetData();
        }

        [HttpGet]
        [Route("{id:long}")]
        public IActionResult Get(long id)
        {
            var data = GetDataById(id);
            if (data != null)
            {
                return Ok(data);
            }
            return BadRequest("no data found for the ID");
        }

        [HttpPost]
        [Route("Update")]
        public IActionResult Post(T data)
        {
            return UpdateData(data);
        }

        [HttpPut]
        [Route("Add")]
        public IActionResult Put(T data)
        {
            return AddData(data);
        }

        [HttpDelete("{id:long}")]
        public IActionResult Delete(long id)
        {
            if (DeleteData(id))
            {
                return Ok();
            }
            return BadRequest();
        }

        protected virtual IActionResult UpdateData(T data)
        {
            throw new NotImplementedException();
        }

        protected virtual bool DeleteData(long id)
        {
            throw new NotImplementedException();
        }
        protected virtual IActionResult AddData(T Data)
        {
            throw new NotImplementedException();
        }

        protected virtual T GetDataById(long id)
        {
            throw new NotImplementedException();
        }

        protected virtual IEnumerable<T> GetData()
        {
            throw new NotImplementedException();
        }
    }
}
