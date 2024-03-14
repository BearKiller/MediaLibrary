using NLog;

namespace MediaLibrary;
class Program
{
    public abstract class Media {

            //public virtual string Display() {

            //}

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
