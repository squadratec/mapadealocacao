using System.Security.Claims;

namespace SQH.Entities.SQHoras
{
    public class AuthRetorno
    {
        public bool Authenticated { get; set; }

        public ClaimsIdentity Claims { get; set; }

        public string Message { get; set; }
    }
}
