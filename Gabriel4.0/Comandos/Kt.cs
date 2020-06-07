using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Gabriel4._0.Ignore;
using System;
using Microsoft.VisualBasic;

namespace Gabriel4._0.Comandos
{
    class Kt : BaseCommandModule
    {
        const string LolisLife = "https://api.lolis.life/random";
        const string NekosLife = "https://nekos.life/api/v2/img/";
        const string Dbooru = "https://danbooru.donmai.us/posts.json?login=";

        [Command("Foda-se")]
        [Aliases("Fodase", "fds")]
        [Description("Foda-se")]

        public async Task FodeuMesmo (CommandContext ctx)
        {

            await ctx.RespondAsync(embed: new DiscordEmbedBuilder
            {
                Title = "Foda-se?",
                ImageUrl = Fodase.Links[new Random().Next(0, Fodase.Links.Length)],
                Color = DiscordColor.Purple
            });
        }


        [Command("Loli")]
        [Aliases("L")]
        [Description("Lolis.")]
        [Hidden]

        public async Task Lolis(CommandContext ctx)
        {
            WebClient webClient = new WebClient();
            JObject saudavel = JObject.Parse(await webClient.DownloadStringTaskAsync(LolisLife));
            await ctx.TriggerTypingAsync();
            await ctx.RespondAsync(embed: new DiscordEmbedBuilder
            {
                Title = "Então quer dizer que você curte do negócio bão?",
                Description = $"[Clique aqui]({saudavel["url"]})",
                ImageUrl = (string)saudavel["url"],
                Color = DiscordColor.Purple
            });
        }

        [Command("Neko")]
        [Aliases("Gatinha")]
        [Description("Meninas com orelhas de gato.")]

        public async Task Orelhas(CommandContext ctx)
        {
            WebClient webClient = new WebClient();
            JObject miau = JObject.Parse(await webClient.DownloadStringTaskAsync(NekosLife + "neko"));
            await ctx.TriggerTypingAsync();
            await ctx.RespondAsync(embed: new DiscordEmbedBuilder
            {
                Title = "Furro?",
                Description = $"[Clique aqui]({miau["url"]})",
                ImageUrl = (string)miau["url"],
                Color = DiscordColor.Purple
            });
        }

        [Command("NGif")]
        [Aliases("nekogif")]
        [Description("GIFs de meninas gato.")]

        public async Task NekoAnimada(CommandContext ctx)
        {
            WebClient webClient = new WebClient();
            JObject foda = JObject.Parse(await webClient.DownloadStringTaskAsync("https://nekos.life/api/v2/img/ngif"));
            await ctx.TriggerTypingAsync();
            await ctx.RespondAsync(embed: new DiscordEmbedBuilder
            {
                Title = "Gif de menininhas, brabo!",
                Description = $"[Clique aqui]({foda["url"]})",
                ImageUrl = (string)foda["url"],
                Color = DiscordColor.Purple
            });
        }

        [Command("Yandere")]
        [Aliases("yde")]
        [Description("Te manda uma imagem aleatória, ou com a tag especificada.")]

        public async Task Caralhocoisaruim(CommandContext ctx, [RemainingText]string hoshii)
        {
            var json = "";
            using (var inhau = File.OpenRead("login.json"))
            using (var yay = new StreamReader(inhau, new UTF8Encoding(false)))
                json = await yay.ReadToEndAsync();

            var auau = JsonConvert.DeserializeObject<Yayyy>(json);

            if (ctx.Channel.IsNSFW)
            {
                if (hoshii == null)
                {
                    WebClient webClient = new WebClient();
                    JArray yay = JArray.Parse(await webClient.DownloadStringTaskAsync($"https://yande.re/post.json?login={auau.YouWatanabe}&limit=1&tags=order%3Arandom+rating%3Aexplicit"));
                    await ctx.TriggerTypingAsync();
                    await ctx.RespondAsync(embed: new DiscordEmbedBuilder
                    {
                        Title = "Ih ala, canal NSFW, vai rolar putaria.",
                        Description = $"[Imagem completa]({(string)yay[0]["file_url"]})",
                        ImageUrl = (string)yay[0]["preview_url"],
                        Color = DiscordColor.Lilac
                    });
                }
                else
                {
                    WebClient webClient = new WebClient();
                    JArray yay = JArray.Parse(await webClient.DownloadStringTaskAsync($"https://yande.re/post.json?login={auau.YouWatanabe}&limit=1&tags=order%3Arandom+rating%3Aexplicit+" + hoshii.Replace(' ', '_')));
                    await ctx.TriggerTypingAsync();
                    await ctx.RespondAsync(embed: new DiscordEmbedBuilder
                    {
                        Title = "Pelo visto você tem gosto.",
                        Description = $"[Imagem completa]({(string)yay[0]["file_url"]})",
                        ImageUrl = (string)yay[0]["preview_url"],
                        Color = DiscordColor.Lilac
                    });
                }
            }
            else
            {
                if (hoshii == null)
                {
                    WebClient webClient = new WebClient();
                    JArray yay = JArray.Parse(await webClient.DownloadStringTaskAsync($"https://yande.re/post.json?login={auau.YouWatanabe}&limit=1&tags=order%3Arandom+rating%3Asafe"));
                    await ctx.TriggerTypingAsync();
                    await ctx.RespondAsync(embed: new DiscordEmbedBuilder
                    {
                        Title = "Só posso mostrar isso nesse canal meu caro.",
                        Description = $"[Imagem completa]({(string)yay[0]["file_url"]})",
                        ImageUrl = (string)yay[0]["preview_url"],
                        Color = DiscordColor.Lilac
                    });
                }
                else
                {
                    WebClient webClient = new WebClient();
                    JArray yay = JArray.Parse(await webClient.DownloadStringTaskAsync($"https://yande.re/post.json?login={auau.YouWatanabe}&limit=1&tags=order%3Arandom+rating%3Asafe+" + hoshii.Replace(' ', '_')));
                    await ctx.TriggerTypingAsync();
                    await ctx.RespondAsync(embed: new DiscordEmbedBuilder
                    {
                        Title = "Você tem bom gosto!.",
                        Description = $"[Imagem completa]({(string)yay[0]["file_url"]})",
                        ImageUrl = (string)yay[0]["preview_url"],
                        Color = DiscordColor.Lilac
                    });
                }

            }
        }

