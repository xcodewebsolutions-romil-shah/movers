namespace MoverAndStore.WebApp.Models
{
    public class SendMailRequestDto
    {
        public string FromEmailAddress { get; set; }
        public string Alias { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public string ToEmailAddress { get; set; }
        public string CcEmailAddress { get; set; }
        public string BccEmailAddress { get; set; }
    }
}
