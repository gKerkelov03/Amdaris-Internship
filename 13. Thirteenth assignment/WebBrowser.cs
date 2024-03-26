namespace BusinessLayer;

public class WebBrowser
{
    public BrowserName Name { get; set; }
    public int MajorVersion { get; set; }

    public WebBrowser(BrowserName name, int majorVersion)
    {
        Name = name;
        MajorVersion = majorVersion;
    }
}