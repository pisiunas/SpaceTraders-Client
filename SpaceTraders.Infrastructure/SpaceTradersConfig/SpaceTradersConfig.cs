using System.Text.Json.Serialization;

namespace SpaceTraders.Infrastructure.SpaceTradersConfig;

public class SpaceTradersConfig
{
    [JsonPropertyName("IsRegistered")] 
    public bool IsRegistered { get; set; }
    
    [JsonPropertyName("Token")] 
    public string Token { get; set; }
}