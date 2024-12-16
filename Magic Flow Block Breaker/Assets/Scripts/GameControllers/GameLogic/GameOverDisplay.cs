using System;
using DG.Tweening;
using GameControllers.Player;
using UnityEngine;

namespace GameControllers.GameLogic
{
    public class GameOverDisplay : MonoBehaviour
    {
        [SerializeField] private GameObject _gameOverDisplay;
        [SerializeField] private GameObject _gameOverTitle;
        [SerializeField] private GameObject _levelCompletedBlock;
        [SerializeField] private AudioSource _gameOverSound;
        [SerializeField] private AudioSource _winGameSound;

        public static bool IsGameOver { get; private set; }
        public static Func<bool> OnGetStateFirstStar;

        private void Start()
        {
            IsGameOver = false;
        }

        private void OnEnable()
        {
            TailHandler.OnShowGameOver += ShowGameOver;
            GameFlowManager.OnChangeStateGame += ChangeStateGame;
        }

        private void OnDisable()
        {
            TailHandler.OnShowGameOver -= ShowGameOver;
            GameFlowManager.OnChangeStateGame -= ChangeStateGame;
        }

        private void ChangeStateGame(bool state)
        {
            IsGameOver = state;
        }

        private void ShowGameOver()
        {
            IsGameOver = true;
            _gameOverDisplay.SetActive(true);
            _gameOverDisplay.transform.DOScale(Vector3.one, 0.5f);

            if (OnGetStateFirstStar.Invoke())
            {
                _gameOverTitle.SetActive(false);
                _levelCompletedBlock.SetActive(true);
                _winGameSound.Play();
            }
            else
            {
                _gameOverTitle.SetActive(true);
                _levelCompletedBlock.SetActive(false);
                _gameOverSound.Play();
            }
        }
    }
}
