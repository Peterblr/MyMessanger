using Newtonsoft.Json;
using System;


namespace MyMessanger
{
    class Program
    {
        static void Main(string[] args)
        {
            Message msg = new Message("RusAl", "Hello", DateTime.UtcNow);

            string output = JsonConvert.SerializeObject(msg);

            Console.WriteLine(output);

            Message deserializeMsg = JsonConvert.DeserializeObject<Message>(output);

            Console.WriteLine(deserializeMsg);

            //{ "UserName":"RusAl","MessageText":"Hello","TimeStamp":"2021-09-23T15:36:10.706071Z"}
            //RusAl < 9 / 23 / 2021 3:36:10 PM >: Hello
        }
    }
}
