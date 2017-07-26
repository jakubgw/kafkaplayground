using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Confluent.Kafka;
using Confluent.Kafka.Serialization;

namespace KafkaPlayGround.ConsumerSubscribe
{
    class Program
    {
        static void Main(string[] args)
		{
			string brokerList = args[0];
			var topics = args.Skip(1).ToList();

			var config = new Dictionary<string, object>
			{
				{ "group.id", "simple-csharp-consumer" },
				{ "bootstrap.servers", brokerList }
			};

			using (var consumer = new Consumer<Null, string>(config, null, new StringDeserializer(Encoding.UTF8)))
			{
				consumer.Subscribe(topics.First());



				while (true)
				{
					Message<Null, string> msg;
					if (consumer.Consume(out msg, TimeSpan.FromSeconds(1)))
					{
						Console.WriteLine($"Topic: {msg.Topic} Partition: {msg.Partition} Offset: {msg.Offset} {msg.Value}");
					}
				}
			}
		}
    }
}