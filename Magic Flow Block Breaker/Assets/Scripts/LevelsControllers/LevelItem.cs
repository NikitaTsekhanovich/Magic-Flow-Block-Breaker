using System;
using SceneLoaderControllers;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace LevelsControllers
{
    public class LevelItem : MonoBehaviour
    {
        [SerializeField] private int _index;
        [SerializeField] private GameObject _openBlock;
        [SerializeField] private GameObject _lockBlock;
        [SerializeField] private TMP_Text _moreStarsText;
        [SerializeField] private Button _playButton;
        [SerializeField] private Image[] _starsImages;

        public static Action<LevelData> OnStashLevelData;

        public void UpdateLevelItemData()
        {
            var stateLevel = LevelDataContainer.LevelsData[_index].TypeStateLevel;
            UpdateStarsStats();

            if (stateLevel == TypeStateObject.IsOpen)
            {
                _openBlock.SetActive(true);
                _lockBlock.SetActive(false);
            }
            else 
            {
                _openBlock.SetActive(false);
                _lockBlock.SetActive(true);
                _playButton.interactable = false;

                _moreStarsText.text =
                    $"To open you need {LevelDataContainer.LevelsData[_index].StarsToOpenLevel - PlayerPrefs.GetInt(LevelDataKeys.AmountStarsKey)} stars";
            }
        }

        private void UpdateStarsStats()
        {
            if (LevelDataContainer.LevelsData[_index].TypeStateFirstStar == TypeStateObject.IsOpen)
            {
                _starsImages[0].enabled = true;
            }
            if (LevelDataContainer.LevelsData[_index].TypeStateSecondStar == TypeStateObject.IsOpen)
            {
                _starsImages[1].enabled = true;
            }
            if (LevelDataContainer.LevelsData[_index].TypeStateThirdStar == TypeStateObject.IsOpen)
            {
                _starsImages[2].enabled = true;
            }
        }

        public void PlayGame()
        {
            OnStashLevelData.Invoke(LevelDataContainer.LevelsData[_index]);
            LoadingScreenController.Instance.ChangeScene("Game");
        }
    }
}
