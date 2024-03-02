using System.Text.Json.Serialization;

namespace SpaceTraders.Infrastructure.Modules.Responses.SystemsInformation;

public class GetSystemResponse
{
    [JsonPropertyName("data")] 
    public SystemData Data { get; set; }
}

public class SystemData
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
    public List<Waypoint> Waypoints { get; set; }

    [JsonPropertyName("factions")] 
    public List<Faction> Factions { get; set; }
}

public class Waypoint
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
    public List<Orbital> Orbitals { get; set; }

    [JsonPropertyName("orbits")] 
    public string Orbits { get; set; }
}

public class Orbital
{
    [JsonPropertyName("symbol")] 
    public string Symbol { get; set; }
}

public class Faction
{
    [JsonPropertyName("symbol")] 
    public string Symbol { get; set; }
}
