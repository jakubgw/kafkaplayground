1. To run zookeeper 
   .\bin\windows\zookeeper-server-start.bat config/zookeeper.properties
2. To run kafka server
    .\bin\windows\kafka-server-start.bat config\server.properties
3. To create topic  
    .\bin\windows\kafka-topics.bat --create --topic test_topic --zookeeper localhost:2181 --replication-factor 1 --partitions 1
4. To run sample producer 
    .\bin\windows\kafka-console-producer.bat --broker-list localhost:9092 --topic test_topic
5. To run sample consuper 
    .\bin\windows\kafka-console-consumer.bat --zookeeper localhost:2181 --topic test_topic --from-beginning

--

6. To run custom brokers  - I have changed broker id, port and log dir    
    .\bin\windows\kafka-server-start.bat playground\config\server.1.properties
    .\bin\windows\kafka-server-start.bat playground\config\server.2.properties
    .\bin\windows\kafka-server-start.bat playground\config\server.3.properties

7. Create topic with  replication    
    .\bin\windows\kafka-topics.bat --create --topic replication_topic --zookeeper localhost:2181 --replication-factor 3 --partitions 1

