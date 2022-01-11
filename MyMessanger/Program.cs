using System;
using Newtonsoft.Json;
using MyMessanger;

namespace MyMessanger
{
    class Program
    {
        private static int MessageID;
        private static string UserName;
        private static MessangerClientAPI API = new MessangerClientAPI();
        
        private static void GetNewMessages()
        {
            Message msg = API.GetMessage(MessageID);
            while(msg != null)
            {
                Console.WriteLine(msg);
                MessageID++;
                msg = API.GetMessage(MessageID);
            }
        }

        static void Main(string[] args)
        {
            /* Message msg = new Message("Maksim", "Hello", DateTime.UtcNow);
             string output = JsonConvert.SerializeObject(msg);
             Console.WriteLine(output);
             Message deserealizedMsg = JsonConvert.DeserializeObject<Message>(output);
             Console.WriteLine(deserealizedMsg);
             //{ "UserName":"RusAl","MessageText":"Hello","TimeStamp":"2022-01-10T06:00:51.5841281Z"}
             //RusAl, < 10.01.2022 06:00:51 >: Hello*/
            MessageID = 1;
            Console.WriteLine("Enter your name: ");
            UserName = Console.ReadLine();
            string MessageText = "";
            while (MessageText != "exit")
            {
                GetNewMessages();
                MessageText = Console.ReadLine();
                if (MessageText.Length > 1)
                {
                    Message SendMsg = new Message(UserName, MessageText, DateTime.Now);
                    API.SendMessage(SendMsg);
                }
            }
        }
    }
}
