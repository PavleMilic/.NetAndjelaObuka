using System.Security.Cryptography;
using WebApplication1.Services;


namespace WebApplication1
{
    public class PasswordHasher : IPasswordHasher
    {
        private const int SaltSize = 128 / 8; // imace 16 bajtova
        private const int KeySize = 256 / 8; // mora da bude iste velicine kao i Hashing Algoritam
        private const int Iterations = 10000; // po defaultu;
        private static readonly HashAlgorithmName _hashAlgoirthmName = HashAlgorithmName.SHA256;
        private static char Delimiter = ';';
                               
     
        public string GenerateSalt()
        {
            var salt = RandomNumberGenerator.GetBytes(SaltSize);
            return Convert.ToBase64String(salt);
        }

        public string Hash(string password, string salt)
        {
            var saltBytes = Convert.FromBase64String(salt);
            var hash = Rfc2898DeriveBytes.Pbkdf2(password, saltBytes, Iterations, _hashAlgoirthmName, KeySize);

            string hashedPassword = string.Join(Delimiter, Convert.ToBase64String(saltBytes), Convert.ToBase64String(hash));
            return hashedPassword;


        }

        public bool Verify(string passwordHash, string inputPassword)
        {
             String[] elements  = passwordHash.Split(Delimiter);
            var salt = Convert.FromBase64String(elements[0]);
            var hash = Convert.FromBase64String(elements[1]);

            var hashInput = Rfc2898DeriveBytes.Pbkdf2(inputPassword, salt, Iterations, _hashAlgoirthmName, KeySize);
            return CryptographicOperations.FixedTimeEquals(hash, hashInput);
        }
    }
}
