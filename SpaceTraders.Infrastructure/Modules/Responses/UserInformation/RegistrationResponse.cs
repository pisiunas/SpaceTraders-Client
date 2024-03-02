using System.Text.Json.Serialization;

namespace SpaceTraders.Infrastructure.Modules.Responses.UserInformation;

public class RegistrationResponse
{
    [JsonPropertyName("data")] 
    public RegistrationData Data { get; set; }
}

public class RegistrationData
{
    [JsonPropertyName("token")] 
    public string Token { get; set; }
}
