using Microsoft.AspNetCore.Mvc.ApplicationParts;
using System.Reflection;

namespace APIHost.Helpers
{
    public static class ApiAssemblyLoader
    {
        public static void AddControllersFromBoundedContexts(this IServiceCollection services, WebApplicationBuilder builder)
        {
            var mvcBuilder = services.AddControllers();

            string? basePath = AppContext.BaseDirectory;
            var apiDlls = Directory.GetFiles(basePath, "*.API.dll", SearchOption.TopDirectoryOnly);

            foreach (var dll in apiDlls)
            {
                try
                {
                    var assembly = Assembly.LoadFrom(dll);
                    mvcBuilder.PartManager.ApplicationParts.Add(new AssemblyPart(assembly));
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"[WARN] Failed to load {dll}: {ex.Message}");
                }
            }
        }
    }
}
