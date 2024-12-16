using System;
using GameControllers.GameEntities.Properties;
using GameControllers.GameEntitiesPool;
using GameControllers.LocationControllers.PartControllers;
using UnityEngine;

namespace GameControllers.Factories
{
    public abstract class Factory<T> : MonoBehaviour 
        where T : MonoBehaviour, ICanInitialize<T>
    {
        [SerializeField] private T _gameEntity;
        [SerializeField] private Transform _parentTransform;
        private const int ballPreloadCount = 20;
        private PoolBase<T> _gameEntitiesPool;

        private void Awake()
        {
            _gameEntitiesPool = new PoolBase<T>(Preload, GetGameEntityAction, ReturnGameEntityAction, ballPreloadCount);
        }

        protected void GetGameEntity(Transform parent, int indexLocation, int amount)
        {
            var newGameEntity = _gameEntitiesPool.Get();
            newGameEntity.Init(parent, ReturnBall, indexLocation, amount);
        }

        private void ReturnBall(T ball) => _gameEntitiesPool.Return(ball);

        public T Preload()
        {
            var newGameEntity = 
                Instantiate(_gameEntity, new Vector3(200, 0, 0), Quaternion.identity, _parentTransform).GetComponent<T>();
            newGameEntity.transform.localPosition = Vector3.zero;
            return newGameEntity;
        } 

        public void GetGameEntityAction(T gameEntity)
        {
            gameEntity.gameObject.SetActive(true);
        }

        public void ReturnGameEntityAction(T gameEntity)
        {
            gameEntity.transform.SetParent(_parentTransform);
            gameEntity.gameObject.SetActive(false);
        } 
    }
}
