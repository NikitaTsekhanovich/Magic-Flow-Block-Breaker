using System;
using System.Collections;
using GameControllers.GameEntities.Properties;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace GameControllers.GameEntities.BonusBalls
{
    public class BonusBallInitializer : GameEntity, ICanInitialize<BonusBallInitializer>
    {
        [SerializeField] private Image _iconBall;
        [SerializeField] private BoxCollider2D _boxCollider;
        [SerializeField] private RectTransform _rectTransform;
        [SerializeField] private TMP_Text _amountText;
        private Action<BonusBallInitializer> _returnAction;
        protected override int indexLocation { get; set; }

        public int Amount { get; private set; }
        public Sprite CurrentSprite { get; private set; }
        public static Func<SpritesSettings> OnGetSprite;

        public void Init(Transform parent, Action<BonusBallInitializer> returnAction, int indexLocation, int amount)
        {
            Amount = amount;
            _amountText.text = Amount.ToString();
            var spriteSettings = OnGetSprite.Invoke();
            CurrentSprite = spriteSettings.Sprite;
            _amountText.color = spriteSettings.ColorText;
            _iconBall.sprite = CurrentSprite;
                
            this.indexLocation = indexLocation;
            _returnAction = returnAction;
            transform.SetParent(parent);
            StartCoroutine(InitPosition());
        }
        
        private IEnumerator InitPosition()
        {
            yield return new WaitForEndOfFrame();
            _boxCollider.size = _rectTransform.rect.size;
        }

        public void PlayerTakeBonus()
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
