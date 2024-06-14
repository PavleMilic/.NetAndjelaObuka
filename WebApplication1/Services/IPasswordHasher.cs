namespace WebApplication1.Services
{
    public interface IPasswordHasher
    {
        public string GenerateSalt();
        public string Hash(string password, string salt);
        public bool Verify(string passwordHash, string inputPassword);
    }
}
