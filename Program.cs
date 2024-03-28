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
    Console.WriteLine("3) Find Movie");
    Console.WriteLine("Press enter to quit");
    Console.Write("> ");
    option = Console.ReadLine();
    switch(option) {

    // Menu to add movies
        case "1":
        logger.Info("User choice: \"1\"");
        if (File.Exists(scrubbedFile)) {
            Movie newMovie = new Movie();

            Console.WriteLine("Enter movie title");
            newMovie.title = Console.ReadLine();

            Console.WriteLine("Enter genres of the movie (type 'done' to finish):");
            newMovie.genres = new List<string>();
            string genreInput;
            do {
                genreInput = Console.ReadLine();
                if (genreInput.ToLower() != "done")
                    newMovie.genres.Add(genreInput);
            } while (genreInput.ToLower() != "done");

        Console.WriteLine("Enter movie director");
        newMovie.director = Console.ReadLine();

        bool fail = true;
        while (fail) {
            Console.WriteLine("Enter running time(h:m:s)");
            string runningTimeInput = Console.ReadLine();
            TimeSpan runningTime;
            if (TimeSpan.TryParse(runningTimeInput, out runningTime)) {
                newMovie.runningTime = runningTime;
                fail = false;
            } else {
                Console.WriteLine("Invalid input for running time.");
            }
            
        movieFile.AddMovie(newMovie);

        }

        } else {
            logger.Warn("movies.scrubbed.csv is missing.");
        }
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



    // Menu to allow the user to search for movies
        case "3":
        Console.Clear();
        string query = Inputs.GetString("Search for movie by title > ");
        var queryMovies = movieFile.Movies.Where(m => m.title.Contains(query)).Select(m => m.title);

        Console.WriteLine($"There are {queryMovies.Count()} movies with {query} in the title:");
        foreach (string m in queryMovies) {
            Console.WriteLine($" {m}");
        }
        break;
    }

} while (option == "1" || option == "2" || option == "3");

logger.Info("Program ended");
