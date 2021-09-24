using Newtonsoft.Json.Converters;
using System;
using System.IO;
using System.Net;
using System.Text;


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

            while (msg != null)
            {
                Console.WriteLine(msg);
                MessageID++;
                msg = API.GetMessage(MessageID);
            }
        }

        static void Main(string[] args)
        {
            //Message msg = new Message("RusAl", "Hello", DateTime.UtcNow);

            //string output = JsonConvert.SerializeObject(msg);

            //Console.WriteLine(output);

            //Message deserializeMsg = JsonConvert.DeserializeObject<Message>(output);

            //Console.WriteLine(deserializeMsg);

            //{ "UserName":"RusAl","MessageText":"Hello","TimeStamp":"2021-09-23T15:36:10.706071Z"}
            //RusAl < 9 / 23 / 2021 3:36:10 PM >: Hello

            MessageID = 1;

            Console.WriteLine("Insert your name:");

            UserName = Console.ReadLine();

            string MessageText = "";

            while (MessageText != "exit")
            {
                GetNewMessages();
                MessageText = Console.ReadLine();

                if (MessageText.Length > 1)
                {
                    Message sendMsg = new Message(UserName, MessageText, DateTime.Now);
                    API.SendMessage(sendMsg);
                }
            }

        }
    }
}
