using System;
using UnityEngine;

namespace GameControllers.GameEntities.Properties
{
    public interface ICanInitialize<T>
    {
        public void Init(Transform parent, Action<T> returnAction, int indexLocation, int amount);
    }
}
