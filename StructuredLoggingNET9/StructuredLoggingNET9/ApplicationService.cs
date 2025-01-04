using Serilog;
using Serilog.Formatting.Json;

namespace StructuredLoggingNET9
{
    public static class ApplicationService
    {
        public static void ConfigureLogging(this IHostBuilder host)
        {
            host.UseSerilog((ctx, lc) =>
            {
                lc.WriteTo.Console();
                lc.WriteTo.Seq("http://localhost:5341");
                lc.WriteTo.File(new JsonFormatter(), "log.txt");

            });
        }
    }
}
