using NLog;

namespace MediaLibrary;
class Program
{

    public class Media
    {
        // public properties
        public UInt64 mediaId { get; set; }
        public string title { get; set; }
        public List<string> genres { get; set; }

        // constructor
        public Media()
        {
            genres = new List<string>();
        }

        // public method
        public string Display()
        {
            return $"Id: {mediaId}\nTitle: {title}\nGenres: {string.Join(", ", genres)}\n";
        }
    }

    static void Main(string[] args) {

    string path = Directory.GetCurrentDirectory() + "\\nlog.config";

    // create instance of Logger
    var logger = LogManager.LoadConfiguration(path).GetCurrentClassLogger();
    logger.Info("Program started");

    Console.WriteLine("Hello World!");

    logger.Info("Program ended");

    }

}
