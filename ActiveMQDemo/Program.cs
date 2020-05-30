using Apache.NMS;
using Apache.NMS.ActiveMQ;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActiveMQDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var a = 123456.123.ToString("###,###");
            Console.WriteLine("Hello World!");
            StartConsumer("tom");
            StartProducer();
        }

        static void StartProducer()
        {
            using (var conn = new ConnectionFactory("tcp://localhost:61616").CreateConnection())
            using (var session = conn.CreateSession())
            {
                var producer = session.CreateProducer(new Apache.NMS.ActiveMQ.Commands.ActiveMQTopic("testing"));
                while (true)
                {
                    var msg = Console.ReadLine();
                    if (string.IsNullOrEmpty(msg))
                        break;
                    producer.Send(producer.CreateTextMessage(msg));
                }
            }
        }

        static void StartConsumer(string name)
        {
            Task.Run(() =>
            {
                using (var conn = new ConnectionFactory("tcp://localhost:61616").CreateConnection())
                {
                    conn.ClientId = name;
                    conn.Start();
                    using (var session = conn.CreateSession())
                    using (var consumer = session.CreateConsumer(new Apache.NMS.ActiveMQ.Commands.ActiveMQTopic("testing")))
                    {
                        while (true)
                        {
                            var msg = consumer.Receive();
                            Console.WriteLine("receive: " + (msg as ITextMessage).Text);
                        }
                    }
                }
            });
        }
    }
}
