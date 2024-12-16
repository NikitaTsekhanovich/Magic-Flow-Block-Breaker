using System.Collections.Generic;
using SceneLoaderControllers;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace MainMenu.ThemeControllers
{
    public class ThemeLoader : MonoBehaviour
    {
        [Header("UI Elements")]
        [SerializeField] private List<Image> _mainBackgrounds = new();
        [SerializeField] private List<Image> _logos = new();
        [SerializeField] private List<Image> _playButtons = new();
        [SerializeField] private List<Image> _backButtons = new();
        [SerializeField] private List<Image> _frames = new();
        [SerializeField] private Image _levelsBackground;
        [SerializeField] private Image _gameBackground;
        [SerializeField] private Image _themeButton;
        [SerializeField] private Image _achievementsButton;
        [SerializeField] private Image _pauseButton;
        
        [Header("Blue theme")]
        [SerializeField] private Sprite _blueMainBckground;
        [SerializeField] private Sprite _blueLogo;
        [SerializeField] private Sprite _bluePlayButtons;
        [SerializeField] private Sprite _blueLevelsBackground;
        [SerializeField] private Sprite _blueGameBackground;
        [SerializeField] private Sprite _blueFrame;
        [SerializeField] private Sprite _blueBackButton;
        [SerializeField] private Sprite _blueThemeButton;
        [SerializeField] private Sprite _blueAchievementsButton;
        [SerializeField] private Sprite _bluePauseButton;
        
        [Header("Purple theme")]
        [SerializeField] private Sprite _purpleMainBckground;
        [SerializeField] private Sprite _purpleLogo;
        [SerializeField] private Sprite _purplePlayButtons;
        [SerializeField] private Sprite _purpleLevelsBackground;
        [SerializeField] private Sprite _purpleGameBackground;
        [SerializeField] private Sprite _purpleFrame;
        [SerializeField] private Sprite _purpleBackButton;
        [SerializeField] private Sprite _purpleThemeButton;
        [SerializeField] private Sprite _purpleAchievementsButton;
        [SerializeField] private Sprite _purplePauseButton;

        private void OnEnable()
        {
            ThemeSelectorController.OnChoosePurpleTheme += ChoosePurpleTheme;
            ThemeSelectorController.OnChooseBlueTheme += ChooseBlueTheme;
            SceneDataLoader.OnLoadTheme += LoadTheme;
        }

        private void OnDisable()
        {
            ThemeSelectorController.OnChoosePurpleTheme -= ChoosePurpleTheme;
            ThemeSelectorController.OnChooseBlueTheme -= ChooseBlueTheme;
            SceneDataLoader.OnLoadTheme -= LoadTheme;
        }

        private void LoadTheme()
        {
            if (PlayerPrefs.GetInt(ThemeDataKeys.IsChosenClassicThemeKey) == 0)
                ChooseBlueTheme();
            else
                ChoosePurpleTheme();
        }

        private void ChoosePurpleTheme()
        {
            foreach (var mainBackground in _mainBackgrounds)
            {
                if (mainBackground != null) mainBackground.sprite = _purpleMainBckground;
            }
            
            foreach (var logo in _logos)
            {
                if (logo != null) logo.sprite = _purpleLogo;
            }
            
            foreach (var playButton in _playButtons)
            {
                if (playButton != null) playButton.sprite = _purplePlayButtons;
            }
            
            foreach (var backButton in _backButtons)
            {
                if (backButton != null) backButton.sprite = _purpleBackButton;
            }
            
            foreach (var frame in _frames)
            {
                if (frame != null) frame.sprite = _purpleFrame;
            }
            
            if (_levelsBackground != null) _levelsBackground.sprite = _purpleLevelsBackground;
            if (_gameBackground != null) _gameBackground.sprite = _purpleGameBackground;
            if (_themeButton != null) _themeButton.sprite = _purpleThemeButton;
            if (_achievementsButton != null) _achievementsButton.sprite = _purpleAchievementsButton;
            if (_pauseButton != null) _pauseButton.sprite = _purplePauseButton;
        }

        private void ChooseBlueTheme()
        {
            foreach (var mainBackground in _mainBackgrounds)
            {
                if (mainBackground != null) mainBackground.sprite = _blueMainBckground;
            }
            
            foreach (var logo in _logos)
            {
                if (logo != null) logo.sprite = _blueLogo;
            }
            
            foreach (var playButton in _playButtons)
            {
                if (playButton != null) playButton.sprite = _bluePlayButtons;
            }
            
            foreach (var backButton in _backButtons)
            {
                if (backButton != null) backButton.sprite = _blueBackButton;
            }
            
            foreach (var frame in _frames)
            {
                if (frame != null) frame.sprite = _blueFrame;
            }
            
            if (_levelsBackground != null) _levelsBackground.sprite = _blueLevelsBackground;
            if (_gameBackground != null) _gameBackground.sprite = _blueGameBackground;
            if (_themeButton != null) _themeButton.sprite = _blueThemeButton;
            if (_achievementsButton != null) _achievementsButton.sprite = _blueAchievementsButton;
            if (_pauseButton != null) _pauseButton.sprite = _bluePauseButton;
        }
    }
}
