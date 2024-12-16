using UnityEngine;

namespace GameControllers.LocationControllers.PartControllers
{
    [CreateAssetMenu(fileName = "PartPatternData", menuName = "Part pattern data/ Part")]
    public class PartPatternData : ScriptableObject
    {
        [SerializeField] private int _index;
        [SerializeField] private PartType _partType;
        [SerializeField] private GamaFieldData _blocksOnGameField = new();

        public int Index => _index;
        public PartType PartType => _partType;
        public GamaFieldData BlocksOnGameField => _blocksOnGameField;
    }
}
