using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

namespace GameLibrary.Frontend
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            builder.RootComponents.Add<HeadOutlet>("head::after");
            var url = "https://localhost:7019";
            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(url) });

            builder.Services.AddScoped<Services.IGameService, Services.GameService>();

            await builder.Build().RunAsync();
        }
    }
}
