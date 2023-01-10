using Newtonsoft.Json;

namespace ask;

public static class FileManager
{
    public static async Task<string> Read(string fileName)
    {
        try
        {
            using var stream = new StreamReader(AppContext.BaseDirectory + fileName);
            var content = await stream.ReadToEndAsync();

            return content;
        }
        catch (FileNotFoundException)
        {
            throw new ConfigNotFoundException();
        }
    }

    public static async Task UpdateConfig(string propertyName, string value, string fileName)
    {
        var json = await Read(fileName);
        var config = JsonConvert.DeserializeObject<ConfigData>(json);
        
        var type = typeof(ConfigData);
        var propertyInfo = type.GetProperty(propertyName);
        propertyInfo!.SetValue(config, value, null);

        await Write(JsonConvert.SerializeObject(config, Formatting.Indented), fileName);
    }
    
    private static async Task Write(string data, string fileName)
    {
        await using var stream = new StreamWriter(AppContext.BaseDirectory + fileName);
        await stream.WriteAsync(data);
    }
}