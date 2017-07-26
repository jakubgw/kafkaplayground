using System;
using System.Text;
using System.Collections.Generic;
using Confluent.Kafka.Serialization;
using Confluent.Kafka;

namespace KafkaPlayGround.Producer
{
    class Program
    {
        static void Main(string[] args)
        {              
            string brokerList = args[0];
            string topicName = args[1];
            Console.WriteLine(brokerList);
            Console.WriteLine(topicName);
            var config = new Dictionary<string, object> { { "bootstrap.servers", brokerList } };

            using (var producer = new Producer<Null, string>(config, null, new StringSerializer(Encoding.UTF8)))
            {
                Console.WriteLine($"{producer.Name} producing on {topicName}. q to exit.");

                string text;
                while ((text = Console.ReadLine()) != "q")
                {
                    var deliveryReport = producer.ProduceAsync(topicName, null, text);
                    deliveryReport.ContinueWith(task =>
                    {
                        Console.WriteLine($"Partition: {task.Result.Partition}, Offset: {task.Result.Offset}");
                    });
                }

                // Tasks are not waited on synchronously (ContinueWith is not synchronous),
                // so it's possible they may still in progress here.
                producer.Flush(TimeSpan.FromSeconds(10));
            }
        }
    }
}