        [Command("Danbooru")]
        [Aliases("dbr")]
        [Description("Te manda uma imagem aleatória, ou com a tag especificada.")]

        public async Task Danbooru (CommandContext ctx, [RemainingText]string hoshii)
        {
            var json = "";
            using (var inhau = File.OpenRead("login.json"))
            using (var yay = new StreamReader(inhau, new UTF8Encoding(false)))
                json = await yay.ReadToEndAsync();

            var auau = JsonConvert.DeserializeObject<Yayyy>(json);

            if (ctx.Channel.IsNSFW)
            {
                if (hoshii == null)
                {
                    WebClient webClient = new WebClient();
                    JArray yay = JArray.Parse(await webClient.DownloadStringTaskAsync(Dbooru+auau.Dbr+ "&limit=1&random=true&tags=rating%3Aexplicit"));
                    await ctx.TriggerTypingAsync();
                    await ctx.RespondAsync(embed: new DiscordEmbedBuilder
                    {
                        Title = "Yande.re > Danbooru.",
                        Description = $"[Imagem completa]({(string)yay[0]["large_file_url"]})",
                        ImageUrl = (string)yay[0]["file_url"],
                        Color = DiscordColor.Lilac
                    });
                }
                else
                {
                    WebClient webClient = new WebClient();
                    JArray yay = JArray.Parse(await webClient.DownloadStringTaskAsync(Dbooru + auau.Dbr + "&limit=1&random=true&tags=rating%3Aexplicit+" + hoshii));
                    await ctx.TriggerTypingAsync();
                    await ctx.RespondAsync(embed: new DiscordEmbedBuilder
                    {
                        Title = "Yande.re > Danbooru.",
                        Description = $"[Imagem completa]({(string)yay[0]["large_file_url"]})",
                        ImageUrl = (string)yay[0]["file_url"],
                        Color = DiscordColor.Lilac
                    });
                }
            }
            else
            {
                if (hoshii == null)
                {
                    WebClient webClient = new WebClient();
                    JArray yay = JArray.Parse(await webClient.DownloadStringTaskAsync(Dbooru + auau.Dbr + "&limit=1&random=true&tags=rating%3Asafe"));
                    await ctx.TriggerTypingAsync();
                    await ctx.RespondAsync(embed: new DiscordEmbedBuilder
                    {
                        Title = "Yande.re > Danbooru.",
                        Description = $"[Imagem completa]({(string)yay[0]["large_file_url"]})",
                        ImageUrl = (string)yay[0]["file_url"],
                        Color = DiscordColor.Purple
                    });
                }
                else
                {
                    WebClient webClient = new WebClient();
                    JArray yay = JArray.Parse(await webClient.DownloadStringTaskAsync(Dbooru + auau.Dbr + "&limit=1&random=true&tags=rating%3Asafe+" + hoshii));
                    await ctx.TriggerTypingAsync();
                    await ctx.RespondAsync(embed: new DiscordEmbedBuilder
                    {
                        Title = "Yande.re > Danbooru.",
                        Description = $"[Imagem completa]({(string)yay[0]["large_file_url"]})",
                        ImageUrl = (string)yay[0]["file_url"],
                        Color = DiscordColor.Purple
                    });
                }

            }
        }
        public struct Yayyy
        {
            [JsonProperty("yandere")]
            public string YouWatanabe { get; private set; }

            [JsonProperty("danbooru")]
            public string Dbr { get; private set; }
        }
    }
}