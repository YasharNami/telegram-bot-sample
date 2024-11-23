using Telegram.Bot;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using TelegramSampleBot.Keyboards;

namespace TelegramSampleBot.Handlers;

public static class MainHandler
{
    [Obsolete("Obsolete")]
    public static Task Run(ITelegramBotClient bot, Update update, CancellationToken cancellationToken)
    {
        Task.Run(async () =>
        {
            try
            {
                switch (update.Type)
                {
                    case UpdateType.Message:
                        switch (update.Message!.Chat.Type)
                        {
                            case ChatType.Private:
                                switch (update.Message.Type)
                                {
                                    case MessageType.Text:
                                        var message = update.Message.Text;
                                        var userId = update.Message.From!.Id;
                                        if (message == "/start")
                                        {
                                            await bot.SendTextMessageAsync(userId, $"سلام به ربات خوش آمدبد!",
                                                parseMode:ParseMode.Html,
                                                replyParameters: new ReplyParameters()
                                                {
                                                    MessageId = update.Message.MessageId,
                                                },
                                                replyMarkup:ReplyMarkupKeyboards.Panel(),
                                                cancellationToken: cancellationToken);
                                        }
                                        break;
                                    case MessageType.Photo:
                                        break;
                                    case MessageType.Video:
                                        break;
                                    default:
                                        break;
                                }
                                break;
                            case ChatType.Group or ChatType.Supergroup:
                                break;
                        }
                        break;
                    case UpdateType.CallbackQuery:
                        break;
                    default:
                        return;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }, cancellationToken);
        return Task.CompletedTask;
    }

 
    public static Task HandlePollingErrorAsync(ITelegramBotClient bot, Exception exception,
        CancellationToken cancellationToken)
    {
        var errorMessage = exception switch
        {
            ApiRequestException apiRequestException
                => $"Telegram API Error:\n[{apiRequestException.ErrorCode}]\n{apiRequestException.Message}",
            _ => exception.ToString()
        };
        Console.WriteLine(errorMessage);

        return Task.CompletedTask;
    }
}