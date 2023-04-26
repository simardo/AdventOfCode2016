using Libs;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

Console.WriteLine("Day 00");

int year = Int32.Parse(args[0]);
int day = Int32.Parse(args[1]);

using IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services => {
        services.AddHttpClient("", c => {
            c.BaseAddress = new Uri("https://adventofcode.com/");
            c.DefaultRequestHeaders.Add("Cookie", "session=53616c7465645f5fefebf56c3845b429e56123301cf66c2f72ff9037d7acec1109d2256cf66568162292a70856286835b0ec9c9fcc50e9964b50be3cb258f975");
        });
        services.AddTransient<InputLoaderService>();
    })
    .Build();

using IServiceScope scope = host.Services.CreateScope();
IServiceProvider serviceProvider = scope.ServiceProvider;

InputLoaderService svc = serviceProvider.GetRequiredService<InputLoaderService>();
string s = await svc.GetInputAsync(year, day);

using StreamWriter sw = new StreamWriter($"{Environment.CurrentDirectory}\\input.txt");
sw.Write(s);

await host.RunAsync();

Console.WriteLine("Done");