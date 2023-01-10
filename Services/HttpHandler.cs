using System.Text;
using ask.Helpers;
using Newtonsoft.Json;

namespace ask.Services;

public class HttpHandler
{
    private string? BearerToken { get; set; }
    private string? RequestUri { get; set; }
    private string? AiModel { get; set; }
    private string? Temperature { get; set; }

    public async Task<string> Request(string fileName, string command)
    {
        await SetVariables(fileName);
        using var client = new HttpClient();
        
        client.DefaultRequestHeaders.Add("authorization", BearerToken ?? throw new TokenNotSetException());
        var content =
            new StringContent(
                "{\"model\": \"" + AiModel + "\", \"prompt\": \"" + command + "\",\"temperature\": " + Temperature +
                ",\"max_tokens\": 100}", Encoding.UTF8, "application/json");
        
        var response = await client.PostAsync(RequestUri, content);
        var responseString = await response.Content.ReadAsStringAsync();

        return responseString;
    }
    
    public string ParseResponseString(string responseString)
    {
        var dynamicData = JsonConvert.DeserializeObject<dynamic>(responseString);
        var raw = dynamicData!.choices[0].text;
        string[] rawArray = raw.ToString().Split('\n');
    
        Console.ResetColor();
        TextCopy.ClipboardService.SetText(rawArray.Last());

        return raw;
    }
    
    private async Task SetVariables(string fileName)
    {
        var jsonContent = await FileManager.Read(fileName);
        var data = JsonConvert.DeserializeObject<ConfigData>(jsonContent);

        if (data is null)
            throw new ConfigNotFoundException();

        BearerToken = string.IsNullOrWhiteSpace(data.Token) ? throw new TokenNotSetException() : $"Bearer {data.Token}";
        RequestUri = string.IsNullOrWhiteSpace(data.RequestUri) ? throw new RequestUriNotSetException() : data.RequestUri;
        AiModel = string.IsNullOrWhiteSpace(data.AiModel) ? throw new AiModelNotSetException() : data.AiModel;
        Temperature = string.IsNullOrWhiteSpace(data.Temperature) ? throw new TemperatureNotSetException() : data.Temperature;
    }
}