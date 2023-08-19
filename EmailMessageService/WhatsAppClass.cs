using System;
using Twilio;
using Twilio.Types;
using Twilio.Rest.Api.V2010.Account;
using System.Linq;
using WhatsAppApi;

namespace EmailMessageService
{
    internal class SendWhatsUpClass
    {
        private const string WHATSUP_TWILIO_SID = "AC3b06ddca9622339beb9bb67b2f7d9b72";
        private const string AUTH_TWILIO_TOKEN = "a95216af50fa8dbcf904cc3ffb384b53";
        private const string TWILIO_PHONE = "+37494XXXXXX";

        private const string WHATSAPP_SEND_FROM = "";
        private const string WHATSAPP_SEND_FROM_PASS = "";

        public static void SendMessage(string phoneTo, string messageTo)
        {
            WhatsApp wa = new WhatsApp(WHATSAPP_SEND_FROM, WHATSAPP_SEND_FROM_PASS, "text", false, false);

            wa.OnConnectSuccess += () =>
            {
                wa.OnLoginSuccess += (phone, data) =>
                {
                    wa.SendMessage(phoneTo, messageTo);
                };
                wa.OnLoginFailed += (data) =>
                {

                };
                wa.Login();
            };
            wa.OnConnectFailed += (ex) => {
            };
            wa.Connect();
        }

        public static void TwilioSendMessage(string phoneTo, string sendMessage)
        {
            TwilioClient.Init(WHATSUP_TWILIO_SID, AUTH_TWILIO_TOKEN);
            var message = MessageResource.Create(
                from: new Twilio.Types.PhoneNumber("whatsapp:" + TWILIO_PHONE + ""), // format is +374XXXXXXXX
                body: sendMessage,
                to: new Twilio.Types.PhoneNumber("whatsapp:" + phoneTo + "") // format is +374XXXXXXXX
                );
            Console.WriteLine(message.Sid);

        }
    }
}
