using WebApplication1.shared.Interfaces;

namespace WebApplication1.DTO
{
    public class LoginUserDTO : ILoginUser
    {
         public string UserName { get; set; }
        public string Password { get; set; }
    }
}

