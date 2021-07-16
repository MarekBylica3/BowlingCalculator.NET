namespace BowlingApp.Src
{
    public interface ITextFileLoader
    {
        string LoadFile(string path, bool defaultFileIfNotFound = false);
    }
}
