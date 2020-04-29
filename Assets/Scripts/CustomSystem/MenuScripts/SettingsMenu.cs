using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace CustomSystem.MenuScripts
{
    public class SettingsMenu : MonoBehaviour, INavigationSystem
    {
    
        [SerializeField] private int menuIndex;
        [SerializeField] private int menuHorizontalIndex;
        [SerializeField] private int menuHorizontalIndexMax;
        [SerializeField] private int menuIndexMax;
        [SerializeField] private Color selectedColor;
        [SerializeField] private Color notSelectedColor;
        public GameObject[] options;
        public GameObject controlsInstruction;

        public Slider musicSlider;
        public Slider effectSlider;

        public float volMusic;
        public float volEffect;

        private bool controlSettingsOpen;
        
        private void Awake()
        {
            NavigationController.instance.currentNavigationSystem = this;
        }

        private void Start()
        {
            menuIndexMax = options.Length;
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
            volMusic = vol;
            musicSlider.value = volMusic;
            print("Music: " + volMusic);
        }
        
        public void SetEffectVol(float vol)
        {
            volEffect = vol;
            effectSlider.value = volEffect;
            print("Effect: " + volEffect);
        }

        public void OnUpdateHud()
        {
            foreach (var temp in options)
            {
                temp.GetComponentInChildren<TextMeshProUGUI>().color = notSelectedColor;
            }
            options[menuIndex].GetComponentInChildren<TextMeshProUGUI>().color = selectedColor;
        }

        private void UpdateDirectionVertical()
        {
            switch (menuIndex)
            {
                case 0:
                    musicSlider.Select();
                    print("START");
                    break;
                case 1:
                    effectSlider.Select();
                    print("SETTINGS");
                    break;
                case 2:
                    print("QUIT");
                    break;
            }
        }
        
        private void OnEnable()
        {
            NavigationController.instance.currentNavigationSystem = this;
        }
        
        public void OnConfirm()
        {
            switch (menuIndex)
            {
                case 2:
                    controlSettingsOpen = true;
                    controlsInstruction.SetActive(true);
                    break;
            }
        }

        public void OnCancel()
        {
            switch (menuIndex)
            {
                case 2:
                    if (controlSettingsOpen)
                    {
                        controlsInstruction.SetActive(false);
                        controlSettingsOpen = false;
                    }
                    else
                    {
                        NavigationController.instance.ChangeMenu(Menus.MainMenu);
                    }
                    break;
                default:
                    if (!controlSettingsOpen)
                    {
                        NavigationController.instance.ChangeMenu(Menus.MainMenu);
                    }
                    
                    break;
            } 
        }

        public void OnLeft()
        {
            switch (menuIndex)
            {
                case 0:
                    SetMusicVol(--volMusic);
                    break;
                case 1:
                    SetEffectVol(--volEffect);
                    break;
            }
        }

        public void OnRight()
        {
            switch (menuIndex)
            {
                case 0:
                    SetMusicVol(++volMusic);
                    break;
                case 1:
                    SetEffectVol(++volEffect);
                    break;
            }
        }

        public void OnUp()
        {
            if(controlSettingsOpen) return;
            if (CheckOptionsIndex(true))
            {
                menuIndex++;
            }
        }

        public void OnDown()
        {
            if(controlSettingsOpen) return;
            if (CheckOptionsIndex(false))
            {
                menuIndex--;
            }
        }
    }
}
