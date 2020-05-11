using CustomSystem.MenuControllers;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace CustomSystem.MenuScripts
{
    public class SelectCharacter : MonoBehaviour, INavigationSystem
    {
        [SerializeField] private CharacterSelectionMenu characterSelectionMenu;
        public JoystickIndex joystickIndex;
        public SelectCharacterStatus selectCharacterStatus;
        
        public Image characterBackground;
        public Image mapBackground;
        
        public GameObject characterHolder;
        public GameObject mapHolder;
        
        public int currentIndex;
        public int currentMaxIndex;

        private NavigationController _navigationController;
        private GameObject _currentCharacterInstantiated;
        private GameObject _currentMapInstantiated;
        
        
        private void Start()
        {
            _navigationController = gameObject.AddComponent<NavigationController>();
            SetupCharacterSelection();
        }

        private void SetupCharacterSelection()
        {
            _navigationController.SetJoystick(joystickIndex);
            _navigationController.currentNavigationSystem = this;
            selectCharacterStatus = SelectCharacterStatus.SelectingCharacter;
            currentIndex = 0;
            currentMaxIndex = characterSelectionMenu.characters.Length;
            ChangeCharacter(Random.Range(0, currentMaxIndex - 1));
            ChangeMap(0);
        }


        private void ChangeCharacter(int characterIndex)
        {
            Destroy(_currentCharacterInstantiated);
            _currentCharacterInstantiated = Instantiate(characterSelectionMenu.characters[characterIndex], characterHolder.transform, true);
            _currentCharacterInstantiated.transform.localPosition = Vector2.zero;
        }

        private void ChangeMap(int mapIndex)
        {
            Destroy(_currentMapInstantiated);
            _currentMapInstantiated = Instantiate(characterSelectionMenu.maps[mapIndex], mapHolder.transform, true);
            _currentMapInstantiated.transform.localPosition = Vector2.zero;
        }

        private int CheckIndexBoundary(int index, int maxIndex, int direction)
        {
            if (direction < 0)
            {
                return index <= 0 ? 0 : index;
            }
            return index < (maxIndex - 1) ? index : maxIndex - 1;
        }
        
        public void OnUpdateHud()
        {
        }

        public void OnConfirm()
        {
            switch (selectCharacterStatus)
            {
                case (SelectCharacterStatus.SelectingCharacter):
                    currentMaxIndex = characterSelectionMenu.maps.Length;
                    selectCharacterStatus = SelectCharacterStatus.SelectingMap;
                    characterBackground.color = Color.black;
                    
                    SelectedCharacterInfo selectedCharacterInfo;
                    selectedCharacterInfo.joystick = JoystickIndex.JoystickOne;
                    selectedCharacterInfo.character = (Characters) currentIndex;
                    MatchInformation.instance.SetSelectedCharacter(selectedCharacterInfo, (int) joystickIndex);

                    break;
                case (SelectCharacterStatus.SelectingMap):
                    mapBackground.color = Color.black;
                    currentMaxIndex = characterSelectionMenu.maps.Length;
                    selectCharacterStatus = SelectCharacterStatus.Finish;
                    break;
            }
            currentIndex = 0;
        }

        public void OnCancel()
        {
            currentIndex = 0;
            switch (selectCharacterStatus)
            {
                case (SelectCharacterStatus.SelectingCharacter):
                    currentMaxIndex = characterSelectionMenu.characters.Length;
                    if (joystickIndex == JoystickIndex.JoystickOne)
                    {
                        MenuManager.instance.ChangeCurrentMenuRoutine(MenuCatalog.MainMenu);
                    }
                    break;
                case (SelectCharacterStatus.SelectingMap):
                    currentMaxIndex = characterSelectionMenu.characters.Length;
                    selectCharacterStatus = SelectCharacterStatus.SelectingCharacter;
                    characterBackground.color = Color.white;
                    break;
                case (SelectCharacterStatus.Finish):
                    currentMaxIndex = characterSelectionMenu.characters.Length;
                    selectCharacterStatus = SelectCharacterStatus.SelectingCharacter;
                    characterBackground.color = Color.white;
                    mapBackground.color = Color.white;
                    break;
            }
        }

        public void OnLeft()
        {
            currentIndex = CheckIndexBoundary(--currentIndex, currentMaxIndex, -1);
            switch (selectCharacterStatus)
            {
                case (SelectCharacterStatus.SelectingCharacter):
                    ChangeCharacter(currentIndex);
                    break;
                case (SelectCharacterStatus.SelectingMap):
                    ChangeMap(currentIndex);
                    break;
            }
        }

        public void OnRight()
        {
            currentIndex = CheckIndexBoundary(++currentIndex, currentMaxIndex, 1);
            switch (selectCharacterStatus)
            {
                case (SelectCharacterStatus.SelectingCharacter):
                    ChangeCharacter(currentIndex);
                    break;
                case (SelectCharacterStatus.SelectingMap):
                    ChangeMap(currentIndex);
                    break;
            }
        }

        public void OnUp()
        {
        }

        public void OnDown()
        {
        }
    }

    public enum SelectCharacterStatus
    {
        SelectingCharacter,
        SelectingMap,
        Finish
    }
}