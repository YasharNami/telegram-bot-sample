using Telegram.Bot.Types.ReplyMarkups;

namespace TelegramSampleBot.Keyboards;

public static class ReplyMarkupKeyboards
{
    public static ReplyKeyboardMarkup Panel()
    {

        return new ReplyKeyboardMarkup(new List<List<KeyboardButton>>()
        {
            new() { "حساب کاربری 👤", "کیف پول من 👝" },
            new() { "پشتیبانی 📞", "آموزش 📒" },
        })
        {
            ResizeKeyboard = true
        };
    }

}