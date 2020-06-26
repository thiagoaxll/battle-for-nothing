using CustomSystem.MenuControllers;
using CustomSystem.Audio;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

namespace CustomSystem.MenuScripts
{
    public class SettingsMenu : MonoBehaviour, INavigationSystem
    {
    
        [SerializeField] private int menuIndex;
        [SerializeField] private int menuIndexMax;
        [SerializeField] private Color selectedColor;
        [SerializeField] private Color notSelectedColor;
        public GameObject[] options;
        public GameObject controlsInstruction;

        public Slider musicSlider;
        public Slider effectSlider;

        public float volMusic;
        public float volEffect;

        private NavigationController _navigationController;
        private bool _controlSettingsOpen;
        private float _minVolume = -10;
        private float _maxVolume = 30;
        private float _scaleVolumeSlider = 4;
        private float _defaultMusicVolume = 15;
        private float _defaultEffectVolume = 15;
        private MenuUtils _menuUtils;

        private void Start()
        {
            _menuUtils = new MenuUtils();

            musicSlider.minValue = _minVolume;
            musicSlider.maxValue = _maxVolume;
            musicSlider.value = _defaultMusicVolume;
            
            effectSlider.minValue = _minVolume;
            effectSlider.maxValue = _maxVolume;
            effectSlider.value = _defaultEffectVolume;
            
            volMusic = _defaultMusicVolume;
            volEffect = _defaultEffectVolume;
            
            SetMusicVol(volMusic);
            SetEffectVol(volEffect);
            
            menuIndexMax = options.Length;
            _navigationController = gameObject.AddComponent<NavigationController>();
            SetupSettingsMenu();
        }
        
        private void SetupSettingsMenu()
        {
            _navigationController.SetJoystick(JoystickIndex.JoystickOne);
            _navigationController.currentNavigationSystem = this;
            OnUpdateHud();
        }
        
        public void SetMusicVol(float vol)
        {
            musicSlider.value = vol;
            SoundManager.instance.SetMusicVolume(volMusic);
        }
        
        public void SetEffectVol(float vol)
        {
            effectSlider.value = vol;
            SoundManager.instance.SetEffectVolume(volEffect);
        }

        public void OnUpdateHud()
        {
            foreach (var temp in options)
            {
                temp.GetComponentInChildren<TextMeshProUGUI>().color = notSelectedColor;
            }
            options[menuIndex].GetComponentInChildren<TextMeshProUGUI>().color = selectedColor;
        }
        
        public void OnConfirm()
        {
            switch (menuIndex)
            {
                case 2:
                    _controlSettingsOpen = true;
                    controlsInstruction.SetActive(true);
                    break;
            }
        }

        public void OnCancel()
        {
            switch (menuIndex)
            {
                case 2:
                    if (_controlSettingsOpen)
                    {
                        controlsInstruction.SetActive(false);
                        _controlSettingsOpen = false;
                    }
                    else
                    {
                        MenuManager.instance.ChangeCurrentMenuRoutine(MenuCatalog.MainMenu);
                    }
                    break;
                default:
                    if (!_controlSettingsOpen)
                    {
                        MenuManager.instance.ChangeCurrentMenuRoutine(MenuCatalog.MainMenu);
                    }
                    break;
            } 
        }

        public void OnLeft()
        {
            switch (menuIndex)
            {
                case 0:
                    volMusic -= _scaleVolumeSlider;
                    if (volMusic <= _minVolume) volMusic = _minVolume;
                    SetMusicVol(volMusic);
                    break;
                case 1:
                    volEffect -= _scaleVolumeSlider;
                    if (volEffect <= _minVolume) volEffect = _minVolume;
                    SetEffectVol(volEffect);
                    break;
            }
        }

        public void OnRight()
        {
            switch (menuIndex)
            {
                case 0:
                    volMusic += _scaleVolumeSlider;
                    if (volMusic >= _maxVolume) volMusic = _maxVolume;
                    SetMusicVol(volMusic);
                    break;
                case 1:
                    volEffect += _scaleVolumeSlider;
                    if (volEffect >= _maxVolume) volEffect = _maxVolume;
                    SetEffectVol(volEffect);
                    break;
            }
        }

        public void OnUp()
        {
            if(_controlSettingsOpen) return;
            menuIndex = _menuUtils.ReturnBoundaryIndex(menuIndex, menuIndexMax, MenuDirection.Up);
        }

        public void OnDown()
        {
            if(_controlSettingsOpen) return;
            menuIndex = _menuUtils.ReturnBoundaryIndex(menuIndex, menuIndexMax, MenuDirection.Down);
        }
    }
}