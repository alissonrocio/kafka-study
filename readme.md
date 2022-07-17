# 1. Start kafka and zookeeper

```
docker-compose up
```

# 2. Change the number the partitions in topic 'topic-1' to 2

```
docker exec -it dotnet_kafka_1 /opt/bitnami/kafka/bin/./kafka-topics.sh --bootstrap-server localhost:9093 --alter --topic topic-1 --partitions 2
```
