using System.Text.Json.Serialization;
using SpaceTraders.Infrastructure.Modules.Authentication.UserInformation;

namespace SpaceTraders.Infrastructure.Api.Models.Authentication;

public class AgentResponse
{
    [JsonPropertyName("data")] 
    public AgentData Agent { get; set; }
}