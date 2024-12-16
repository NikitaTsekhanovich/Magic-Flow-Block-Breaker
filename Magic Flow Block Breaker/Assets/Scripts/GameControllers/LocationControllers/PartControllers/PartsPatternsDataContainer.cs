using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace GameControllers.LocationControllers.PartControllers
{
    public static class PartsPatternsDataContainer
    {
        public static readonly Dictionary<PartType, List<PartPatternData>> DictPartsPatternsData = new ();
        
        private static List<PartPatternData> _partsPatternsData = new ();
        private static bool _loaded;

        public static void LoadLevelData()
        {
            if (_loaded) return;
            _loaded = true;
            
            _partsPatternsData = Resources.LoadAll<PartPatternData>("ScriptableObjectData/PartsPatternData")
                .OrderBy(x => x.Index)
                .ToList();

            foreach (var partPatternData in _partsPatternsData)
            {
                if (!DictPartsPatternsData.ContainsKey(partPatternData.PartType))
                    DictPartsPatternsData[partPatternData.PartType] = new List<PartPatternData> { partPatternData };
                else
                    DictPartsPatternsData[partPatternData.PartType].Add(partPatternData);
            }
        }
    }
}
