using Core.Entitites.Abstract;

namespace Entities.DTOs
{
    public class UserForLoginDto : IDto
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
