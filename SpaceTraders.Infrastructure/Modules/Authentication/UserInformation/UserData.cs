using System.Text.Json.Serialization;

namespace SpaceTraders.Infrastructure.Modules.Authentication.UserInformation;

public class UserData
{
    [JsonPropertyName("agent")]
    public AgentData Agent { get; set; }
    
    [JsonPropertyName("contract")]
    public ContractData Contract { get; set; }
    
    [JsonPropertyName("faction")]
    public FactionData Faction { get; set; }
    
    [JsonPropertyName("ship")]
    public ShipData Ship { get; set; }
    
    [JsonPropertyName("token")]
    public string Token { get; set; }
}