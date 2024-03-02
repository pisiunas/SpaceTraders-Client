using System.Text.Json.Serialization;

namespace SpaceTraders.Infrastructure.Api.Models.Authentication;

public sealed record RegistrationRequest(string Faction, string AgentName, string Email)
{
    [JsonPropertyName("faction")]
    public string Faction { get; } = Faction;

    [JsonPropertyName("symbol")]
    public string AgentName { get; } = AgentName;

    [JsonPropertyName("email")]
    public string Email { get; } = Email;
}
