using Confluent.Kafka;

if(args.Length != 1)
{
    Console.WriteLine("Coloque somente a letra que representa o tópico consumido...");
    Environment.Exit(1);
}

string topicLetter = args.First().ToString();
string groupId = $"consumer_group_{topicLetter}";
string topicName = $"topic_type_{topicLetter}";
var config = new ConsumerConfig{
    BootstrapServers = "localhost:29092",
    GroupId = groupId,
    AutoOffsetReset = AutoOffsetReset.Earliest
};

using var consumer = new ConsumerBuilder<Ignore,string>(config).Build();

consumer.Subscribe(topicName);

Console.WriteLine($"Consumindo mensagens de {topicName}...");

while(true){
    var cr = consumer.Consume();
    Console.WriteLine($"Mensagem recebida: {cr.Message.Value}");
}
