using System;
using DG.Tweening;
using GameControllers.GameLogic;
using GameControllers.LocationControllers;
using LevelsControllers;
using SceneLoaderControllers;
using UnityEngine;

namespace GameControllers
{
    public class GameStartUp : MonoBehaviour
    {
        [SerializeField] private LocationGenerator _locationGenerator;
        [SerializeField] private LocationInitializer _startLocation;
        [SerializeField] private ProgressPlayerHandler _progressPlayerHandler;
        [SerializeField] private Transform _playerTransform;
        private const float StartGameDelay = 2.5f;

        public static Action<bool> OnChangeStateMoveLocation;
        
        private void OnEnable()
        {
            SceneDataLoader.OnLevelLoaded += StartUp;
        }

        private void OnDisable()
        {
            SceneDataLoader.OnLevelLoaded -= StartUp;
        }

        private void StartUp(LevelData levelData)
        {
            OnChangeStateMoveLocation.Invoke(false);
            StartPlayerAnimation();
            _progressPlayerHandler.Init(levelData.ProgressSpeedMultiplier, levelData.Index, StartGameDelay);
            _startLocation.Init(0, levelData.SpeedLocation, levelData.BlockQuantityMultiplier);
            _locationGenerator.InitializeLocationsSettings(levelData.SpeedLocation, levelData.BlockQuantityMultiplier);
        }

        private void StartPlayerAnimation()
        {
            DOTween.Sequence()
                .Append(_playerTransform.DOMove(new Vector3(0f, -2f, 0f), StartGameDelay))
                .AppendCallback(() => OnChangeStateMoveLocation.Invoke(true));
        }
    }
}
