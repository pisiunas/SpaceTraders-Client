using System.Text.Json.Serialization;

namespace SpaceTraders.Infrastructure.Modules.Responses.SystemsInformation;

public class SystemsResponse
{
    [JsonPropertyName("data")]
    public List<SystemInfo> Systems { get; set; }

    [JsonPropertyName("meta")]
    public MetaInfo Meta { get; set; }
}

public class SystemInfo
{
    [JsonPropertyName("symbol")]
    public string Symbol { get; set; }

    [JsonPropertyName("sectorSymbol")]
    public string SectorSymbol { get; set; }

    [JsonPropertyName("type")]
    public string Type { get; set; }

    [JsonPropertyName("x")]
    public int X { get; set; }

    [JsonPropertyName("y")]
    public int Y { get; set; }

    [JsonPropertyName("waypoints")]
    public List<WaypointInfo> Waypoints { get; set; }

    [JsonPropertyName("factions")]
    public List<FactionInfo> Factions { get; set; }
}

public class WaypointInfo
{
    [JsonPropertyName("symbol")]
    public string Symbol { get; set; }

    [JsonPropertyName("type")]
    public string Type { get; set; }

    [JsonPropertyName("x")]
    public int X { get; set; }

    [JsonPropertyName("y")]
    public int Y { get; set; }

    [JsonPropertyName("orbitals")]
    public List<OrbitalInfo> Orbitals { get; set; }

    [JsonPropertyName("orbits")]
    public string Orbits { get; set; }
}

public class OrbitalInfo
{
    [JsonPropertyName("symbol")]
    public string Symbol { get; set; }
}

public class FactionInfo
{
    [JsonPropertyName("symbol")]
    public string Symbol { get; set; }
}

public class MetaInfo
{
    [JsonPropertyName("total")]
    public int Total { get; set; }

    [JsonPropertyName("page")]
    public int Page { get; set; }

    [JsonPropertyName("limit")]
    public int Limit { get; set; }
}
