using System;
using System.Collections;
using GameControllers.GameEntities.Properties;
using UnityEngine;

namespace GameControllers.GameEntities.Lines
{
    public class LineInitializer : GameEntity, ICanInitialize<LineInitializer>
    {
        [SerializeField] private BoxCollider2D _boxCollider;
        [SerializeField] private RectTransform _rectTransform;
        private Action<LineInitializer> _returnAction;
        protected override int indexLocation { get; set; }

        public void Init(Transform parent, Action<LineInitializer> returnAction, int indexLocation, int amount)
        {
            this.indexLocation = indexLocation;
            _returnAction = returnAction;
            transform.SetParent(parent);
            StartCoroutine(WaitEndFrame());
        }
        
        private IEnumerator WaitEndFrame()
        {
            yield return new WaitForEndOfFrame();
            _boxCollider.size = _rectTransform.rect.size;
            _boxCollider.offset = new Vector2(_rectTransform.localPosition.x, 0);
        }
        
        protected override void ReturnGameEntity(int indexLocation)
        {
            if (this.indexLocation != indexLocation) return;
            _returnAction.Invoke(this);
        }
    }
}
