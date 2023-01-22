using System.Text.RegularExpressions;
using yt_benchmark.interfaces;

namespace yt_benchmark.Validators;

public class EmailValidatorRegexCompiled : IEmailValidator
{
    static Regex Regex = new Regex(
        @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", 
        RegexOptions.Compiled);

    public bool IsValid(string email) => Regex.Match(email).Success;
}
