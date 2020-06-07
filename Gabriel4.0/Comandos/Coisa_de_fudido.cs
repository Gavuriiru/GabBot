using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using Newtonsoft.Json.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Gabriel4._0.Comandos
{
    class Coisa_de_fudido : BaseCommandModule
    {

        const string NekosLife = "https://nekos.life/api/v2/img/";

        [Command("AvatarAnime")]
        [Aliases("AvAn", "UA")]
        [Description("Manda uma foto que pode ser usada como avatar (você pode usar qualquer uma na real, mas essas vem no tamanho certinho)")]

        public async Task Perfil(CommandContext ctx)
        {
            WebClient webClient = new WebClient();
            JObject fotodeperfil = JObject.Parse(await webClient.DownloadStringTaskAsync(NekosLife+"avatar"));
            await ctx.TriggerTypingAsync();
            await ctx.RespondAsync(embed: new DiscordEmbedBuilder
            {
                Title = "É de seu gosto?",
                Description = $"[Clique aqui]({fotodeperfil["url"]})",
                ImageUrl = (string)fotodeperfil["url"],
                Color = DiscordColor.Cyan
            });
        }

        [Command("Wallpaper")]
        [Aliases("Wpp", "PDP")]
        [Description("Manda um wallpaper")]

        public async Task PapelDeParede(CommandContext ctx)
        {
            WebClient webClient = new WebClient();
            JObject wall = JObject.Parse(await webClient.DownloadStringTaskAsync(NekosLife+"wallpaper"));
            await ctx.TriggerTypingAsync();
            await ctx.RespondAsync(embed: new DiscordEmbedBuilder
            {
                Title = "Que tal esse?!",
                Description = $"[Clique aqui]({wall["url"]})",
                ImageUrl = (string)wall["url"],
                Color = DiscordColor.Cyan
            });
        }
    }
}
