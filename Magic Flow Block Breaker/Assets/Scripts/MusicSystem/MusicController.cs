using MainMenu.ThemeControllers;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

namespace MusicSystem
{
    public class MusicController : MonoBehaviour
    {
        [SerializeField] private Image _currentMusicImage;
        [SerializeField] private Image _currentEffectsImage;
        [SerializeField] private AudioMixer _mixer;
        [SerializeField] private Sprite _purpleMusicOnImage;
        [SerializeField] private Sprite _purpleMusicOffImage;
        [SerializeField] private Sprite _purpleEffectsOnImage;
        [SerializeField] private Sprite _purpleEffectsOffImage;
        [SerializeField] private Sprite _blueMusicOnImage;
        [SerializeField] private Sprite _blueMusicOffImage;
        [SerializeField] private Sprite _blueEffectsOnImage;
        [SerializeField] private Sprite _blueEffectsOffImage;
        private Sprite _musicOnImage;
        private Sprite _musicOffImage;
        private Sprite _effectsOnImage;
        private Sprite _effectsOffImage;
        private ModeMusic _musicIsOn;
        private ModeMusic _effectsIsOn;
        private const int volumeOn = 0;
        private const int volumeOff = -80;
        private const string musicMixerName = "Music";
        private const string effectsMixerName = "SoundEffects";

        public static MusicController Instance;

        private void Start()
        {
            if (Instance == null)
                Instance = this;
            else
                Destroy(this);

            LoadState();
        }

        public void LoadState()
        {
            _musicIsOn = (ModeMusic)PlayerPrefs.GetInt(MusicDataKeys.MusicIsOnKey);
            _effectsIsOn = (ModeMusic)PlayerPrefs.GetInt(MusicDataKeys.EffectsIsOnKey);

            if (PlayerPrefs.GetInt(ThemeDataKeys.IsChosenClassicThemeKey) == 0)
            {
                _musicOnImage = _blueMusicOnImage;
                _musicOffImage = _blueMusicOffImage;
                _effectsOnImage = _blueEffectsOnImage;
                _effectsOffImage = _blueEffectsOffImage;
            }
            else
            {
                _musicOnImage = _purpleMusicOnImage;
                _musicOffImage = _purpleMusicOffImage;
                _effectsOnImage = _purpleEffectsOnImage;
                _effectsOffImage = _purpleEffectsOffImage;
            }

            ChangeVolume(_musicIsOn, musicMixerName, _currentMusicImage,
                _musicOnImage, _musicOffImage);
            ChangeVolume(_effectsIsOn, effectsMixerName, _currentEffectsImage,
                _effectsOnImage, _effectsOffImage);
        }

        public void CheckMusicState(Image currentMusicImage)
        {
            ChangeState(ref _musicIsOn, MusicDataKeys.MusicIsOnKey);
            ChangeVolume(_musicIsOn, musicMixerName, currentMusicImage,
                _musicOnImage, _musicOffImage);
        }

        public void CheckSoundEffectsState(Image currentEffectsImage)
        {
            ChangeState(ref _effectsIsOn, MusicDataKeys.EffectsIsOnKey);
            ChangeVolume(_effectsIsOn, effectsMixerName, currentEffectsImage,
                _effectsOnImage, _effectsOffImage);
        }

        private void ChangeState(ref ModeMusic mode, string key)
        {
            mode = (ModeMusic)(((int)mode + (int)ModeMusic.Off) % 2);
            PlayerPrefs.SetInt(key, (int)mode);
        }

        private void ChangeVolume(ModeMusic isOn, string mixerName, Image currentImage,
            Sprite onImage, Sprite offImage)
        {
            if (isOn == ModeMusic.On)
            {
                _mixer.SetFloat(mixerName, volumeOn);
                currentImage.sprite = onImage;
            }
            else
            {
                _mixer.SetFloat(mixerName, volumeOff);
                currentImage.sprite = offImage;
            }
        }
    }
}