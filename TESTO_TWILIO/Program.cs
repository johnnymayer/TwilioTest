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
            //1
            var client = new RestClient("https://api.twilio.com/2010-04-01");
            //2
            var request = new RestRequest("Accounts/AC6b52bfb712ad0fbb58799aea43ea5b09/Messages", Method.POST);
            //3
            request.AddParameter("To", "+15039335980");
            request.AddParameter("From", "+19715992478");
            request.AddParameter("Body", "Henlo dingdong, this another testo!");
            //4
            client.Authenticator = new HttpBasicAuthenticator("AC6b52bfb712ad0fbb58799aea43ea5b09", "4608382d073888bb7d31ca6544d4da4b");
            //5
            client.ExecuteAsync(request, response =>
            {
                Console.WriteLine(response);
            });
            Console.ReadLine();
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
