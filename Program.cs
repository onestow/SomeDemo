using Apache.NMS;
using Apache.NMS.ActiveMQ;
using System;
using System.Threading.Tasks;

namespace ActiveMQDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            StartConsumer("tom");
            StartProducer();
        }

        static void StartProducer()
        {
            using var conn = new ConnectionFactory("tcp://localhost:61616").CreateConnection();
            using var session = conn.CreateSession();
            var producer = session.CreateProducer(new Apache.NMS.ActiveMQ.Commands.ActiveMQTopic("testing"));
            while (true)
            {
                var msg = Console.ReadLine();
                if (string.IsNullOrEmpty(msg))
                    break;
                producer.Send(producer.CreateTextMessage(msg));
            }
        }

        static void StartConsumer(string name)
        {
            using var conn = new ConnectionFactory("tcp://localhost:61616").CreateConnection();
            using var session = conn.CreateSession();
            var consumer = session.CreateDurableConsumer(new Apache.NMS.ActiveMQ.Commands.ActiveMQTopic("testing"), name, null, false);
            consumer.Listener += new Apache.NMS.MessageListener(msg =>
            {
                Console.WriteLine("receive: " + (msg as ITextMessage).Text);
            });
        }
    }
}
