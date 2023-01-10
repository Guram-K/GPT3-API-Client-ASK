namespace ask.Helpers;

public static class Constants
{
    public const string ConfigFile = "config.json";
    
    public const string Help = "Available commands with `ask`:" +
                               "\n   -up - tells ask that user intends to update configuration" +
                               "\n      -token - pairs after -up to update token in configuration" +
                               "\n      -uri - pairs after -up to update URI in configuration" +
                               "\n      -ai - pairs after -up to update AI model in configuration" +
                               "\n      -temp - pairs after -up to update AI model Temperature in configuration";
    
    public static readonly string[] UpdateCommands = { "-token", "-uri", "-ai", "-temp" };

    public static class Commands
    {
        public const string Update = "-up";
        public const string Help = "-help";
    }
}