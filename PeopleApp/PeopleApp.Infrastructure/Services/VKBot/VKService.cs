using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace PeopleApp.Infrastructure.Services.VKBot
{
    public class VKService : IVKService
    {
        private readonly IUnitOfWork _uow;

        public VKService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public string GetHandledMessage(string message)
        {
            if (HelpHandling(ref message)) return message;
            if (GreetingHandling(ref message)) return message;
            if (ChatHandling(ref message)) return message;
            if (InterestFactsHandling(ref message)) return message;
            if (WhyItNeedsHandling(ref message)) return message;
            if (The2020YearHandling(ref message)) return message;
            if (StatInfoHandling(ref message)) return message;

            return "К сожалению, я еще прототип. Для получения списка всех моих возможностей пришлите '?'";
        }

        private bool HelpHandling(ref string message)
        {
            var messageText = message;

            if (messageText.Contains("кто ты") || messageText.Contains("ты кто"))
            {
                message = "Привет, я Скворец! :-) Я призван рассеять все сомнения по поводу бесполезности переписи населения!\n Для получения списка всех моих возможностей пришлите '?'";
                return true;
            }

            var helpMessages = new[]
            {
                "как это работает", "что тут делать", "справка", "help",
                "помоги", "помощь", "что ты умеешь"
            };

            if (helpMessages.Any(m => messageText.Contains(m)) || messageText.Equals("?"))
            {
                message =
                    "Узнать какой-нибудь интересный факт, связанный с переписью - команда 'Расскажи что-нибудь'!\n" +
                    "Узнать численность населения какой-либо области - 'Сколько людей живет в Курской области'\n" +
                    "Узнать рождаемость/смертность какой-либо области за опеределенный год - 'Рождаемость/Смертность в Курской области в 2010 году.'\n" +
                    "Лучше понять, зачем проводится перепись населения, и какую пользу она несет - 'Зачем нужна перепись населения?'\n" +
                    "Информация о переписи населения 2020 года - '2020'";

                return true;
            }

            return false;
        }

        private bool GreetingHandling(ref string message)
        {
            var messageText = message;
            var greetingMessages = new[]
            {
                "привет", "hello", "здравствуй", "здравствуйте", "хай",
                "добрый день", "добрый вечер", "доброе утро", "прив"
            };

            if (greetingMessages.Any(m => messageText.Contains(m)))
            {
                message = greetingMessages[new Random().Next(0, greetingMessages.Length)] + "! :-)";
                message = FirstUpper(message);
                return true;
            }

            return false;
        }

        private bool ChatHandling(ref string message)
        {
            if (message.Contains("как дела"))
            {
                message = "Всегда отлично! А у тебя?";
                return true;
            }

            if (message.Contains("ок") || message.Contains("тож") || message.Contains("и у меня"))
            {
                message = "Супер! :-)";
                return true;
            }

            if (message.Contains("что делаешь") || message.Contains("маешься"))
            {
                message = "Готовлюсь к переписи населения 2020. Если интересно, напиши 'Зачем нужна перепись населения?' :-)";
                return true;
            }

            return false;
        }

        private bool InterestFactsHandling(ref string message)
        {
            if (message.Contains("расскажи") || message.Contains("удиви"))
            {
                string result = "Я могу быть очень полезен и поделиться с тобой интересными статистическими данными. Например, ";
                switch (new Random().Next(3))
                {
                    case 0:
                        result += " первая Всероссийская перепись была проведена в 2002 году. Она прошла под девизом <Впиши себя в историю России>";
                        break;
                    case 1:
                        result += " перепись на Руси провели еще татаро-монголы в 1245 году. Правда, учет не был общим: учитывались только дома для обложения данью.";
                        break;
                    case 2:
                        result += " во 2 веке до н.э. скифский царь Скилур решил провести подсчет подданных довольно необычным образом. Правитель велел каждому мужчине принести к его резиденции по одному наконечнику стрелы. Многие, так и не поняв замысла своего повелителя, в знак уважения принесли сразу несколько наконечников. Таким образом, переписи так и не суждено было осуществиться. Известно, что по замыслу выдающегося полководца хана Тамерлана воины вместо наконечников стрел должны были бросать камни.";
                        break;
                }

                message = result;
                return true;
            }

            return false;
        }

        private bool WhyItNeedsHandling(ref string message)
        {
            var messageText = message;
            var whyMessages = new[]
            {
                "для чего", "зачем", "какая польза", "что дает"
            };

            if (whyMessages.Any(m => messageText.Contains(m)))
            {
                message = "Перепись населения\n" + 
                          "- Улучшает жизнь благодаря решениям власти\n" + 
                          "- Помогает обратить внимание на проблемы в различных сферах\n" + 
                          "- Позволяет принять решение при выборе места для проживания\n\n"+ "" +
                          "Точная информация о населении страны демографического и социально-экономического характера"+
                          " нужна для самых разных целей. На её основе планируют бюджеты регионов и населённых пунктов,"+
                          " выстраивают стратегии развития экономики. Данные переписи служат для разработки госпрограмм"+
                          " поддержки тех или иных слоёв населения (молодёжи, семей с детьми и т.д.).";
                return true;
            }

            return false;
        }

        private bool The2020YearHandling(ref string message)
        {
            if (message.Contains("2020"))
            {
                message = "Выборы 2020 года\n" +
                          "- будут проводиться с 1 по 31 октября 2020 года" +
                          "- появится возможность заполнить переписной лист самостоятельно (на сайте https://www.gosuslugi.ru/)" +
                          "- в крупных городах страны переписчиков оснастят электронными планшетами (бумага в прошлом)";
                return true;
            }
            return false;
        }

        private bool StatInfoHandling(ref string message)
        {
            var messageText = message;

            if (message.Contains("сколько людей живет")
                || message.Contains("сколько человек живет")
                || message.Contains("населений"))
            {
                var maxRegion = GetMismatchRegion(messageText);
                message = $"{maxRegion?.Name}: население - {maxRegion?.Population} чел.";
                return true;
            }

            if (message.Contains("рождаемость") || message.Contains("родил") || message.Contains("появилось"))
            {
                var maxRegion = GetMismatchRegion(messageText, true);
                var year = int.Parse(Regex.Match(messageText, @"\d{4}").Value);
                message = maxRegion.BirthRates.FirstOrDefault(b => b.Year == year)?.Value.ToString();
                if (message == null) message = "К сожалению, эта информация отсутствует";
                else message = $"В {year} году в данной области родилось: {message} чел.";
                return true;
            }

            if (message.Contains("смертность") || message.Contains("погиб") || message.Contains("умер"))
            {
                var maxRegion = GetMismatchRegion(messageText, true);
                var year = int.Parse(Regex.Match(messageText, @"\d{4}").Value);
                message = maxRegion.DeathRates.FirstOrDefault(b => b.Year == year)?.Value.ToString();
                if (message == null) message = "К сожалению, эта информация отсутствует";
                else message = $"В {year} году в данной области погибло: {message} чел.";
                return true;
            }
            return false;
        }

        private Core.Entity.Region GetMismatchRegion(string messageText, bool eagerMode = false)
        {
            messageText = GetShortMessageText(messageText);
            var regions = _uow.Regions.GetAll(eagerMode).ToList();
            var max = regions.Max(r => LongestCommonSubstring(messageText, r.Name.ToLower()));
            var maxRegion = regions.First(r => LongestCommonSubstring(messageText, r.Name.ToLower()) == max);
            return maxRegion;
        }

        private static string GetShortMessageText(string messageText)
        {
            messageText = messageText
                .Replace("сколько людей живет", "")
                .Replace("сколько человек живет", "")
                .Replace("населений", "")
                .Replace("област", "")
                .Replace("автономн", "")
                .Replace("рождаемость", "")
                .Replace("сколько", "")
                .Replace("человек", "")
                .Replace("погибло", "")
                .Replace("родил", "")
                .Replace("появилось", "")
                .Replace("округ", "")
                .Replace("кой", "")
                .Replace("кую", "")
                .Replace("в ", "")
                .Replace(" и", "")
                .Trim();
            return messageText;
        }

        #region Utils

        public static string FirstUpper(string str)
        {
            return str.Substring(0, 1).ToUpper() + (str.Length > 1 ? str.Substring(1) : "");
        }

        /// <summary>
        /// Наиболее общая подстрока
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static int LongestCommonSubstring(string str1, string str2)
        {
            if (String.IsNullOrEmpty(str1) || String.IsNullOrEmpty(str2))
                return 0;

            List<int[]> num = new List<int[]>();
            int maxlen = 0;
            for (int i = 0; i < str1.Length; i++)
            {
                num.Add(new int[str2.Length]);
                for (int j = 0; j < str2.Length; j++)
                {
                    if (str1[i] != str2[j])
                        num[i][j] = 0;
                    else
                    {
                        if ((i == 0) || (j == 0))
                            num[i][j] = 1;
                        else
                            num[i][j] = 1 + num[i - 1][j - 1];
                        if (num[i][j] > maxlen)
                            maxlen = num[i][j];
                    }
                    if (i >= 2)
                        num[i - 2] = null;
                }
            }
            return maxlen;
        }

        #endregion
    }
}