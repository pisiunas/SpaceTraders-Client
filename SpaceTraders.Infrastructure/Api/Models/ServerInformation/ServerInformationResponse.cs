using System.Text.Json.Serialization;

namespace SpaceTraders.Infrastructure.Api.Models.ServerInformation;

public class ServerInformationResponse
{
    [JsonPropertyName("status")]
    public string Status { get; set; }
    
    [JsonPropertyName("version")]
    public string Version { get; set; }
    
    [JsonPropertyName("resetDate")]
    public string ResetDate { get; set; }
    
    [JsonPropertyName("description")]
    public string Description { get; set; }

    [JsonPropertyName("stats")] 
    public ServerInformationStats StatsList { get; set; }
}