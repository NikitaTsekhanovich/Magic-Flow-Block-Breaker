using System;
using GameControllers.GameEntities.Properties;
using UnityEngine;

namespace GameControllers.GameEntities.Blocks
{
    public class EmptyBlockInitializer : GameEntity, ICanInitialize<EmptyBlockInitializer>
    {
        private Action<EmptyBlockInitializer> _returnAction;
        protected override int indexLocation { get; set; }

        public void Init(Transform parent, Action<EmptyBlockInitializer> returnAction, int indexLocation, int amount)
        {
            this.indexLocation = indexLocation;
            _returnAction = returnAction;
            transform.SetParent(parent);
        }
        
        protected override void ReturnGameEntity(int indexLocation)
        {
            if (this.indexLocation != indexLocation) return;
            _returnAction.Invoke(this);
        }
    }
}
