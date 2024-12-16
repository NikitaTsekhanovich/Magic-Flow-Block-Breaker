using System;
using System.Collections;
using GameControllers.GameEntities.Properties;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace GameControllers.GameEntities.Blocks
{
    public class BlockInitializer : GameEntity, ICanInitialize<BlockInitializer>
    {
        [SerializeField] private Image _icon;
        [SerializeField] private BoxCollider2D _solidBoxCollider;
        [SerializeField] private BoxCollider2D _triggerBoxCollider;
        [SerializeField] private RectTransform _rectTransform;
        [SerializeField] private TMP_Text _amountText;
        private Action<BlockInitializer> _returnAction;
        protected override int indexLocation { get; set; }
        
        public static Func<SpritesSettings> OnGetSprite;
        public int Amount { get; private set; }

        public void Init(Transform parent, Action<BlockInitializer> returnAction, int indexLocation, int amount)
        {
            this.indexLocation = indexLocation;
            _returnAction = returnAction;
            var spritesSettings = OnGetSprite.Invoke();
            _icon.sprite = spritesSettings.Sprite;
            _amountText.color = spritesSettings.ColorText;
                
            transform.SetParent(parent);
            UpdateAmountText(amount);
            StartCoroutine(WaitEndFrame());
        }

        private void UpdateAmountText(int amount)
        {
            Amount = amount;
            _amountText.text = $"{amount}";
        }

        private IEnumerator WaitEndFrame()
        {
            yield return new WaitForEndOfFrame();
            _solidBoxCollider.size = _rectTransform.rect.size;
            _triggerBoxCollider.size = new Vector2(_rectTransform.rect.size.x, 2);
            _triggerBoxCollider.offset = new Vector2(0, _rectTransform.rect.position.y);
        }

        public void DestroyedByPlayer()
        {
            _returnAction.Invoke(this);
        }

        protected override void ReturnGameEntity(int indexLocation)
        {
            if (this.indexLocation != indexLocation) return;
            _returnAction.Invoke(this);
        }
    }
}
