namespace Desk.Domain.Auth
{
    public class ResponseBase
    {
        public string ContentType => "application/json";

        public int StatusCode { get; set; }

        public string Messege { get; set; }
    }
}
