using System.Text.Json.Serialization;

namespace SpaceTraders.Infrastructure.Modules.Responses.UserInformation;

public class AgentResponse
{
    [JsonPropertyName("data")]
    public AgentData Data { get; set; }
}

public class AgentData
{
    [JsonPropertyName("accountId")]
    public string AccountId { get; set; }

    [JsonPropertyName("symbol")]
    public string Symbol { get; set; }

    [JsonPropertyName("headquarters")]
    public string Headquarters { get; set; }

    [JsonPropertyName("credits")]
    public int Credits { get; set; }

    [JsonPropertyName("startingFaction")]
    public string StartingFaction { get; set; }

    [JsonPropertyName("shipCount")]
    public int ShipCount { get; set; }
}
