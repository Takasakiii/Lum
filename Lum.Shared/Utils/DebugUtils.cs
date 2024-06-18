using System.Text.Json;

namespace Lum.Shared.Utils;

public static class DebugUtils
{
    public static void PrintLn(params object[] elements)
    {
        Console.WriteLine(string.Join(" ", elements.Select(x => JsonSerializer.Serialize(x,
            options: new JsonSerializerOptions
            {
                WriteIndented = true
            }))));
    }
}