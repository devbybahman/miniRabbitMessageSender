using Newtonsoft.Json;
using RabbitMQ.Client;
using System.ComponentModel.DataAnnotations;
using System.Text;
Console.WriteLine("Please Enter Your Email :");
var email = Console.ReadLine();
Console.WriteLine("Please Enter Your Phone :");
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
var ExchangeName = "User_Registered";
model.QueueDeclare(queue, true, false, false, null);
model.ExchangeDeclare(ExchangeName, ExchangeType.Fanout, true);
// create a publish
if (email != null)
{
    var user = new User()
    {
        Email = email,
        Phone=phone
    };
    //convert object to json
    var userConvert=JsonConvert.SerializeObject(user);

    //first . create Body Message to Byte
    var body = Encoding.UTF8.GetBytes(userConvert);
    //     "Fanout Exchange",RoutingKey== mohem nist dar Fanout
    model.BasicPublish(ExchangeName, queue, null, body);
}
Console.ReadKey();
