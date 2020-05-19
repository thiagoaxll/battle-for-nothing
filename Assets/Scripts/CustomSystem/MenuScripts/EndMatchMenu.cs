using CustomSystem.MenuControllers;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine;
using TMPro;

namespace CustomSystem.MenuScripts
{
    public class EndMatchMenu : MonoBehaviour, INavigationSystem
    {
        [SerializeField] private string menuSceneName;
        public GameObject winnerHolder;
        public GameObject[] winners;
        public GameObject optionsHolder;
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
            _navigationController.joystickIndex = JoystickIndex.JoystickOne;
            OnUpdateHud();
            StartCoroutine(DelayToShowOptions());
        }

        public void ShowWinnerObject(int winnerIndex)
        {
            var temp = Instantiate(winners[winnerIndex], transform.position, Quaternion.identity);
            temp.transform.SetParent(winnerHolder.transform);
            temp.transform.localPosition = Vector2.zero;
        }

        private IEnumerator DelayToShowOptions()
        {
            yield return new WaitForSeconds(0.6f);
            optionsHolder.SetActive(true);
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
                case 0:
                    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                    break;
                case 1:
                    SceneManager.LoadScene(menuSceneName);
                    break;
            }
        }

        public void OnCancel()
        {
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