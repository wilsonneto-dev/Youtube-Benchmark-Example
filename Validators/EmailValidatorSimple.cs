using yt_benchmark.interfaces;

namespace yt_benchmark.Validators;

public class EmailValidatorSimple : IEmailValidator
{
    public bool IsValid(string email)
    {
        int userNameLength = 0;
        bool foundAtSign = false;
        int domainLength = 0;
        int domainDotCount = 0;

        foreach (var ch in email.ToCharArray())
        {
            if (ch == '@')
            {
                if (foundAtSign || userNameLength == 0)
                    return false;
                foundAtSign = true;
                continue;
            }

            if (!foundAtSign)
                userNameLength++;
            else if (ch == '.')
            {
                if (domainLength == 0)
                    return false;
                domainLength = 0;
                domainDotCount++;
            }
            else domainLength++;
        }

        if (userNameLength == 0 || domainDotCount < 1 || domainDotCount > 2 || domainLength == 0)
            return false;

        return true;
    }
}