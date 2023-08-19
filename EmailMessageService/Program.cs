using EmailMessageService;

internal class Program
{
    private static void Main(string[] args)
    {
        //For email
        EmailClass.Email("email", "subject", "message");
        // For whatsApp
        SendWhatsUpClass.SendMessage("phone number", "message");
    }
}