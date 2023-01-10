using ask.Helpers;
using Newtonsoft.Json;

namespace ask.Services;

public class InputHandler
{
    public async Task Handle(string[] args)
    {
        if (args.Length > 0)
        {
            const string configFile = ".config.json";

            switch (args[0])
            {
                case "-up":
                    args.CheckElementAt(1);
                    
                    switch (args[1])
                    {
                        case "-token":
                            args.CheckElementAt(2);
                            await FileManager.UpdateConfig(nameof(ConfigData.Token), args[2], configFile);
                            break;
                        case "-uri":
                            args.CheckElementAt(2);
                            await FileManager.UpdateConfig(nameof(ConfigData.RequestUri), args[2], configFile);
                            break;
                        case "-ai":
                            args.CheckElementAt(2);
                            await FileManager.UpdateConfig(nameof(ConfigData.AiModel), args[2], configFile);
                            break;
                        case "-temp":
                            args.CheckElementAt(2);
                            await FileManager.UpdateConfig(nameof(ConfigData.Temperature), args[2], configFile);
                            break;
                        default:
                            Console.WriteLine("\ncommand not found write `ask -help` for available commands");
                            break;
                    }
                    return;
                case "-help":
                    Console.WriteLine("Available commands with `ask`:" +
                                      "\n  -up - tells ask that user intends to update configuration" +
                                      "\n     -token - pairs after -up to update token in configuration" +
                                      "\n     -uri - pairs after -up to update URI in configuration" +
                                      "\n     -ai - pairs after -up to update AI model in configuration" +
                                      "\n     -temp - pairs after -up to update AI model Temperature in configuration");
                    return;
            }

            var httpHandler = new HttpHandler();
            var responseString = await httpHandler.Request(configFile, args[0]);
            
            try
            {
                ParseResponseString(responseString);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"---> Could not deserialize the JSON: {ex.Message}");
                throw;
            }
        }
        else
            Console.WriteLine("---> You need to provide some input");
    }

    void ParseResponseString(string responseString)
    {
        var dynamicData = JsonConvert.DeserializeObject<dynamic>(responseString);
        var raw = dynamicData!.choices[0].text;
        
        Console.WriteLine("---> GPT-3 API Returned Text:");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine(raw);
    
        string[] rawArray = raw.ToString().Split('\n');
        var lastElement = rawArray.Last();
    
        Console.ResetColor();
        TextCopy.ClipboardService.SetText(lastElement);
    }
}