using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types.Enums;
using TelegramSampleBot.Handlers;

using var host = CreateHostBuilder(args).Build();
using var scope = host.Services.CreateScope();

var bot = new TelegramBotClient("7787627745:AAEbG3h_8CWThohTodgp9QffjCkFBY9i7VA");
var receiverOptions = new ReceiverOptions
{
    AllowedUpdates = Array.Empty<UpdateType>() // receive all update types
};

bot.StartReceiving(MainHandler.Run, MainHandler.HandlePollingErrorAsync, receiverOptions);
var me = bot.GetMe().GetAwaiter().GetResult();

Console.WriteLine($"Start listening for @{me.Username}");
await host.RunAsync();


static IHostBuilder CreateHostBuilder(string[] args)
{
    return Host.CreateDefaultBuilder(args)
        .ConfigureAppConfiguration((context, builder) => { builder.AddEnvironmentVariables(); });
}


