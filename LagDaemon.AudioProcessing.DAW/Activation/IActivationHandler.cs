namespace LagDaemon.AudioProcessing.DAW.Activation;

public interface IActivationHandler
{
    bool CanHandle(object args);

    Task HandleAsync(object args);
}
