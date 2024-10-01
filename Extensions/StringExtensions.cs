namespace apiservicosadm.tests.Extensions;

public static class StringExtensions
{
    public static string NormalizarString(this string input)
        => string.Concat(input.Where(c => !char.IsWhiteSpace(c))).ToLowerInvariant();
}
