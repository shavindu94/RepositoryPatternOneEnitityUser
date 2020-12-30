using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    [EnableCors("AnotherPolicy")]
    public class UserController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public UserController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        // GET: api/<ItemsController>
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(_unitOfWork.Users.GetAll());
            }
            catch (Exception)
            {

                throw;
            }

        }

        // GET api/<ItemsController>/5
        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            try
            {
                return Ok(_unitOfWork.Users.GetById(id));
            }
            catch (Exception)
            {

                throw;
            }
        }

        // POST api/<ItemsController>
        [HttpPost]
        public IActionResult Post([FromBody] User user)
        {
            try
            {
                _unitOfWork.Users.Add(user);
                _unitOfWork.Complete();
                return Ok();
            }
            catch (Exception)
            {

                throw;
            }
        }

        // PUT api/<ItemsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ItemsController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                var User = _unitOfWork.Users.GetById(id);
                _unitOfWork.Users.Remove(User);

                return Ok();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
