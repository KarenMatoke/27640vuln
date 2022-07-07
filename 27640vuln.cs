logger.LogInformation("Starting myMethod for date: {0}", endDate.ToString().SanitizeLogData());

public static class StringExtensions
{
public static string SanitizeLogData(this string logData)
{
return Regex.Replace(logData, @"\s+", " ");
}
}
