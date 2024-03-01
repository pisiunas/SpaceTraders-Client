using System.Text.Json.Serialization;
using SpaceTraders.Infrastructure.Modules.Contracts;

namespace SpaceTraders.Infrastructure.Modules.Authentication.UserInformation;

public class ContractData
{
    [JsonPropertyName("id")] 
    public string Id { get; set; }

    [JsonPropertyName("factionSymbol")] 
    public string FactionSymbol { get; set; }

    [JsonPropertyName("type")] 
    public string Type { get; set; }

    [JsonPropertyName("terms")]
    public ContractTermsData TermsData { get; set; }

    [JsonPropertyName("accepted")] 
    public bool IsAccepted { get; set; }

    [JsonPropertyName("fulfilled")] 
    public bool IsFulfilled { get; set; }

    [JsonPropertyName("expiration")] 
    public string Expiration { get; set; }
    
    [JsonPropertyName("deadlineToAccept")] 
    public string DeadlineToAccept { get; set; }
}