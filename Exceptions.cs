namespace ask;

public class ExceptionBase : Exception
{
    public string? ErrorMassage { get; protected set; }
}

public abstract class ConfigurationException : ExceptionBase
{
    private const string ConfigExample = "{\n  \"Token\": \"<your access token>\",\n  \"RequestUri\": \"https://api.openai.com/v1/completions\",\n  \"AiModel\": \"text-davinci-001\",\n  \"Temperature\": \"0\"\n}";

    protected const string ConfigMessage =
        $"please make sure that .config.json file was not changed manually and has correct structure.\nExample: \n{ConfigExample}";
}

public class TokenNotSetException : ConfigurationException
{
    public TokenNotSetException()
    {
        ErrorMassage = $"\nAccess token not found, {ConfigMessage}\nTo configure token run command: `ask -up -token your-token`";
    }
}

public class RequestUriNotSetException : ConfigurationException
{
    public RequestUriNotSetException()
    {
        ErrorMassage = $"\nRequest URI not found, {ConfigMessage}";
    }
}

public class AiModelNotSetException : ConfigurationException
{
    public AiModelNotSetException()
    {
        ErrorMassage = $"\nRequest URI not found, {ConfigMessage}";
    }
}

public class TemperatureNotSetException : ConfigurationException
{
    public TemperatureNotSetException()
    {
        ErrorMassage = $"\nTemperature not found, {ConfigMessage}";
    }
}

public class ConfigNotFoundException : ExceptionBase
{
    public ConfigNotFoundException()
    {
        ErrorMassage =
            "\n.config.json file not found, please make sure that .config.json file exists in the same location as ask.exe";
    }
}

public class ParameterNullException : ExceptionBase
{
    public ParameterNullException()
    {
        ErrorMassage = "\nParameterNullException: please provide missing parameter, `ask -help` for available commands";
    }
}