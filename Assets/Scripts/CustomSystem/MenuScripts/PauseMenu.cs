using CustomSystem.MenuControllers;
using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;

namespace CustomSystem.MenuScripts
{
    public class PauseMenu : MonoBehaviour, INavigationSystem
    {
        
        [SerializeField] private string menuSceneName;
        [SerializeField] private Color selectedColor;
        [SerializeField] private Color notSelectedColor;
        public TextMeshProUGUI[] options;

        private NavigationController _navigationController;
        private MenuUtils _menuUtils;
        private int _maxIndex;
        private int _currentIndex;

        private void Awake()
        {
            _navigationController = gameObject.AddComponent<NavigationController>();
        }

        private void Start()
        {
            _maxIndex = options.Length;
            _menuUtils = new MenuUtils();
            _navigationController.currentNavigationSystem = this;
            OnUpdateHud();
        }
        
        public void SetJoystick(JoystickIndex joystickIndex)
        {
            _navigationController.joystickIndex = joystickIndex;
        }

        public void OnUpdateHud()
        {
            foreach (var temp in options)
            {
                temp.color = notSelectedColor;
            }
            
            options[_currentIndex].color = selectedColor;
        }

        public void OnConfirm()
        {
            GameController.instance.ResumeGame();
            switch (_currentIndex)
            {
                case 1:
                    GameController.instance.ResumeGame();
                    SceneManager.LoadScene(menuSceneName);
                    break;
            }
        }

        public void OnCancel()
        {
            GameController.instance.ResumeGame();
        }

        public void OnLeft()
        {
        }

        public void OnRight()
        {
        }

        public void OnUp()
        {
            _currentIndex = _menuUtils.ReturnBoundaryIndex(_currentIndex, _maxIndex, MenuDirection.Up);
        }

        public void OnDown()
        {
            _currentIndex = _menuUtils.ReturnBoundaryIndex(_currentIndex, _maxIndex, MenuDirection.Down);
        }
    }
}