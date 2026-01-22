using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

var ConnectionFactory = new ConnectionFactory()
{
    HostName = "localHost",
    UserName = "guest",
    Password = "guest",
};
var connection = ConnectionFactory.CreateConnection();
var model = connection.CreateModel();
var queue = "register_user";
model.QueueDeclare(queue, true, false, false, null);

var consumer = new EventingBasicConsumer(model);
consumer.Received += (sender, args) =>
{
    var result = Encoding.UTF8.GetString(args.Body.ToArray());
    if (true)
    {
        // Do something like send SMS
        Console.WriteLine($"Hi {result}");
        model.BasicAck(args.DeliveryTag, false);
    }

};

model.BasicConsume(queue, false, consumer);


Console.ReadKey();