
using System.Text.Json;
using Serilog;

public class MovieStarsService()
{

    public IEnumerable<MovieStar>? GetMovieStarsList(string inputFilePath)
    {
        string? json = null;

        try
        {
            json = File.ReadAllText(inputFilePath);
        }
        catch (FileNotFoundException e)
        {
            Log.Error("The input file for the show movie stars feature was not found. {ErrorMessage}", e.Message);
        }
        catch (IOException e)
        {
            Log.Error("Cannot read the input file for the show movie stars feature. {ErrorMessage}", e.Message);
        }

        IEnumerable<MovieStar> movieStars = null;
        try
        {
            movieStars = JsonSerializer.Deserialize<IEnumerable<MovieStar>>(json);
        }
        catch (ArgumentException)
        {
            Log.Error("Your json is null");
        }
        catch (JsonException)
        {
            Log.Error("Json serialization exception, cannot deserialize this data into this object");
        }

        return movieStars;
    }
}
