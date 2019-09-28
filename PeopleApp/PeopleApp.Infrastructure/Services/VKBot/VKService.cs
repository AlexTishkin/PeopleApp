using System;
using System.Linq;

namespace PeopleApp.Infrastructure.Services.VKBot
{
    public class VKService : IVKService
    {
        public string GetHandledMessage(string message)
        {
            if (HelpHandling(ref message)) return message;
            if (GreetingHandling(ref message)) return message;
            if (ChatHandling(ref message)) return message;
            if (InterestFactsHandling(ref message)) return message;
            if (WhyItNeedsHandling(ref message)) return message;
            if (The2020YearHandling(ref message)) return message;
            if (StatInfoHandling(ref message)) return message;

            return "Пока не могу на это ответить. Но я учусь! :-)";
        }

        private bool HelpHandling(ref string message)
        {
            var messageText = message;
            var helpMessages = new[]
            {
                "?", "как это работает", "что тут делать", "справка", "help",
                "помоги", "помощь", "доброе утро"
            };

            if (helpMessages.Any(m => messageText.Contains(m)))
            {
                message = "Я Даня! Я хочу объяснить, зачем нужна перепись населения без нудной информации. :-)" +
                          "Если интересно узнать интересные факты, связанные с переписью" +
                          " населения, напиши 'Расскажи что-нибудь интересное'!\n" +
                          "Также вы можете получить следующую информацию:\n" +
                          "Численность населения какой-либо области - 'Сколько людей живет в Курской области'\n" +
                          "Рождаемость и Смертность за опеределенный год - 'Рождаемость/Смертность в Курской области в 2010 году.'\n" +
                          "Для того, чтобы лучше понять, зачем проводится перепись населения, и какую пользу она несет, также можете узнать у меня" +
                          "Вроде бы и все! Ах да! Чуть не забыл. В следующем году будет проводиться перепись населения. Для того, чтобы узнать подробнее о событии напишите '2020'";

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

            if (message.Contains("ок") || message.Contains("и у меня"))
            {
                message = "Супер! :-)";
                return true;
            }

            if (message.Contains("что делаешь") || message.Contains("маешься"))
            {
                message =
                    "Готовлюсь к переписи населения 2020. Если интересно, напиши 'Зачем нужна перепись населения?' :-)";
                return true;
            }

            return false;
        }

        private bool InterestFactsHandling(ref string message)
        {
            if (message.Contains("расскажи") || message.Contains("удиви"))
            {
                string result =
                    "Я могу быть очень полезен и поделиться с тобой интересными статистическими данными. Например, ";
                switch (new Random().Next(3))
                {
                    case 0:
                        result +=
                            " первая Всероссийская перепись была проведена в 2002 году. Она прошла под девизом <Впиши себя в историю России>";
                        break;
                    case 1:
                        result +=
                            " перепись на Руси провели еще татаро-монголы в 1245 году. Правда, учет не был общим: учитывались только дома для обложения данью.";
                        break;
                    case 2:
                        result +=
                            " во 2 веке до н.э. скифский царь Скилур решил провести подсчет подданных довольно необычным образом. Правитель велел каждому мужчине принести к его резиденции по одному наконечнику стрелы. Многие, так и не поняв замысла своего повелителя, в знак уважения принесли сразу несколько наконечников. Таким образом, переписи так и не суждено было осуществиться. Известно, что по замыслу выдающегося полководца хана Тамерлана воины вместо наконечников стрел должны были бросать камни.";
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
                message = "Перепись населения нужна, потому что...!";
                return true;
            }

            return false;
        }

        private bool The2020YearHandling(ref string message)
        {
            if (message.Contains("2020"))
            {
                message = "Выборы 2020 года будут...";
                return true;
            }
            return false;
        }

        private bool StatInfoHandling(ref string message)
        {
            if (message.Contains("сколько людей") || message.Contains("населений"))
            {
                // TODO: Стат. инфа с БД
                message = "100";
                return true;
            }

            if (message.Contains("рождаемость") || message.Contains("родил") || message.Contains("появилось"))
            {
                // TODO: Стат. инфа с БД
                message = "1000";
                return true;
            }

            if (message.Contains("смертность") || message.Contains("погиб") || message.Contains("умер"))
            {
                // TODO: Стат. инфа с БД
                message = "5000";
                return true;
            }
            return false;
        }

        #region Utils

        public static string FirstUpper(string str)
        {
            return str.Substring(0, 1).ToUpper() + (str.Length > 1 ? str.Substring(1) : "");
        }

        #endregion
    }
}