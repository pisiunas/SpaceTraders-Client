using System.Text.Json.Serialization;

namespace SpaceTraders.Infrastructure.Modules.Contracts;

public class ContractPaymentData
{
    [JsonPropertyName("onAccepted")] 
    public int OnAccepted { get; set; }

    [JsonPropertyName("onFulfilled")] 
    public int OnFulfilled { get; set; }
}