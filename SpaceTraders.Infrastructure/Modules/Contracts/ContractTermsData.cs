using System.Text.Json.Serialization;

namespace SpaceTraders.Infrastructure.Modules.Contracts;

public class ContractTermsData
{
    [JsonPropertyName("deadline")] 
    public string Deadline { get; set; }

    [JsonPropertyName("payment")] 
    public ContractPaymentData PaymentData { get; set; }
    
    // [JsonPropertyName("deliver")] 
    // public ContractDeliverData DeliverData { get; set; }
}