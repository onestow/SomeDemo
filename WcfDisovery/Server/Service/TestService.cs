using SContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Server.Service
{
    public class TestService : ITestService
    {
        public string Hello(string name)
        {
            return "hello, " + name;
        }
    }
}
