namespace Venhancer.Crowd.Dtos
{
    public class CreateTokenDto
    {
        public class Request
        {
            public string? client_id { get; set; }
            public string? client_secret { get; set; }
            public string? grant_type { get; set; }
            public string? username { get; set; }
            public string? password { get; set; }
        }
        public class Response
        {
            public string? access_token { get; set; }
            public int? expires_in { get; set; }
            public string? token_type { get; set; }
            public string? refresh_token { get; set; }
            public string? scope { get; set; }
        }
    }
}
