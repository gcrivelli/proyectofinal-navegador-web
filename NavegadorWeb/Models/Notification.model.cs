namespace NavegadorWeb.Models
{
    public class Notification
    {
        public string evento { get; set; }
        public string message { get; set; }

        public string type = "helpUrl";
        public string data { get; set; }
    }
}
