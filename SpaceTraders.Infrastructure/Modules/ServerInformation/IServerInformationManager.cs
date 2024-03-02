using SpaceTraders.Infrastructure.Modules.Responses.ServerInformation;

namespace SpaceTraders.Infrastructure.Modules.ServerInformation;

public interface IServerInformationManager
{
    ServerInformationResponse GetServerInformation();
}