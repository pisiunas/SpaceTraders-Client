using Newtonsoft.Json;

namespace SpaceTraders.Infrastructure.SpaceTradersConfig;

public static class SpaceTradersConfigExtensions
{
    public static T Apply<T>(this T obj, Action<T> action)
    {
        action(obj);
        return obj;
    }
    
    public static SpaceTradersConfig? GetDeserializedConfig() =>
        JsonConvert.DeserializeObject<SpaceTradersConfig>(File.ReadAllText(Constants.Paths.AppConfig));
    
    public static void WriteConfigToFile(SpaceTradersConfig? config) =>
        File.WriteAllText(Constants.Paths.AppConfig, JsonConvert.SerializeObject(config, Formatting.Indented));
}