using Assets.Scripts.Data;
using Assets.Scripts.Infrastructure.Services;

namespace Assets.Scripts.Services.SaveLoad
{
    public interface ISaveLoadService : IService
    {
        void SaveProgress();
        PlayerProgress LoadProgress();
    }
}