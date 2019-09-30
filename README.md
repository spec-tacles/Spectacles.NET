# Spectacles.NET

A distributed Discord API wrapper.

## Pre-installing
Download & Install [RabbitMQ](https://www.rabbitmq.com/download.html)

## Getting Started

### Broker

#### AMQP
Create a Broker
```csharp
var broker = new AMQPBroker("Group", "OptionalSubGroup");
```

Register the EventListener
```csharp
broker.Receive += (sender, receiveArgs) => 
{
	// Handle Incomming Message
}
```

Connect the Broker
```csharp
await broker.ConnectAsync();
```
### Gateway

Start by creating either a Cluster (which hold an amount of Shards) or Shard(s) and subscribing to the Events they emit
```csharp
// Collection of Shards
var cluster = new Cluster("TOKEN");

// or

// Single Shard
var shard = new Shard("TOKEN")
```

Register the EventListener to Log & Push dispatches to RabbitMQ via the Broker
```csharp
clusterOrShard.Dispatch += (sender, receiveArgs) 
	=> Task.Run(() =>
		broker.PublishAsync(Enum.GetName(typeof(GatewayEvent), dispatchArgs.Event),
			Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(dispatchArgs.Data, Formatting.None,
				new JsonSerializerSettings {NullValueHandling = NullValueHandling.Ignore}))));

clusterOrShard.Log += (sender, log) 
	=> Console.WriteLine($"{DateTime.Now:HH:mm:ss tt} {logArgs.LogLevel} [{logArgs.Sender}] {logArgs.Message}");

clusterOrShard.Error += (sender, errorArgs) 
	=> Console.WriteLine($"{DateTime.Now:HH:mm:ss tt} ERROR [SHARD {errorArgs.ShardID}] {errorArgs.Exception}");
```

Connect the Gateway
```csharp
clusterOrShard.ConnectAsync();
```

Subscribe to the Shard Events

### Worker

Create Rest Client
```csharp
var rest = new RestClient("TOKEN");
```

Handle incomming Dispatches
```csharp
broker.Receive += (sender, receiveArgs) => 
{
	var data = Encoding.UTF8.GetString(receiveArgs.Data);
	var event = (GatewayEvent) Enum.Parse(typeof(GatewayEvent), receiveArgs.Event);
	if (event == GatewayEvent.MESSAGE_CREATE) {
		var message = JsonConvert.DeserializeObject<Message>(data);
		if (message.Content != "!ping") return;
		await rest.Channels[Message.ChannelID].Messages.PostAsync<Message>(
				new SendableMessage
				{
					Content = "Pong!"
				}, null);
	}
}
```

## Installing
You can download Spectacles.NET Releases from Nuget [here](https://www.nuget.org/packages?q=Spectacles.Net).

## Versioning

We use [SemVer](http://semver.org/) for versioning. For the versions available, see the [tags on this repository](https://github.com/spec-tacles/Spectacles.NET/tags). 

## Authors

* **DevYukine** - *Initial work* - [DevYukine](https://github.com/Dev-Yukine)

See also the list of [contributors](https://github.com/spec-tacles/Spectacles.NET/contributors) who participated in this project.

## License

This project is licensed under the MIT License - see the [LICENSE.md](https://github.com/spec-tacles/Spectacles.NET/blob/master/LICENSE) file for details