using Assets.Scripts.Data;
using Assets.Scripts.Infrastructure.Services;

namespace Assets.Scripts.Services.PersistentProgress
{
    public interface IPersistentProgressService: IService
    {
        PlayerProgress Progress { get; set; }
    }
}