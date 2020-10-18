using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RESTfulServer
{

    [ApiController]
    [Route("[controller]")]
    public class SimpleController : ControllerBase
    {
        private static List<User> _Users = new List<User>();

        [HttpGet]
        public IEnumerable<User> GetAll()
        {
            return _Users;
        }

        [HttpGet("{id}")]
        public User Get(int id)
        {
            return _Users.FirstOrDefault(u => u.Id == id);
        }
    }
}
