using LevelsControllers;
using UnityEngine;
using UnityEngine.UI;

namespace MainMenu
{
    public class AchievementsController : MonoBehaviour
    {
        [SerializeField] private Image _achievementsImage1;
        [SerializeField] private Image _achievementsImage2;
        [SerializeField] private Image _achievementsImage3;
        [SerializeField] private Image _achievementsImage4;
        [SerializeField] private Image _achievementsImage5;
        [SerializeField] private Image _achievementsImage6;

        private void Start()
        {
            CheckStarsProgress();
        }

        private void CheckStarsProgress()
        {
            var amountStars = 0;
            
            for (var i = 0; i < LevelDataContainer.LevelsData.Count; i++)
            {
                var firstStar = PlayerPrefs.GetInt($"{LevelDataKeys.FirstStarOpenKey}{i}");
                var secondStar = PlayerPrefs.GetInt($"{LevelDataKeys.SecondStarOpenKey}{i}");
                var thirdStar = PlayerPrefs.GetInt($"{LevelDataKeys.ThirdStarOpenKey}{i}");
                
                amountStars += firstStar + secondStar + thirdStar;

                if (firstStar + secondStar + thirdStar != 3) return;
                
                if (i == 0)
                    _achievementsImage1.color = new Color32(255, 255, 255, 255);
                else if (i == 2)
                    _achievementsImage2.color = new Color32(255, 255, 255, 255);
                else if (i == 4)
                    _achievementsImage3.color = new Color32(255, 255, 255, 255);
                else if (i == 6)
                    _achievementsImage4.color = new Color32(255, 255, 255, 255);
                else if (i == 9)
                    _achievementsImage5.color = new Color32(255, 255, 255, 255);
            }
            
            if (amountStars == LevelDataContainer.LevelsData.Count * 3)
                _achievementsImage6.color = new Color32(255, 255, 255, 255);
        }
    }
}
