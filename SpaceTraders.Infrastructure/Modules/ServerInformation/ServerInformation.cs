namespace SpaceTraders.Infrastructure.Modules.ServerInformation;

public sealed record ServerInformation(string Status, string Version, string ResetDate, string Description, int Agents, int Ships, int Systems, int Waypoints)
{
    public string Status { get; set; } = Status;
    public string Version { get; set; } = Version;
    public string ResetDate { get; set; } = ResetDate;
    public string Description { get; set; } = Description;
    public int Agents { get; set; } = Agents;
    public int Ships { get; set; } = Ships;
    public int Systems { get; set; } = Systems;
    public int Waypoints { get; set; } = Waypoints;
}