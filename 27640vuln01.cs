using Microsoft.Extensions.Logging;
using System;
using System.IO;
using System.Web;
public class LogForgingHandler : IHttpHandler
{
    private ILogger logger;

    public void ProcessRequest(HttpContext ctx)
    {
       //String username = ctx.Request.QueryString["username"];
       String endDate = ctx.Request.QueryString["endDate"];
       // BAD: User input logged as-is
           // logger.Warn(username + " log in requested.");
logger.LogInformation("Starting myMethod for date: {0}", endDate.ToString().SanitizeLogData());
       // GOOD: User input logged with new-lines removed
string endDateLog = Regex.Replace(endDate.ToString(), @"\s+", " ");
logger.LogInformation("Starting myMethod for date: {0}", endDateLog);
           // logger.Warn(username.Replace(Environment.NewLine, "") + " log in requested");
    }
}
public static class StringExtensions
{
public static string SanitizeLogData(this string logData)
{
return Regex.Replace(logData, @"\s+", " ");
}
}
