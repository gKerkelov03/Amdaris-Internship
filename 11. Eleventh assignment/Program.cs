using Serilog;
var partToRemove = Path.Combine(
    Path.DirectorySeparatorChar + "bin",
    "Debug",
    "net8.0"
);
var appDirectory = Environment.CurrentDirectory.Replace(partToRemove, string.Empty);
var logFilesPath = Path.Combine(appDirectory, "Logs", "log-.txt");
var inputFilePath = Path.Combine(appDirectory, "input.txt");

Log.Logger = new LoggerConfiguration()
    .WriteTo
    .File(logFilesPath, rollingInterval: RollingInterval.Day)
    .CreateLogger();

//the easiest way to force some error is to rename, delete or move the input.txt file
var movieStarsService = new MovieStarsService();
var movieStars = movieStarsService.GetMovieStarsList(inputFilePath);

if (movieStars is not null)
{
    foreach (var movieStar in movieStars)
    {
        Console.WriteLine($"{movieStar.Name} {movieStar.Surname}");
        Console.WriteLine(movieStar.Sex);
        Console.WriteLine(movieStar.Nationality);
        Console.WriteLine($"Date of birth: {movieStar.DateOfBirth.Date:dd.MM.yyyy}");
        Console.WriteLine();
    }
}