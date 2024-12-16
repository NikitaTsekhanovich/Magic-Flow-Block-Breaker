using System;
using GameControllers.LocationControllers;
using UnityEngine;

namespace GameControllers.GameEntities
{
    public abstract class GameEntity : MonoBehaviour
    {
        protected abstract int indexLocation { get; set; }

        private void OnEnable()
        {
            LocationInitializer.OnReturnGameEntities += ReturnGameEntity;
        }

        private void OnDisable()
        {
            LocationInitializer.OnReturnGameEntities -= ReturnGameEntity;
        }

        protected virtual void ReturnGameEntity(int indexLocation)
        {
            
        }
    }
}
