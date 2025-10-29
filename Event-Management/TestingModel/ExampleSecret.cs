namespace Event_Management.TestingModel
{
    internal class ExampleSecret
    {
        private static readonly Lazy<ExampleSecret> instance = new Lazy<ExampleSecret>(() => new ExampleSecret());
        private string URL = "Server=MSI\\SQLEXPRESS;Database=Event-Management;Integrated Security=SSPI;TrustServerCertificate=True;";
        private ExampleSecret()
        {

        }

        public static ExampleSecret Instance => instance.Value;

        public string GetURL() { return URL; }
    }
}
