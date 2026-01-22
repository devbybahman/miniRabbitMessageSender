using RabbitMQ.Client;
using System.Text;
Console.WriteLine("Please Enter Your PhoneNumber :");
var phone = Console.ReadLine();
// create connection
var ConnectionFactory = new ConnectionFactory()
{
    HostName = "localHost",
    UserName = "guest",
    Password = "guest",
};
// create conn with RabbitMQ
var connection = ConnectionFactory.CreateConnection();
// create Channel
var model = connection.CreateModel();
// create a queue 
var queue = "register_user";
model.QueueDeclare(queue, true, false, false, null);
// create a publish
if (phone != null)
{
    //first . create Body Message to Byte
    var body = Encoding.UTF8.GetBytes(phone.ToString());
    //     "Direct",RoutingKey==QueueName Bezar
    model.BasicPublish("", queue, null, body);
}
Console.ReadKey();
