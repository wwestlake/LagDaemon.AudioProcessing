using System.Collections.Specialized;

namespace LagDaemon.AudioProcessing.DAW.Contracts.Services;

public interface IAppNotificationService
{
    void Initialize();

    bool Show(string payload);

    NameValueCollection ParseArguments(string arguments);

    void Unregister();
}
