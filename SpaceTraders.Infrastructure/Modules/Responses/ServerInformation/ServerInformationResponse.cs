using System.Text.Json.Serialization;

namespace SpaceTraders.Infrastructure.Modules.Responses.ServerInformation;

public class ServerInformationResponse
{
    [JsonPropertyName("status")]
    public string Status { get; set; }

    [JsonPropertyName("version")]
    public string Version { get; set; }

    [JsonPropertyName("resetDate")]
    public string ResetDate { get; set; }

    [JsonPropertyName("description")]
    public string Description { get; set; }

    [JsonPropertyName("stats")]
    public ServerInformationStats StatsList { get; set; }

    [JsonPropertyName("leaderboards")]
    public LeaderboardEntry Leaderboard { get; set; }

    [JsonPropertyName("serverResets")]
    public ServerResetInfo ServerResets { get; set; }

    [JsonPropertyName("announcements")]
    public List<Announcement> Announcements { get; set; }

    [JsonPropertyName("links")]
    public List<LinkInfo> Links { get; set; }
}

public class ServerInformationStats
{
    [JsonPropertyName("agents")]
    public int Agents { get; set; }

    [JsonPropertyName("ships")]
    public int Ships { get; set; }

    [JsonPropertyName("systems")]
    public int Systems { get; set; }

    [JsonPropertyName("waypoints")]
    public int Waypoints { get; set; }
}

public class LeaderboardEntry
{
    [JsonPropertyName("mostCredits")]
    public List<MostCredits> MostCredits { get; set; }

    [JsonPropertyName("mostSubmittedCharts")]
    public List<MostSubmittedCharts> MostSubmittedCharts { get; set; }
}

public class MostCredits
{
    [JsonPropertyName("agentSymbol")]
    public string AgentSymbol { get; set; }

    [JsonPropertyName("credits")]
    public int Credits { get; set; }
}

public class MostSubmittedCharts
{
    [JsonPropertyName("agentSymbol")]
    public string AgentSymbol { get; set; }

    [JsonPropertyName("chartCount")]
    public int ChartCount { get; set; }
}

public class ServerResetInfo
{
    [JsonPropertyName("next")]
    public string Next { get; set; }

    [JsonPropertyName("frequency")]
    public string Frequency { get; set; }
}

public class Announcement
{
    [JsonPropertyName("title")]
    public string Title { get; set; }

    [JsonPropertyName("body")]
    public string Body { get; set; }
}

public class LinkInfo
{
    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("url")]
    public string Url { get; set; }
}
