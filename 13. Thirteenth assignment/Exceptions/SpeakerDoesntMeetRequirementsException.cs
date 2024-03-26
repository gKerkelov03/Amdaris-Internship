namespace BusinessLayer.Exceptions;

public class SpeakerDoesntMeetRequirementsException : Exception
{
    public SpeakerDoesntMeetRequirementsException(string message) : base(message) { }
}