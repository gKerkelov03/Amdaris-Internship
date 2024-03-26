namespace BusinessLayer;

using BusinessLayer.Exceptions;

public partial class Speaker
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public required int YearsOfExperience { get; set; }
    public required bool HasBlog { get; set; }
    public required string BlogURL { get; set; }
    public required WebBrowser Browser { get; set; }
    public required IEnumerable<string> Certifications { get; set; }
    public required string Employer { get; set; }
    public int RegistrationFee { get; set; }
    public IEnumerable<Session> Sessions { get; set; }

    public Speaker(string firstName, string lastName, string email, IEnumerable<Session> sessions)
    {
        ArgumentException.ThrowIfNullOrEmpty(firstName);
        ArgumentException.ThrowIfNullOrEmpty(lastName);
        ArgumentException.ThrowIfNullOrEmpty(email);

        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Sessions = sessions;

        RegistrationFee = CalculateRegistrationFee(YearsOfExperience);
        ApproveOrDissaproveTheSessions();
    }

    public int? Register(IRepository repository)
    {
        var thereIsApprovedSession = Sessions.Any(session => session.Approved);
        var isProfessional = CheckIsProfessional();

        if (!isProfessional)
        {
            throw new SpeakerDoesntMeetRequirementsException("Speaker doesn't meet our abitrary and capricious standards.");
        }

        if (!thereIsApprovedSession)
        {
            throw new NoSessionsApprovedException("No sessions approved.");
        }

        return SaveToDatabase(repository);
    }

    private bool CheckIsProfessional()
    {
        var badEmailDomains = new[] { "aol.com", "hotmail.com", "prodigy.com", "CompuServe.com" };
        var prestigiousEmployers = new[] { "Microsoft", "Google", "Fog Creek Software", "37Signals" };
        var emailDomain = Email.Split('@').Last();

        var isProfessional = YearsOfExperience > 10 ||
            HasBlog ||
            Certifications.Count() > 3 ||
            prestigiousEmployers.Contains(Employer) ||
            (
                !badEmailDomains.Contains(emailDomain) &&
                Browser.Name != BrowserName.InternetExplorer &&
                Browser.MajorVersion > 9
            );

        return isProfessional;
    }

    private void ApproveOrDissaproveTheSessions()
    {
        var outdatedTechnologies = new[] { "Cobol", "Punch Cards", "Commodore", "VBScript" };

        foreach (var session in Sessions)
        {
            var isSessionOutdated =
                outdatedTechnologies.Any(session.Title.Contains) ||
                outdatedTechnologies.Any(session.Description.Contains);

            if (isSessionOutdated)
            {
                session.Approved = false;
            }
            else
            {
                session.Approved = true;
            }
        }
    }

    private int? SaveToDatabase(IRepository repository)
    {
        try
        {
            var speakerId = repository.SaveSpeaker(this);
            return speakerId;
        }
        catch (Exception e)
        {
            Console.WriteLine($"Speaker not saved to the database. Error message: {e.Message}");
            return null;
        }
    }

    private static int CalculateRegistrationFee(int yearsOfExperience)
    {
        var registrationFee = 0;

        if (yearsOfExperience <= 1)
        {
            registrationFee = 500;
        }
        else if (yearsOfExperience <= 3)
        {
            registrationFee = 250;
        }
        else if (yearsOfExperience <= 5)
        {
            registrationFee = 100;
        }
        else if (yearsOfExperience <= 9)
        {
            registrationFee = 50;
        }

        return registrationFee;
    }
}