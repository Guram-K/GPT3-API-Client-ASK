using ask.Helpers;

namespace ask.Services;

public class InputHandler
{
    public async Task Handle(string[] args)
    {
        if (args.Length <= 0)
        {
            Console.WriteLine("---> You need to provide some input");
            return;
        }

        if (await HandleCommands(args)) return;
        
        await HandleRequest(args);
    }

    private async Task<bool> HandleCommands(IReadOnlyList<string> args)
    {
        switch (args[0])
        {
            case Constants.Commands.Update:
                args.CheckElementAt(1);

                if (!Constants.UpdateCommands.Contains(args[1]))
                    Console.WriteLine("\ncommand not found write `ask -help` for available commands");

                args.CheckElementAt(2);
                await FileManager.UpdateConfig(nameof(ConfigData.Token), args[2], Constants.ConfigFile);

                return true;
            case Constants.Commands.Help:
                Console.WriteLine(Constants.Help);
                return true;
        }

        return false;
    }

    private async Task HandleRequest(IReadOnlyList<string> args)
    {
        var httpHandler = new HttpHandler();
        var responseString = await httpHandler.Request(Constants.ConfigFile, args[0]);

        try
        {
            var parsedResponse = httpHandler.ParseResponseString(responseString);

            Console.WriteLine("---> GPT-3 API Returned Text:");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(parsedResponse);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"---> Could not deserialize the JSON: {ex.Message}");
            throw;
        }
    }
}