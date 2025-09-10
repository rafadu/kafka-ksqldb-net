using Confluent.Kafka;
using System.Text.Json;

var config = new ProducerConfig {BootstrapServers = "localhost:29092"};

using var producer = new ProducerBuilder<Null,string>(config).Build();

while (true){
    Console.Write("Digite o tipo da mensagem (A/B) ou 'sair':");
    var type = Console.ReadLine();
    if (type?.ToLower() == "sair") break;

    if(type==null){
        Console.WriteLine("Vamos tentar de novo...");
        continue;
    }

    var message = new MessagePayload{
        Id = Guid.NewGuid().ToString(),
        Type = type.ToUpper(),
        Payload = $"Mensagem teste {DateTime.Now}"
    };

    var json = JsonSerializer.Serialize(message);

    await producer.ProduceAsync("topic_input", new Message<Null, string>{ Value = json});
    Console.WriteLine($"Mensagem enviada: {json}");
}


public class MessagePayload{
    public string Id {get; set;} = default!;
    public string Type {get; set;} = default!;
    public string Payload {get; set;} = default!;

}
