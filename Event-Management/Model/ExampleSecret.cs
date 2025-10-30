namespace Event_Management.Model
{
    internal class ExampleSecret //Rename this class name to Secret and replace URL
    {
        private static readonly Lazy<ExampleSecret> instance = new Lazy<ExampleSecret>(() => new ExampleSecret());
        private string URL = "Server=LAPTOP-HTBNMGAH\\SQLEXPRESS;Database=Event-Management;Integrated Security=SSPI;TrustServerCertificate=True;";
        private ExampleSecret()
        {

        }

        public static ExampleSecret Instance => instance.Value;

        public string GetURL() { return URL; }
    }
}
