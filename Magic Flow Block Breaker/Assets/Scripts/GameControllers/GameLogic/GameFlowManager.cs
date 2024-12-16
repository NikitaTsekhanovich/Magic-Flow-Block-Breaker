using System;
using SceneLoaderControllers;
using UnityEngine;
using DG.Tweening;

namespace GameControllers.GameLogic
{
    public class GameFlowManager : MonoBehaviour
    {
        [SerializeField] private GameObject _pauseScreen;

        public static Action<bool> OnChangeStateGame;

        public void PauseGame()
        {
            OnChangeStateGame.Invoke(true);
            _pauseScreen.SetActive(true);
            
            _pauseScreen.transform.DOScale(Vector3.one, 0.5f);
        }

        public void ContinueGame()
        {
            OnChangeStateGame.Invoke(false);
            
            DOTween.Sequence()
                .Append(_pauseScreen.transform.DOScale(Vector3.zero, 0.5f))
                .AppendCallback(() => _pauseScreen.SetActive(false));
        }

        public void RestartGame()
        {
            LoadingScreenController.Instance.ChangeScene("Game");
        }

        public void BackToMainMenu()
        {
            LoadingScreenController.Instance.ChangeScene("MainMenu");
        }
    }
}
