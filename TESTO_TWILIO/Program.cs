using System;
using System.Threading.Tasks;
using RestSharp;
using RestSharp.Authenticators;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace TESTO_TWILIO
{
    class Program
    {
        static void Main(string[] args)
        {
            
            SendSms().Wait();
            Console.Write("Press any key to continue.");
            Console.ReadKey();
        }

        static async Task SendSms()
        {
            var accountSid = "AC6b52bfb712ad0fbb58799aea43ea5b09";
            var authToken = "4608382d073888bb7d31ca6544d4da4b";

            TwilioClient.Init(accountSid, authToken);

            var message = await MessageResource.CreateAsync(
                to: new PhoneNumber("+15039335980"),
                from: new PhoneNumber("+19715992478"),
                body: "Henlo from c charp, you're really doing it now.");

            Console.WriteLine(message.Sid);
        }
    }
}
