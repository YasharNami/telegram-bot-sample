using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types.Enums;
using TelegramSampleBot.Handlers;

var bot = new TelegramBotClient("Insert Your Telegram Bot Token Here");
var receiverOptions = new ReceiverOptions
{
    AllowedUpdates = Array.Empty<UpdateType>() // receive all update types
};

bot.StartReceiving(MainHandler.Run, MainHandler.HandlePollingErrorAsync, receiverOptions);
var me = bot.GetMe().GetAwaiter().GetResult();

Console.WriteLine($"Start listening for @{me.Username}");
