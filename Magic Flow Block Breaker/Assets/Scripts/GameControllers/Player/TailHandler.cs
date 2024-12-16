using System;
using System.Collections.Generic;
using DG.Tweening;
using GameControllers.GameEntities.BonusBalls;
using TMPro;
using UnityEngine;

namespace GameControllers.Player
{
    public class TailHandler : MonoBehaviour
    {
        [SerializeField] private TMP_Text _tailLenghtText;
        [SerializeField] private TailMovement _tailPrefab;
        [SerializeField] private Transform _parentTail;
        [SerializeField] private Transform _headTail;
        [SerializeField] private AudioSource _increaseTailSound;
        [SerializeField] private AudioSource _decreaseTailSound;
        private readonly Color _tailTextStandardColor = new (0.7254902f, 0.2705882f, 0.509804f);
        private readonly Vector3 _startScaleTail = new (0.3f, 0.3f, 0.3f);
        private readonly Stack<TailMovement> _tailStack = new ();
        private Transform _previousHead;
        private const float OffsetNewTailY = -0.5f;
        private const float ColorChangeDuration = 0.5f;
        private const float ScaleChangeDuration = 1f;

        public static Action OnShowGameOver;
        
        public void IncreaseTail(BonusBallInitializer bonusBall, int amountBalls)
        {
            _increaseTailSound.Play();
            
            DOTween.Sequence()
                .Append(_tailLenghtText.DOColor(Color.green, ColorChangeDuration))
                .Append(_tailLenghtText.DOColor(_tailTextStandardColor, ColorChangeDuration));
            
            bonusBall.PlayerTakeBonus();

            for (var i = 0; i < amountBalls; i++)
            {
                var newBonusBall = Instantiate(_tailPrefab, _parentTail);
                newBonusBall.transform.localPosition = new Vector3(0, OffsetNewTailY * (_tailStack.Count + 1), 0);

                DOTween.Sequence()
                    .Append(newBonusBall.transform.DOScale(_startScaleTail, ScaleChangeDuration));

                newBonusBall.Init(_tailStack.Count > 0 ? _previousHead : _headTail, bonusBall.CurrentSprite);

                _previousHead = newBonusBall.transform;
            
                _tailStack.Push(newBonusBall);
            }

            UpdateTailLenghtText();
        }

        public void DecreaseTail(int decreaseValue)
        {
            _decreaseTailSound.Play();
            
            DOTween.Sequence()
                .Append(_tailLenghtText.DOColor(Color.red, ColorChangeDuration))
                .Append(_tailLenghtText.DOColor(_tailTextStandardColor, ColorChangeDuration));
            
            if (decreaseValue > _tailStack.Count)
            {
                UnhookTail(_tailStack.Count);
                UpdateTailLenghtText();
                OnShowGameOver.Invoke();
                return;
            }
            
            UnhookTail(decreaseValue);

            if (_tailStack.Count > 0)
            {
                var lastBall = _tailStack.Pop();
                _previousHead = lastBall.transform;
                _tailStack.Push(lastBall);
            }
            else
            {
                _previousHead = _headTail;
            }

            UpdateTailLenghtText();
        }

        private void UnhookTail(int decreaseValue)
        {
            for (var i = 0; i < decreaseValue; i++)
            {
                var bonusBall = _tailStack.Pop();
                bonusBall.StartDestroy();
            }
        }


        private void UpdateTailLenghtText()
        {
            _tailLenghtText.text = _tailStack.Count.ToString();
        }
    }
}
