using Assets.Scripts.Infrastructure.Services;
using Assets.Scripts.Logic;
using Assets.Scripts.StaticData;
using Assets.Scripts.StaticData.Windows;
using Assets.Scripts.UI.Services.Windows;

namespace Assets.Scripts.Services
{
    public interface IStaticDataService : IService
    {
        LevelStaticData ForLevel(string sceneKey);
        MonsterStaticData ForMonster(MonsterTypeId monsterTypeId);
        WindowConfig ForWindow(WindowId shop);
        void Load();
    }
 }