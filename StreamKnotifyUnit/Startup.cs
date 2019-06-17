using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Builder;
using Microsoft.Extensions.DependencyInjection;
using StreamKnotifyUnit.Providers;
using StreamKnotifyUnit.Services;

namespace StreamKnotifyUnit
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<ToastService>();
            services.AddScoped<TwitchService>();
            services.AddScoped<WeatherForecastService>();
            services.AddAuthorizationCore();
            services.AddScoped<AuthenticationStateProvider, KnotifyAuthenticationProvider>();
        }

        public void Configure(IComponentsApplicationBuilder app)
        {
            app.AddComponent<App>("app");
        }
    }
}
