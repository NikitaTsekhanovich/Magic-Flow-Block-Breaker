using System;
using System.Collections;
using LevelsControllers;
using UnityEngine;
using UnityEngine.UI;

namespace GameControllers.GameLogic
{
    public class ProgressPlayerHandler : MonoBehaviour
    {
        [SerializeField] private Image _firstStarImage;
        [SerializeField] private Image _secondStarImage;
        [SerializeField] private Image _thirdStarImage;
        [SerializeField] private Image _firstStarEndGameImage;
        [SerializeField] private Image _secondStarEndGameImage;
        [SerializeField] private Image _thirdStarEndGameImage;
        [SerializeField] private Image _progressBar;
        [SerializeField] private AudioSource _getStarSound;
        private float _progressValue;
        private float _speedMultiplier;
        private int _indexLevel;
        private bool _firstStarOpen;
        private bool _secondStarOpen;
        private bool _thirdStarOpen;
        private bool _gameIsStarted;

        private void OnEnable()
        {
            GameOverDisplay.OnGetStateFirstStar += GetStateFirstStar;
        }

        private void OnDestroy()
        {
            GameOverDisplay.OnGetStateFirstStar -= GetStateFirstStar;
        }
        
        private bool GetStateFirstStar() => _firstStarOpen;

        public void Init(float speedMultiplier, int indexLevel, float startGameDelay)
        {
            _speedMultiplier = speedMultiplier;
            _indexLevel = indexLevel;
            StartCoroutine(WaitStartGameDelay(startGameDelay));
        }

        private IEnumerator WaitStartGameDelay(float startGameDelay)
        {
            yield return new WaitForSeconds(startGameDelay);
            _gameIsStarted = true;
        }

        private void Update()
        {
            if (GameOverDisplay.IsGameOver || !_gameIsStarted) return;
            
            UpdateProgressBar();
        }

        private void UpdateProgressBar()
        {
            _progressValue += Time.deltaTime * _speedMultiplier;
            var progressValueBar = _progressValue / 100f;
            _progressBar.fillAmount = progressValueBar;

            SetProgressStars(progressValueBar);
        }

        private void SetProgressStars(float progressValueBar)
        {
            if (progressValueBar >= 1f && !_thirdStarOpen)
            {
                _getStarSound.Play();
                _thirdStarOpen = true;
                _thirdStarEndGameImage.enabled = true;
                _thirdStarImage.enabled = true;
                SetStarsData(LevelDataKeys.ThirdStarOpenKey);
            }   
            if (progressValueBar >= 1f / 1.5f && !_secondStarOpen)
            {
                _getStarSound.Play();
                _secondStarOpen = true;
                _secondStarEndGameImage.enabled = true;
                _secondStarImage.enabled = true;
                SetStarsData(LevelDataKeys.SecondStarOpenKey);
            }
            if (progressValueBar >= 1f / 3f && !_firstStarOpen)
            {
                _getStarSound.Play();
                _firstStarOpen = true;
                _firstStarEndGameImage.enabled = true;
                _firstStarImage.enabled = true;
                SetStarsData(LevelDataKeys.FirstStarOpenKey);
            }
        }
        
        private void SetStarsData(string starOpenKey)
        {
            // _soundsContainer.GetStarSound.Play();

            if (PlayerPrefs.GetInt($"{starOpenKey}{_indexLevel}") == (int)TypeStateObject.IsClosed)
            {
                var amountStars = PlayerPrefs.GetInt(LevelDataKeys.AmountStarsKey);
                PlayerPrefs.SetInt(LevelDataKeys.AmountStarsKey, amountStars + 1);
                PlayerPrefs.SetInt($"{starOpenKey}{_indexLevel}", (int)TypeStateObject.IsOpen);
            }
        }
    }
}
