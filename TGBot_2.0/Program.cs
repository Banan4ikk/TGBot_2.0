using System;
using System.Collections.Generic;
using System.Text;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Types.ReplyMarkups;
using Telegram.Bot.Types.Enums;

namespace TGBot_2._0
{
    class Program
    {
        static string TG_TOKEN = "1536000259:AAHZE1h3SgYrd6W1TSkMnGzsHkZ35onuEhw";
        static TelegramBotClient Bot = new TelegramBotClient(TG_TOKEN);


        static ReplyKeyboardMarkup mainKB = new ReplyKeyboardMarkup
        {
            Keyboard = new[]
            {      
                   new[]
                   {
                       new KeyboardButton("Спорт"),
                       new KeyboardButton("Политика"),
                       new KeyboardButton("Экономика")
                   },
                   new[]
                   {
                       new KeyboardButton("Местные новости"),
                       new KeyboardButton("Автомобили"),
                       new KeyboardButton("Игры")
                   }
            },
            ResizeKeyboard = true
        };

        static ReplyKeyboardMarkup SportKB = new ReplyKeyboardMarkup
        {
            Keyboard = new[]
            {
                new[]
                {
                    new KeyboardButton("Футбол"),
                    new KeyboardButton("Хоккей"),
                    new KeyboardButton("Биатлон"),
                    new KeyboardButton("Баскетбол"),
                },
                new[]
                {
                    new KeyboardButton("Бокс"),
                    new KeyboardButton("Автоспорт"),
                    new KeyboardButton("ММА"),
                    new KeyboardButton("Киберспорт"),
                },
                new[]
                {
                    new KeyboardButton("Назад")
                }
            },
            ResizeKeyboard = true
        };
        static void Main(string[] args)
        {
            
            var bot_check = Bot.GetMeAsync().Result;
            Console.WriteLine($"Bot name: {bot_check.FirstName}\r\nBot's ID: {bot_check.Id}\r\nBot's username: {bot_check.Username}");

            Bot.OnMessage += Bot_OnMessage;
            Bot.StartReceiving();

            Console.ReadLine();
            Bot.StopReceiving();
        }

       

        private static async void Bot_OnMessage(object sender, MessageEventArgs e)
        {
            if (e.Message.Type != MessageType.Text)
            {
                await Bot.SendTextMessageAsync(
                    chatId: e.Message.Chat,
                    text: "I can handle only text messages.");
                return;
            }
            if(e.Message.Text == "/start")
                await Bot.SendTextMessageAsync(chatId: e.Message.Chat,text: "Новости для вас",replyMarkup: mainKB);

          
            switch (e.Message.Text)
            {
                case "Спорт": 
                    {
                        await Bot.SendTextMessageAsync(chatId: e.Message.Chat, text: "Доступные виды спорта ↓ ", replyMarkup: SportKB);
                        switch (e.Message.Text)
                        {
                            case "Футбол": await Bot.SendTextMessageAsync(chatId: e.Message.Chat, text: "Новости про Футбол", replyMarkup: SportKB); break;
                            case "Хоккей": await Bot.SendTextMessageAsync(chatId: e.Message.Chat, text: "Новости про Хоккей", replyMarkup: SportKB); break;
                            case "Биатлон": await Bot.SendTextMessageAsync(chatId: e.Message.Chat, text: "Новости про Биатлон", replyMarkup: SportKB); break;
                            case "Баскетбол": await Bot.SendTextMessageAsync(chatId: e.Message.Chat, text: "Новости про Баскетбол", replyMarkup: SportKB); break;
                            case "Бокс": await Bot.SendTextMessageAsync(chatId: e.Message.Chat, text: "Новости про Бокс", replyMarkup: SportKB); break;
                            case "Автоспорт": await Bot.SendTextMessageAsync(chatId: e.Message.Chat, text: "Новости про Автоспорт", replyMarkup: SportKB); break;
                            case "ММА": await Bot.SendTextMessageAsync(chatId: e.Message.Chat, text: "Новости про ММА", replyMarkup: SportKB); break;
                            case "Киберспорт": await Bot.SendTextMessageAsync(chatId: e.Message.Chat, text: "Новости про Киберспорт", replyMarkup: SportKB); break;
                            case "Назад": await Bot.SendTextMessageAsync(chatId: e.Message.Chat, text: "", replyMarkup: mainKB); break;
                        }
                    }
                    break;
                case "Политика": await Bot.SendTextMessageAsync(chatId: e.Message.Chat, text: "Новости про политику", replyMarkup: mainKB); break;
                case "Экономика": await Bot.SendTextMessageAsync(chatId: e.Message.Chat, text: "Новости про экономику", replyMarkup: mainKB); break;
                case "Местные новости": await Bot.SendTextMessageAsync(chatId: e.Message.Chat, text: "Новости про местные события", replyMarkup: mainKB); break;
                case "Автомобили": await Bot.SendTextMessageAsync(chatId: e.Message.Chat, text: "Новости про авто", replyMarkup: mainKB); break;
                case "Игры" +
                "": await Bot.SendTextMessageAsync(chatId: e.Message.Chat, text: "Новости про игры", replyMarkup: mainKB); break;

            }
        }
        
    }
}
