using System.Text.Json.Serialization;

namespace SpaceTraders.Infrastructure.Api.Models.ServerInformation;

public class ServerInformationStats
{
    [JsonPropertyName("agents")]
    public int Agents { get; set; }
    
    [JsonPropertyName("ships")]
    public int Ships { get; set; }
    
    [JsonPropertyName("systems")]
    public int Systems { get; set; }
    
    [JsonPropertyName("waypoints")]
    public int Waypoints { get; set; }
}