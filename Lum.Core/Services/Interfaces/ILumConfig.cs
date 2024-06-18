namespace Lum.Core.Services.Interfaces;

public interface ILumConfig
{
    string ChatModel { get; }
    string OpenIaToken { get; }
}