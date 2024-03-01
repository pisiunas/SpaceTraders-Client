namespace SpaceTraders.Infrastructure.SpaceTradersConfig;

public interface ISpaceTradersConfigManager
{
    bool GetIsRegistered();
    void SetIsRegistered(bool isRegistered);
    
    string GetToken();
    void RemoveToken();
    void SetToken(string token);
}