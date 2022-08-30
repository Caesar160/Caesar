namespace Caesar.Common.Helpers;

public static class PasswordsHelper
{
    public static bool IsPasswordMeetRequirements(string password)
    {
        if (password.Length < 8)
        {
            return false;
        }

        bool isUpper, isLower, isDigit = isLower = isUpper = false;

        foreach (var ch in password)
        {
            if (char.IsUpper(ch))
            {
                isUpper = true;
            }
            if (char.IsLower(ch))
            {
                isLower = true;
            }
            if (char.IsDigit(ch))
            {
                isDigit = true;
            }
        }

        return isDigit && isUpper && isLower;
    }
}
