using FileAccess = System.IO.FileAccess;
using FileShare = System.IO.FileShare;

namespace AsiDotNet;

internal class Logger
{
    private static readonly StreamWriter _logWriter =
        new(File.Open("AsiDotNet.log", FileMode.Create, FileAccess.ReadWrite, FileShare.Read));

    public static void Info(string msg)
    {
        try
        {
            _logWriter.WriteLine(msg);
            _logWriter.FlushAsync();
        }
        catch
        {
        }
    }
}