using System.Collections.Generic;
using UnityEngine;

namespace LevelsControllers
{
    [CreateAssetMenu(fileName = "LevelData", menuName = "Levels data/ Level")]
    public class LevelData : ScriptableObject
    {
        [Header("Level info")]
        [SerializeField] private int _index;
        [SerializeField] private int _starsToOpenLevel;

        [Header("Settings game entities info")] 
        [SerializeField] private float _speedLocation;
        [SerializeField] private float _blockQuantityMultiplier;
        [SerializeField] private float _progressSpeedMultiplier;

        public int Index => _index;
        public int StarsToOpenLevel => _starsToOpenLevel;  
        public float SpeedLocation => _speedLocation;
        public float BlockQuantityMultiplier => _blockQuantityMultiplier;
        public float ProgressSpeedMultiplier => _progressSpeedMultiplier;
        
        public TypeStateObject TypeStateLevel 
        {
            get
            {
                if (_starsToOpenLevel - PlayerPrefs.GetInt(LevelDataKeys.AmountStarsKey) <= 0)
                    return TypeStateObject.IsOpen;

                return PlayerPrefs.GetInt($"{LevelDataKeys.LevelOpenKey}{_index}") == (int)TypeStateObject.IsClosed ? 
                    TypeStateObject.IsClosed : TypeStateObject.IsOpen;
            }
        }
        public TypeStateObject TypeStateFirstStar =>
            PlayerPrefs.GetInt($"{LevelDataKeys.FirstStarOpenKey}{_index}") == (int)TypeStateObject.IsClosed ? 
                TypeStateObject.IsClosed : TypeStateObject.IsOpen;

        public TypeStateObject TypeStateSecondStar =>
            PlayerPrefs.GetInt($"{LevelDataKeys.SecondStarOpenKey}{_index}") == (int)TypeStateObject.IsClosed ? 
                TypeStateObject.IsClosed : TypeStateObject.IsOpen;

        public TypeStateObject TypeStateThirdStar =>
            PlayerPrefs.GetInt($"{LevelDataKeys.ThirdStarOpenKey}{_index}") == (int)TypeStateObject.IsClosed ? 
                TypeStateObject.IsClosed : TypeStateObject.IsOpen;
    }
}
