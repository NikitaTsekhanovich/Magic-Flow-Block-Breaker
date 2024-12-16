using System;
using GameControllers.Canvas;
using GameControllers.GameLogic;
using UnityEngine;

namespace GameControllers.LocationControllers
{
    public class LocationMovement : MonoBehaviour
    {
        [SerializeField] private LocationInitializer _locationInitializer;
        private float _speed;
        private bool _isReachedBottom;
        private float _spawnBorderNewLocation;
        private float _destroyBorderLocation;
        private bool _isCanMove = true;

        public static Action OnReachedBottom;

        private void OnEnable()
        {
            GameStartUp.OnChangeStateMoveLocation += ChangeMoveState;
        }

        private void OnDestroy()
        {
            GameStartUp.OnChangeStateMoveLocation -= ChangeMoveState;
        }

        private void ChangeMoveState(bool isCanMove)
        {
            _isCanMove = isCanMove;
        }

        public void Init(float speed)
        {
            _speed = speed;
            _spawnBorderNewLocation = 0 - transform.localPosition.y + 50f;
            _destroyBorderLocation = _spawnBorderNewLocation - CanvasSettings.Instance.HeightCanvas;
        }

        private void Update()
        {
            if (GameOverDisplay.IsGameOver) return;
            
            CheckSpawnBorder();
            CheckDestroyBorder();
            Movement();
        }

        private void Movement()
        {
            if (_isCanMove)
                transform.position += Vector3.down * Time.deltaTime * _speed;
        }

        private void CheckDestroyBorder()
        {
            if (transform.localPosition.y <= _destroyBorderLocation)
                _locationInitializer.DestroyLocation();
        }

        private void CheckSpawnBorder()
        {
            if (transform.localPosition.y <= _spawnBorderNewLocation && !_isReachedBottom)
            {
                _isReachedBottom = true;
                OnReachedBottom.Invoke();
            }
        }
    }
}
