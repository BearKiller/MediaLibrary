using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using NLog;

// See https://aka.ms/new-console-template for more information
string path = Directory.GetCurrentDirectory() + $"{Path.DirectorySeparatorChar}nlog.config";
// create instance of Logger
var logger = LogManager.LoadConfiguration(path).GetCurrentClassLogger();
logger.Info("Program started");


string scrubbedFile = FileScrubber.ScrubMovies("movies.csv");
logger.Info(scrubbedFile);
MovieFile movieFile = new MovieFile(scrubbedFile);

string option;
do {
    Console.Clear();
    Console.WriteLine("1) Add a Movie");
    Console.WriteLine("2) Display All Movies");
    Console.WriteLine("Press enter to quit");
    Console.Write("> ");
    option = Console.ReadLine();
    switch(option) {
    // Menu to add movies
        case "1":
        break;

    // Menu to display all movies
        case "2":
        break;
    }
} while (option == "1" || option == "2");

logger.Info("Program ended");
