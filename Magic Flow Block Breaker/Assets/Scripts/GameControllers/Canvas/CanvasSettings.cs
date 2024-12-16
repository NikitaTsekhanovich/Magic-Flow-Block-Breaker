using UnityEngine;

namespace GameControllers.Canvas
{
    public class CanvasSettings : MonoBehaviour
    {
        private const float ReferenceWidth = 1080f;
        private const float ReferenceHeight = 1920f;
        private const float Match = 0.5f;
        private float _scaleFactor;
        
        public static CanvasSettings Instance { get; private set; }
        public float HeightCanvas { get; private set; }
        public float WidthCanvas { get; private set; }
        public float HeightLocation { get; private set; }
        public float StartPositionYLocation { get; private set; }

        private void Awake()
        {
            if (Instance == null)
                Instance = this;
            else if(Instance == this)
                Destroy(gameObject); 

            CalculateHeightCanvas();
        }

        private void CalculateHeightCanvas()
        {
            float screenWidth = Screen.width;
            float screenHeight = Screen.height;
            
            var widthScale = screenWidth / ReferenceWidth;
            var heightScale = screenHeight / ReferenceHeight;

            _scaleFactor = Mathf.Pow(widthScale * heightScale, Match);
            HeightCanvas = screenHeight / _scaleFactor;
            WidthCanvas = screenWidth / _scaleFactor;

            HeightLocation = HeightCanvas * 4;
            StartPositionYLocation = HeightCanvas * 2 - HeightCanvas / 2;
        }
    }
}
