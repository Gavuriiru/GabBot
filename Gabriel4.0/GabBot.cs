using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.EventArgs;
using Gabriel4._0.Comandos;
using Newtonsoft.Json;
using System;
using System.Drawing;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Console = Colorful.Console;

namespace GabBot
{
    public class GabBot
    {
        private DiscordClient _client;
        static void Main(string[] args) => new GabBot().RodarBotAsync().GetAwaiter().GetResult();

        public async Task RodarBotAsync()
        {

            var json = "";
            using (var inhau = File.OpenRead("corno.json"))
            using (var yay = new StreamReader(inhau, new UTF8Encoding(false)))
                json = await yay.ReadToEndAsync();

            var cfgjson = JsonConvert.DeserializeObject<ConfigJson>(json);

            Console.WriteAscii("Gabriel Tenma White", Color.Cyan);
            DiscordConfiguration cfg = new DiscordConfiguration

            {
                Token = cfgjson.Token,
                TokenType = TokenType.Bot,
                ReconnectIndefinitely = true,
                GatewayCompressionLevel = GatewayCompressionLevel.Stream,
                AutoReconnect = true,
                LogLevel = LogLevel.Debug,
                UseInternalLogHandler = true,

            };
            _client = new DiscordClient(cfg);
            _client.Ready += Client_Ready;
            _client.ClientErrored += Client_ClientError;

            string[] prefix = new string[1];
            prefix[0] = cfgjson.CommandPrefix;

            CommandsNextExtension cnt = _client.UseCommandsNext(new CommandsNextConfiguration()
            {
                StringPrefixes = prefix,
                EnableDms = true,
                CaseSensitive = false,
                EnableDefaultHelp = true,
                EnableMentionPrefix = true,
                IgnoreExtraArguments = true,
            });
            cnt.CommandExecuted += Cnt_CommandExecuted;
            cnt.RegisterCommands<Comandos_Foda_se>();
            cnt.RegisterCommands<NSFW>();
            cnt.RegisterCommands<Kt>();
            cnt.RegisterCommands<Coisa_de_fudido>();

            await _client.ConnectAsync();
            await Task.Delay(-1);
        }

        private Task Client_Ready(ReadyEventArgs e)
        {
            e.Client.DebugLogger.LogMessage(LogLevel.Info, "GabBot", "Tô on seu corno!", DateTime.Now);
            new Thread(async () =>
            {
                while (true)
                {
                    await _client.UpdateStatusAsync(new DSharpPlus.Entities.DiscordActivity("sua mãe me mamando", DSharpPlus.Entities.ActivityType.Watching), DSharpPlus.Entities.UserStatus.Online);
                    await Task.Delay(10000);
                    await _client.UpdateStatusAsync(new DSharpPlus.Entities.DiscordActivity("sua irmã na cama", DSharpPlus.Entities.ActivityType.Playing), DSharpPlus.Entities.UserStatus.Online);
                    await Task.Delay(10000);
                    await _client.UpdateStatusAsync(new DSharpPlus.Entities.DiscordActivity("sua tia gemendo", DSharpPlus.Entities.ActivityType.ListeningTo), DSharpPlus.Entities.UserStatus.Online);
                    await Task.Delay(10000);
                }
            }).Start();
            return Task.CompletedTask;
        }

        private Task Client_ClientError(ClientErrorEventArgs e)
        {
            e.Client.DebugLogger.LogMessage(LogLevel.Error, "GabBot", $"Deu merda seu corno:" +
                $" {e.Exception.GetType()}: {e.Exception.Message}", DateTime.Now);
            return Task.CompletedTask;
        }

        private Task Cnt_CommandExecuted(CommandExecutionEventArgs e)
        {
            e.Context.Client.DebugLogger.LogMessage(LogLevel.Info, $"GabBot", $"({e.Context.Guild?.Id}) {e.Context.Guild?.Name}" +
                $" ({e.Context.User.Id}) {e.Context.User.Username} executou '{e.Command.QualifiedName}'", DateTime.Now);
            return Task.CompletedTask;
        }
    }
    public struct ConfigJson
    {
        [JsonProperty("token")]
        public string Token { get; private set; }

        [JsonProperty("prefix")]
        public string CommandPrefix { get; private set; }
    }
}
