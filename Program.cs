using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using NLog;
using Helper;

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
    //Console.Clear();
    Console.WriteLine("1) Add a Movie");
    Console.WriteLine("2) Display All Movies");
    Console.WriteLine("Press enter to quit");
    Console.Write("> ");
    option = Console.ReadLine();
    switch(option) {
    // Menu to add movies
        case "1":
        logger.Info("User choice: \"1\"");
        break;

    // Menu to display all movies
        case "2":
        logger.Info("User choice: \"2\"");
        if (File.Exists(scrubbedFile)) {
            logger.Info("movies.scrubbed.csv located.");
            Console.WriteLine(movieFile.Movies.Count);
            foreach (Movie movie in movieFile.Movies) {
                // Output movie details
                Console.WriteLine($"Title: {movie.title}");
                Console.WriteLine($"Genres: {string.Join(", ", movie.genres)}");
                Console.WriteLine($"Director: {movie.director}");
                Console.WriteLine($"Running Time: {movie.runningTime}");
                Console.WriteLine();
            }
            
        } else {
            logger.Warn("movies.scrubbed.csv is missing.");
        }
        break;
    }
} while (option == "1" || option == "2");

logger.Info("Program ended");
