using System;
using MusicSystem;
using UnityEngine;
using UnityEngine.UI;

namespace MainMenu.ThemeControllers
{
    public class ThemeSelectorController : MonoBehaviour
    {
        [SerializeField] private Image _themeButtonIcon;
        [SerializeField] private Sprite _purpleThemeChosenIcon;
        [SerializeField] private Sprite _blueThemeChosenIcon;
        private int _indexCurrentTheme;

        public static Action OnChoosePurpleTheme;
        public static Action OnChooseBlueTheme;

        private void Start()
        {
            _indexCurrentTheme = PlayerPrefs.GetInt(ThemeDataKeys.IsChosenClassicThemeKey);

            if (_indexCurrentTheme == 0)
            {
                OnChooseBlueTheme.Invoke();
                _indexCurrentTheme = 1;
            }
            else
            {
                OnChoosePurpleTheme.Invoke();
                _indexCurrentTheme = 0;
            }
        }

        public void ClickChoose()
        {
            if (_indexCurrentTheme == 0)
            {
                OnChooseBlueTheme.Invoke();
                PlayerPrefs.SetInt(ThemeDataKeys.IsChosenClassicThemeKey, 0);
                _indexCurrentTheme = 1;
                MusicController.Instance.LoadState();
            }
            else 
            {
                OnChoosePurpleTheme.Invoke();
                PlayerPrefs.SetInt(ThemeDataKeys.IsChosenClassicThemeKey, 1);
                _indexCurrentTheme = 0;
                MusicController.Instance.LoadState();
            }
        }
    }
}
