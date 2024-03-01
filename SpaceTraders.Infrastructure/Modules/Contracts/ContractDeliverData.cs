using System.Text.Json.Serialization;

namespace SpaceTraders.Infrastructure.Modules.Contracts;

public class ContractDeliverData
{
    [JsonPropertyName("tradeSymbol")] 
    public string GoodToDeliver { get; set; }

    [JsonPropertyName("destinationSymbol")] 
    public string Destination { get; set; }
    
    [JsonPropertyName("unitsRequired")] 
    public int UnitsRequired { get; set; }

    [JsonPropertyName("unitsFulfilled")] 
    public int UnitsFulfilled { get; set; }
}