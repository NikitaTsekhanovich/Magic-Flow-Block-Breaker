using System;
using GameControllers.Canvas;
using GameControllers.LocationControllers.PartControllers;
using MainMenu.ThemeControllers;
using UnityEngine;
using UnityEngine.UI;

namespace GameControllers.LocationControllers
{
    public class LocationInitializer : MonoBehaviour
    {
        [SerializeField] private LocationMovement _locationMovement;
        [SerializeField] private RectTransform _rectTransform;
        [SerializeField] private bool _isFirstLocation;
        [SerializeField] private Part[] _parts;
        [SerializeField] private Image _backgroundImage;
        [SerializeField] private Sprite _blueBackground;
        private int _indexLocation;
        private float _blockQuantityMultiplier;
        
        public static Action<int> OnReturnGameEntities;

        public void Init(int indexLocation, float speedLocation, float blockQuantityMultiplier)
        {
            if (PlayerPrefs.GetInt(ThemeDataKeys.IsChosenClassicThemeKey) == 0)
                _backgroundImage.sprite = _blueBackground;
            
            _rectTransform.sizeDelta = new Vector2(
                CanvasSettings.Instance.WidthCanvas, 
                CanvasSettings.Instance.HeightLocation);
            
            transform.localPosition = new Vector3(
                0f, 
                CanvasSettings.Instance.StartPositionYLocation, 
                0f);
            
            _locationMovement.Init(speedLocation);
            _blockQuantityMultiplier = blockQuantityMultiplier;

            _indexLocation = indexLocation;
            if (indexLocation != 0) SetStartPosition();
            InitParts(indexLocation);
        }

        private void SetStartPosition()
        {
            transform.localPosition += new Vector3(0, CanvasSettings.Instance.HeightCanvas, 0);
        }

        private void InitParts(int indexLocation)
        {
            foreach (var part in _parts)
                part.Init(indexLocation, _blockQuantityMultiplier);
        }

        public void DestroyLocation()
        {
            OnReturnGameEntities.Invoke(_indexLocation);
            Destroy(gameObject);
        }
    }
}
