using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Logic;
using Assets.Scripts.Services;
using Assets.Scripts.StaticData.Windows;
using Assets.Scripts.UI.Services.Windows;
using UnityEngine;

namespace Assets.Scripts.StaticData
{
    public class StaticDataService : IStaticDataService
    {
        private const string StaticDataMonstersPath = "StaticData/Monsters";
        private const string StaticDataLevelsPath = "StaticData/Levels";
        private const string StaticDataWindowsPath = "StaticData/UI/WindowStaticData";
        private Dictionary<MonsterTypeId, MonsterStaticData> _monsters;
        private Dictionary<string, LevelStaticData> _levels;
        private Dictionary<WindowId, WindowConfig> _windowConfigs; 

        public void Load()
        {
            _monsters = Resources.LoadAll<MonsterStaticData>(StaticDataMonstersPath)
                .ToDictionary(x => x.MonsterTypeId, x => x);

            _levels = Resources.LoadAll<LevelStaticData>(StaticDataLevelsPath)
                .ToDictionary(x => x.LevelKey, x => x);

            _windowConfigs = Resources.Load<WindowStaticData>(StaticDataWindowsPath)
                .Configs
                .ToDictionary(x => x.WindowId, x => x);
        }

        public MonsterStaticData ForMonster(MonsterTypeId monsterTypeId) =>
             _monsters.TryGetValue(monsterTypeId, out MonsterStaticData monsterStaticData) ? monsterStaticData : null;

        public LevelStaticData ForLevel(string sceneKey) =>
             _levels.TryGetValue(sceneKey, out LevelStaticData levelStaticData) ? levelStaticData : null;

        public WindowConfig ForWindow(WindowId windowId) =>
            _windowConfigs.TryGetValue(windowId, out WindowConfig windowConfig) ? windowConfig : null;
    }
}