using System.Text.RegularExpressions;
using yt_benchmark.interfaces;

namespace yt_benchmark.Validators;

public class EmailValidatorRegex : IEmailValidator
{
    public bool IsValid(string email)
    {
        var regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
        return regex.Match(email).Success;
    }
}
