namespace WebApplication1
{
    public class Singleton
    {
     
        private static Singleton _instance;

        private Singleton() {}
        public static Singleton GetSingletonInstance()
        {
            if (_instance == null)
            {
                _instance = new();
            }
            return _instance;
        }

    }
}
