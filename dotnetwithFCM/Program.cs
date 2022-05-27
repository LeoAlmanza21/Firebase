using FirebaseAdmin;
using FirebaseAdmin.Messaging;
using Google.Apis.Auth.OAuth2;

Console.WriteLine("Hello, World!");


FirebaseApp.Create(new AppOptions()
{
    //ruta del json de configuracion
    Credential = GoogleCredential.FromFile(@"C:\Users\Leo\Downloads\cloud-message-5c4a5-firebase-adminsdk-jvff1-84de736254.json"),
});

// The topic name can be optionally prefixed with "/topics/".
var topic = "perronegro";

// See documentation on defining a message payload.
var message = new Message()
{
    Data = new Dictionary<string, string>()
    {
        { "score", "850" },
        { "time", "2:45" },
    },
    Topic = topic,
    Notification = new Notification()
    {
        Title = "$GOOG up 1.43% on the day",
        Body = "$GOOG gained 11.80 points to close at 835.67, up 1.43% on the day.",
    }
};

// Send a message to the devices subscribed to the provided topic.
string response = await FirebaseMessaging.DefaultInstance.SendAsync(message);
// Response is a message ID string.
Console.WriteLine("Successfully sent message: " + response);
