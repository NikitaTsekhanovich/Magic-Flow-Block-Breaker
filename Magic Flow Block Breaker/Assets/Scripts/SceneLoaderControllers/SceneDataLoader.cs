using System;
using GameControllers.LocationControllers.PartControllers;
using LevelsControllers;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SceneLoaderControllers
{
    public class SceneDataLoader : MonoBehaviour
    {
        private LevelData _levelData;
        
        public static Action<LevelData> OnLevelLoaded;
        public static Action OnLoadLevelsData;
        public static Action OnLoadTheme;
        public static SceneDataLoader Instance;

        private void OnEnable()
        {
            SceneManager.sceneLoaded += OnSceneLoaded;
            LevelItem.OnStashLevelData += StashLevelData;
        }

        private void OnDisable()
        {
            SceneManager.sceneLoaded -= OnSceneLoaded;
            LevelItem.OnStashLevelData -= StashLevelData;
        }

        private void Start() 
        {        
            if (Instance == null) 
                Instance = this; 
            else 
                Destroy(this);  
        }

        private void StashLevelData(LevelData levelData)
        {
            _levelData = levelData;
        }

        private void OnSceneLoaded(Scene scene, LoadSceneMode loadSceneMode)
        {
            if (scene.name == "MainMenu")
            {
                OnLoadTheme.Invoke();
                LevelDataContainer.LoadLevelData();
                OnLoadLevelsData.Invoke();
            }
            else if (scene.name == "Game")
            {
                OnLoadTheme.Invoke();
                PartsPatternsDataContainer.LoadLevelData();
                OnLevelLoaded.Invoke(_levelData);
            }
        }
    }
}
