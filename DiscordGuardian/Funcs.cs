using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using DSharpPlus.SlashCommands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordGuardian
{
    public class Funcs : BaseCommandModule
    {
        [Command("liberar")]
        public async Task liberar(CommandContext ctx, String username)
        {
            bool registered = Banco.user_auth_mc(username);
            if(registered != false)
            {
                await ctx.RespondAsync($"Nick ({username}) Liberado!");
            }
            else
            {
                await ctx.RespondAsync($"O nick ({username}) não foi possivel liberar!");
            }

        }
    }
}
