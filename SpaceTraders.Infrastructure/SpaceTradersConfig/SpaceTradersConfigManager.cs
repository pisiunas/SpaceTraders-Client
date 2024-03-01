namespace SpaceTraders.Infrastructure.SpaceTradersConfig;

public class SpaceTradersConfigManager : ISpaceTradersConfigManager
{
    public bool GetIsRegistered() => SpaceTradersConfigExtensions.GetDeserializedConfig()!.IsRegistered;

    public void SetIsRegistered(bool isRegistered) =>
        SpaceTradersConfigExtensions.WriteConfigToFile(SpaceTradersConfigExtensions.GetDeserializedConfig()?.Apply(x => x.IsRegistered = isRegistered));

    public string GetToken() => SpaceTradersConfigExtensions.GetDeserializedConfig()!.Token;

    public void RemoveToken() =>
        SpaceTradersConfigExtensions.WriteConfigToFile(SpaceTradersConfigExtensions.GetDeserializedConfig()?.Apply(x => x.Token = string.Empty));
    
    public void SetToken(string token) => SpaceTradersConfigExtensions.WriteConfigToFile(SpaceTradersConfigExtensions.GetDeserializedConfig()?.Apply(x => x.Token = token));
}