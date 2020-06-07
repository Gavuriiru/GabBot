using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Gabriel4._0.Comandos
{
    public class NSFW : BaseCommandModule
    {

        readonly string NekosLife = "https://nekos.life/api/v2/img/";
        readonly string LolisLife = "https://api.lolis.life/random?category=";

        [Command("Hentai")]
        [Aliases("H", "Ero")]
        [Description("Hentai é hentai ué.")]
        [RequireNsfw]

        public async Task Gozei(CommandContext ctx)
        {
            WebClient webClient = new WebClient();
            JObject eitabichosexokkkkkkkkkkkkk = JObject.Parse(await webClient.DownloadStringTaskAsync(NekosLife + "/hentai"));
            await ctx.TriggerTypingAsync();
            await ctx.RespondAsync(embed: new DiscordEmbedBuilder
            {
                Title = "Eita bicho, sexokkkkkkkkkkkkkkkk",
                Description = $"[Clique aqui]({eitabichosexokkkkkkkkkkkkk["url"]})",
                ImageUrl = (string)eitabichosexokkkkkkkkkkkkk["url"],
                Color = DiscordColor.Lilac
            });
        }

        [Command("LLewd")]
        [Aliases("LL")]
        [Description("Lewd de lolis gasosas.")]
        [Hidden]
        [RequireNsfw]

        public async Task Lolis_Safadas(CommandContext ctx)
        {
            WebClient webClient = new WebClient();
            JObject lewd = JObject.Parse(await webClient.DownloadStringTaskAsync(LolisLife + "lewd"));
            await ctx.TriggerTypingAsync();
            await ctx.RespondAsync(embed: new DiscordEmbedBuilder
            {
                Title = "Fica quietinho se não cê vai preso!",
                Description = $"[Clique aqui]({lewd["url"]})",
                ImageUrl = (string)lewd["url"],
                Color = DiscordColor.Lilac
            });
        }

        [Command("kuni")]
        [Aliases("lambe", "lingua")]
        [Description("Hentai é hentai ué.")]
        [RequireNsfw]

        public async Task Lingua(CommandContext ctx)
        {
            WebClient webClient = new WebClient();
            JObject lambelambe = JObject.Parse(await webClient.DownloadStringTaskAsync(NekosLife + "/kuni"));
            await ctx.TriggerTypingAsync();
            await ctx.RespondAsync(embed: new DiscordEmbedBuilder
            {
                Title = "Lambe vai!",
                Description = $"[Clique aqui]({lambelambe["url"]})",
                ImageUrl = (string)lambelambe["url"],
                Color = DiscordColor.Lilac
            });
        }

        [Command("NekoLewd")]
        [Aliases("NL")]
        [Description("Gatinhas peladas.")]
        [RequireNsfw]
        public async Task Orelhas_do_jeito_massa(CommandContext ctx)
        {
            WebClient webClient = new WebClient();
            JObject miaul = JObject.Parse(await webClient.DownloadStringTaskAsync(NekosLife + "/lewd"));
            await ctx.TriggerTypingAsync();
            await ctx.RespondAsync(embed: new DiscordEmbedBuilder
            {
                Title = "Tú tá aqui pelos pelos ou pelas partes intimas?",
                Description = $"[Clique aqui]({miaul["url"]})",
                ImageUrl = (string)miaul["url"],
                Color = DiscordColor.Lilac
            });
        }

        [Command("Pussy")]
        [Aliases("ppk", "dlç")]
        [Description("Gifs de cenas legais de animes.")]
        [RequireNsfw]

        public async Task BUCETA(CommandContext ctx)
        {
            WebClient webClient = new WebClient();
            JObject ppk = JObject.Parse(await webClient.DownloadStringTaskAsync(NekosLife + "/pussy"));
            await ctx.TriggerTypingAsync();
            await ctx.RespondAsync(embed: new DiscordEmbedBuilder
            {
                Title = "Isso sim é bom!",
                Description = $"[Clique aqui]({ppk["url"]})",
                ImageUrl = (string)ppk["url"],
                Color = DiscordColor.Lilac
            });
        }

        [Command("PussyJPG")]
        [Aliases("jpg", "jpeg")]
        [Description("Ilustrações interessantes.")]
        [RequireNsfw]

        public async Task BUCETAimg(CommandContext ctx)
        {
            WebClient webClient = new WebClient();
            JObject aa = JObject.Parse(await webClient.DownloadStringTaskAsync(NekosLife + "/pussy_jpg"));
            await ctx.TriggerTypingAsync();
            await ctx.RespondAsync(embed: new DiscordEmbedBuilder
            {
                Title = "aAaAaAaAaAa!",
                Description = $"[Clique aqui]({aa["url"]})",
                ImageUrl = (string)aa["url"],
                Color = DiscordColor.Lilac
            });
        }

        [Command("Femdom")]
        [Aliases("fdm")]
        [Description("Ih ala, dominado por muié, gado d+++ kkkkkkkkkkkkkkkkkkkkkkk")]
        [RequireNsfw]

        public async Task Coino(CommandContext ctx)
        {
            WebClient webClient = new WebClient();
            JObject supamasn = JObject.Parse(await webClient.DownloadStringTaskAsync(NekosLife + "/femdom"));
            await ctx.TriggerTypingAsync();
            await ctx.RespondAsync(embed: new DiscordEmbedBuilder
            {
                Title = "Ih ala, dominado, gado d+ kkkkkkkkkkkkkkkkkkkkkkkkkkkkkk",
                Description = $"[Clique aqui]({supamasn["url"]})",
                ImageUrl = (string)supamasn["url"],
                Color = DiscordColor.Lilac
            });
        }

        [Command("lewdk")]
        [Aliases("lewdkitsune")]
        [Description("Fotos camaradas de kitsunes.")]
        [RequireNsfw]

        public async Task RaposasGasosas(CommandContext ctx)
        {
            WebClient webClient = new WebClient();
            JObject ahri = JObject.Parse(await webClient.DownloadStringTaskAsync(NekosLife + "/lewdk"));
            await ctx.TriggerTypingAsync();
            await ctx.RespondAsync(embed: new DiscordEmbedBuilder
            {
                Title = "Main Ahri? Oi?",
                Description = $"[Clique aqui]({ahri["url"]})",
                ImageUrl = (string)ahri["url"],
                Color = DiscordColor.Lilac
            });
        }

        [Command("Yuri")]
        [Aliases("tesoura")]
        [Description("Tesourada braba dms.")]
        [RequireNsfw]

        public async Task Tesorinha(CommandContext ctx)
        {
            WebClient webClient = new WebClient();
            JObject MarceloRezende = JObject.Parse(await webClient.DownloadStringTaskAsync(NekosLife + "/yuri"));
            await ctx.TriggerTypingAsync();
            await ctx.RespondAsync(embed: new DiscordEmbedBuilder
            {
                Title = "A tesoura é com ou sem ponta?",
                Description = $"[Clique aqui]({MarceloRezende["url"]})",
                ImageUrl = (string)MarceloRezende["url"],
                Color = DiscordColor.Lilac
            });
        }

        [Command("Tits")]
        [Aliases("Tetas")]
        [Description("Peitinhos (e de vez em quando algo a mais).")]
        [RequireNsfw]

        public async Task CortaPra18(CommandContext ctx)
        {
            WebClient webClient = new WebClient();
            JObject Peitos = JObject.Parse(await webClient.DownloadStringTaskAsync(NekosLife + "/tits"));
            await ctx.TriggerTypingAsync();
            await ctx.RespondAsync(embed: new DiscordEmbedBuilder
            {
                Title = "Pelo menos não é uma tábua.",
                Description = $"[Clique aqui]({Peitos["url"]})",
                ImageUrl = (string)Peitos["url"],
                Color = DiscordColor.Lilac
            });
        }

        [Command("LKemonomimi")]
        [Aliases("LewdKemo")]
        [Description("Menininhas com orelhas e rabinhos de uma maneira legal.")]
        [RequireNsfw]

        public async Task MeninasAnimaisGasosas(CommandContext ctx)
        {
            WebClient webClient = new WebClient();
            JObject dsa = JObject.Parse(await webClient.DownloadStringTaskAsync(NekosLife + "/lewdkemo"));
            await ctx.TriggerTypingAsync();
            await ctx.RespondAsync(embed: new DiscordEmbedBuilder
            {
                Title = "HMMMMMMMMMMMMMMMMMMMM",
                Description = $"[Clique aqui]({dsa["url"]})",
                ImageUrl = (string)dsa["url"],
                Color = DiscordColor.Lilac
            });
        }

        [Command("Anal")]
        [Aliases("Cu")]
        [Description("...")]
        [RequireNsfw]

        public async Task SecsuAnaaaaal(CommandContext ctx)
        {
            WebClient webClient = new WebClient();
            JObject uuu = JObject.Parse(await webClient.DownloadStringTaskAsync(NekosLife + "/anal"));
            await ctx.TriggerTypingAsync();
            await ctx.RespondAsync(embed: new DiscordEmbedBuilder
            {
                Title = "Chico Bioca curte isso!",
                Description = $"[Clique aqui]({uuu["url"]})",
                ImageUrl = (string)uuu["url"],
                Color = DiscordColor.Lilac
            });
        }
    }
}