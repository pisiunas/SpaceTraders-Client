using System.Text.Json.Serialization;

namespace SpaceTraders.Infrastructure.Api.Models.Systems;

public sealed record SystemsRequest(int Limit, int Page)
{
    [JsonPropertyName("limit")]
    public int Limit { get; set; } = Limit;
    
    [JsonPropertyName("page")]
    public int Page { get; set; } = Page;
}
