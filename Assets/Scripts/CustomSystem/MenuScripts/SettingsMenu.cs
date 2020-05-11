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
        private float _maxVolume = 100;

        private void Start()
        {
            volMusic = musicSlider.value;
            volEffect = effectSlider.value;
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

        private bool CheckOptionsIndex(bool moveUp)
        {
            if (moveUp)
            {
                return menuIndex < menuIndexMax - 1;
            }
            else
            {
                return menuIndex > 0;
            }
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
                    volMusic -= 10;
                    if (volMusic <= 0) volMusic = 0;
                    SetMusicVol(volMusic);
                    break;
                case 1:
                    volEffect -= 10;
                    if (volEffect <= 0) volEffect = 0;
                    SetEffectVol(volEffect);
                    break;
            }
        }

        public void OnRight()
        {
            switch (menuIndex)
            {
                case 0:
                    volMusic += 10;
                    if (volMusic >= _maxVolume) volMusic = 100;
                    SetMusicVol(volMusic);
                    break;
                case 1:
                    volEffect += 10;
                    if (volEffect >= _maxVolume) volEffect = 100;
                    SetEffectVol(volEffect);
                    break;
            }
        }

        public void OnUp()
        {
            if(_controlSettingsOpen) return;
            if (CheckOptionsIndex(true))
            {
                menuIndex++;
            }
        }

        public void OnDown()
        {
            if(_controlSettingsOpen) return;
            if (CheckOptionsIndex(false))
            {
                menuIndex--;
            }
        }
    }
}