using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using System.Threading.Tasks;

namespace Gabriel4._0.Comandos
{
    public class Comandos_Foda_se : BaseCommandModule

    {
        [Command("Avatar")]
        [Aliases("A")]
        [Description("Exibe o avatar de quem usou o comando, ou do usuário mencionado.")]

        public async Task AvatarAsync(CommandContext ctx, [RemainingText] DiscordUser user = null)
        {
            await ctx.TriggerTypingAsync();
            if (user == null) user = ctx.User;
            if (user == ctx.Client.CurrentUser)
                await ctx.RespondAsync(embed: new DiscordEmbedBuilder
                { 
                    Title = "Estou feliz que queira me ver :thumbsup:",
                    Description = $"[Clique aqui]({user.AvatarUrl})",
                    ImageUrl = user.AvatarUrl,
                    Color = DiscordColor.Aquamarine
            });

            else
                await ctx.RespondAsync(embed: new DiscordEmbedBuilder
                {
                    Title = "Nice avatar, bro!",
                    Description = $"[Clique aqui]({user.AvatarUrl})",
                    ImageUrl = user.AvatarUrl,
                    Color = DiscordColor.Aquamarine
                });
        }

        [Command("ping")]
        [Description("Pong!")]

        public async Task PingAsync(CommandContext ctx)
        {
            await ctx.TriggerTypingAsync();
            await ctx.RespondAsync(embed: new DiscordEmbedBuilder
            {
                Description = ctx.Client.Ping.ToString()+"ms :ping_pong:",
                Color = DiscordColor.Aquamarine
            });

        }

        public string IconUrl { get; }
        [Command("Icone")]
        [Aliases("Icon")]
        [Description("Exibe o ícone do servidor.")]

        public async Task IconAsync(CommandContext ctx, DiscordGuild guild = null)
        {
            await ctx.TriggerTypingAsync();
            if (guild == null) guild = ctx.Guild;
                await ctx.RespondAsync(embed: new DiscordEmbedBuilder
                { 
                    Title = "Aqui a foto do servidor:",
                    Description = $"[Clique aqui]({guild.IconUrl})",
                    ImageUrl = guild.IconUrl+"?size=2048",
                    Color = DiscordColor.Aquamarine
            });

        }

        [Command("Say")]
        [Aliases("Diga")]
        [Description("Diz o que você digitar.")]

        public async Task SayAsync(CommandContext ctx, [RemainingText]string msg)
        {
            await ctx.TriggerTypingAsync();
            await ctx.RespondAsync(msg);
            await ctx.Message.DeleteAsync();
        }
    }
}
