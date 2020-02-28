using Server.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    class Program
    {
        static void Main(string[] args)
        {
            StartService();
        }

        static void StartService()
        {
            using (var host = new ServiceHost(typeof(TestService)))
            {
                host.Open();
                Console.WriteLine(string.Join(Environment.NewLine, host.Description.Endpoints.Select(ep=>ep.ListenUri.AbsoluteUri)));
                Console.WriteLine("ok");
                Console.ReadKey();
            }
        }
    }
}
