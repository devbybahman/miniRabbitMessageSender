using System.Runtime.InteropServices.JavaScript;
using System.Text;
using Newtonsoft.Json;
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
var queue = "SendSmsQueue";
var ExchangeName = "User_Registered";
model.QueueDeclare(queue, true, false, false, null);
model.ExchangeDeclare(ExchangeName, ExchangeType.Fanout, true);
model.QueueBind(queue, ExchangeName, "");

var consumer = new EventingBasicConsumer(model);
consumer.Received += (sender, args) =>
{
  
    var result = Encoding.UTF8.GetString(args.Body.ToArray());
    var user=JsonConvert.DeserializeObject<User>(result);
    if (user !=null)
    {
        // Do something like send SMS
        Console.WriteLine($"SMS sent to {user.Phone}");
        model.BasicAck(args.DeliveryTag, false);
    }

};

model.BasicConsume(queue, false, consumer);


Console.ReadKey();