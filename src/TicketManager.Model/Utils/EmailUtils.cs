using System.Net.Mail;
using System.Text.RegularExpressions;

namespace TicketManager.Model.Utils;

public class EmailUtils
{
    private static readonly Regex EmailRegex = new(
        @"^[^@\s]+@[^@\s]+\.[^@\s]+$",
        RegexOptions.Compiled | RegexOptions.IgnoreCase
    );

    public static bool IsValidEmail(string email)
    {
        if (string.IsNullOrWhiteSpace(email)) return false;

        string emailTrimmed = email.Trim();

        if (!EmailRegex.IsMatch(emailTrimmed))
            return false;

        try
        {
            MailAddress addr = new(emailTrimmed);
            return addr.Address.Equals(emailTrimmed);
        }
        catch
        {
            return false;
        }
    }
}