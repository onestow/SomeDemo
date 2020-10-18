using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SimpleController : ControllerBase
    {
        private static readonly List<User> _Users = new List<User>() { new User { Id = 0, Name = "admin" } };
        [HttpGet("get/{id}")]
        public User Get(int id)
        {
            var u = _Users.FirstOrDefault(u => u.Id == id);
            if (u == null)
                Response.StatusCode = 404;
            return u;
        }
        [HttpPost("add")]
        public string Add(User user)
        {
            if (_Users.Any(u => u.Id == user.Id))
                return "id重复";
            _Users.Add(user);
            return "成功";
        }
        [HttpPut]
        public string Update(User user)
        {
            var u = _Users.FirstOrDefault(u => u.Id == user.Id);
            if (u == null)
                return "不存在id: " + user.Id;
            u.Name = user.Name;
            return "成功";
        }
        [HttpDelete]
        public string Delete(int id)
        {
            var cnt = _Users.RemoveAll(u => u.Id == id);
            if (cnt > 0)
                return "成功";
            return "不存在id: " + id;
        }
    }
}
