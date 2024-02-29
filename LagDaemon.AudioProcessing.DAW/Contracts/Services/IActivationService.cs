namespace LagDaemon.AudioProcessing.DAW.Contracts.Services;

public interface IActivationService
{
    Task ActivateAsync(object activationArgs);
}
