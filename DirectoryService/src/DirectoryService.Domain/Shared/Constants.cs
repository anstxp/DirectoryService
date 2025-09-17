using System.Text.RegularExpressions;

namespace DirectoryService.Domain.Shared;

public class Constants
{
    public const int MIN_NAME_LENGTH = 3;
    public const int MAX_DEP_NAME_LENGTH = 150;
    public const int MAX_POSITION_NAME_LENGTH = 100;
    public const int MAX_LOCATION_NAME_LENGTH = 120;

    public const int MIN_ID_LENGTH = 3;
    public const int MAX_ID_LENGTH = 150;

    public const int MAX_TEXT_LENGTH = 1000;

    public static bool IsValidPath(string s) =>
        Regex.IsMatch(s, @"^[a-z0-9]+(?:[.-][a-z0-9]+)*(?:\\.[a-z0-9]+(?:[.-][a-z0-9]+)*)*$");

    public static bool IsValidIdentifier(string s) =>
        Regex.IsMatch(s, @"^[a-z]+$");

    public static bool IsIanaTz(string s) =>
        Regex.IsMatch(s, @"^[A-Za-z_]+\/[A-Za-z_\-]+$");
}