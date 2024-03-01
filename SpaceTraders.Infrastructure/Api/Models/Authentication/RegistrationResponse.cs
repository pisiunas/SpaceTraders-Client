using System.Text.Json.Serialization;
using SpaceTraders.Infrastructure.Modules.Authentication.UserInformation;

namespace SpaceTraders.Infrastructure.Api.Models.Authentication;

public class RegistrationResponse
{
    [JsonPropertyName("data")] 
    public UserData Data { get; set; }
}