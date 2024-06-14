using WebApplication1.shared.Interfaces;

namespace WebApplication1.IServices
{
    public interface ILoginService
    {
        public Task<string> Login(ILoginUser loginUser);
    }
}
