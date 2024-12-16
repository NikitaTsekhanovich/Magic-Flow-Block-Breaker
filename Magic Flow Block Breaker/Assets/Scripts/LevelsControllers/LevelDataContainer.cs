using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace LevelsControllers
{
    public static class LevelDataContainer
    {
        public static List<LevelData> LevelsData { get; private set; }

        public static void LoadLevelData()
        {
            LevelsData = Resources.LoadAll<LevelData>("ScriptableObjectData/LevelsData")
                .OrderBy(x => x.Index)
                .ToList();
        }

        public static LevelData GetCurrentLevel(int index)
        {
            return LevelsData[index];
        }

        public static int GetAmountLevelsData()
        {
            return LevelsData.Count;
        }
    }
}