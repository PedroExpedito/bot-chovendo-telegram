using System;
using Telegram.Bot;
using Telegram.Bot.Args;
using System.Threading;

namespace BotTempo {
    class TelegramBot {

        static ITelegramBotClient botClient;
        private static string token = "1693521384:AAEiFI1Gm9vLZcW-nGopDeDNMJC6_Dk6z-k";

        public void Start() {
            botClient = new TelegramBotClient(token);

            var me = botClient.GetMeAsync().Result;
            Console.WriteLine(
                    $"Hello, World! I am user {me.Id} and my name is {me.FirstName}."
                    );

            botClient.OnMessage += Bot_OnMessage;

            botClient.StartReceiving();

            Console.WriteLine("Press any key to exit");
            Console.ReadKey();

            botClient.StopReceiving();
            Console.WriteLine("Closing...");
        }

        static async void Bot_OnMessage(object sender, MessageEventArgs e) {
            string mensagem = TratarString.getStringNoSpecialChar(e.Message.Text);

            try {
                GetCidadeId city = await GetCidadeId.GetCityAsync(mensagem);
                if(city != null) {
                    CidadePrevisao previsao =
                        await CidadePrevisao.
                        GetPrevisaoAsync(city.cidade[0].id.ToString());

                    await botClient.SendTextMessageAsync(
                            chatId: e.Message.Chat,
                            text: CidadePrevisao.FormatandoPrevisao(previsao)
                            );
                }

            } catch(Exception ex) {
                await botClient.SendTextMessageAsync(
                        chatId: e.Message.Chat,
                        text: "Nenhuma cidade foi encontrada!");
                Console.WriteLine("error:" + ex.Message);
            }

        }

    }
}


