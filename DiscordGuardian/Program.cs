
using DiscordGuardian;
using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.Interactivity;
using DSharpPlus.Interactivity.Enums;
using DSharpPlus.Interactivity.Extensions;
using Microsoft.Extensions.Logging;

await main();

static async Task main()
{
    Console.WriteLine("Conectando MySql...");
    Banco.iniciar_conexao();
    var discord = new DiscordClient(new DiscordConfiguration()
    {
        Token = Banco.bot_token,
        TokenType = TokenType.Bot,
        MinimumLogLevel = LogLevel.Debug,
        LogTimestampFormat = "hh:mm:ss tt",
        Intents = DiscordIntents.All
    });
    discord.UseInteractivity(new InteractivityConfiguration()
    {
        PollBehaviour = PollBehaviour.KeepEmojis,
        Timeout = TimeSpan.FromSeconds(30)
    });

    var commands = discord.UseCommandsNext(new CommandsNextConfiguration()
    {
        StringPrefixes = new[] { "$" }
    });
   while(Banco.bot_status == true)
    {
        Console.WriteLine("Bot Online!");

        commands.RegisterCommands<Funcs>();
        await discord.ConnectAsync();
        await Task.Delay(-1);

    }
}
