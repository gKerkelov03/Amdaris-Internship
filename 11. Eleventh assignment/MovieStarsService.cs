
using System.Text.Json;
using Serilog;

public class MovieStarsService()
{
    public IEnumerable<MovieStar>? GetMovieStarsList(string inputFilePath)
    {
        string? json = null;
        var successfullyReadTheJson = false;
        var successfullyDeserializeTheJson = false;

        try
        {
            json = File.ReadAllText(inputFilePath);
            successfullyReadTheJson = true;
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
            successfullyDeserializeTheJson = true;
        }
        catch (ArgumentException)
        {
            Log.Error("Your json is null");
        }
        catch (JsonException)
        {
            Log.Error("Json serialization exception, cannot deserialize this data into this object");
        }

        var finishedWithoutErrors = successfullyReadTheJson && successfullyDeserializeTheJson;
        Log.Information(
            "Method {MethodName} finished {MethodOutcome}",
            nameof(GetMovieStarsList),
            finishedWithoutErrors ? "Successfully" : "with errors that were logged"
        );

        return movieStars;
    }
}
