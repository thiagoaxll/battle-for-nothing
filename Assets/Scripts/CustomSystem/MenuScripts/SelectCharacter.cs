﻿using Characters;
using CustomSystem.MenuControllers;
using UnityEngine.UI;
using UnityEngine;

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
        public int selectedMapIndex;
        public int selectedCharacterIndex;

        private NavigationController _navigationController;
        private GameObject _currentCharacterInstantiated;
        private GameObject _currentMapInstantiated;
        private MenuUtils _menuUtils;
        
        private void Start()
        {
            _menuUtils = new MenuUtils();
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
                    selectedCharacterIndex = currentIndex;
                    MatchInformation.instance.selectedCharacterQuantity++;
                    break;
                case (SelectCharacterStatus.SelectingMap):
                    selectedMapIndex = currentIndex;
                    mapBackground.color = Color.black;
                    currentMaxIndex = characterSelectionMenu.maps.Length;
                    selectCharacterStatus = SelectCharacterStatus.Finish;
                    
                    SelectedCharacterInfo selectedCharacterInfo;
                    selectedCharacterInfo.joystick = joystickIndex;
                    selectedCharacterInfo.character = (CharactersRegister) selectedCharacterIndex;
                    selectedCharacterInfo.selectedMap = selectedMapIndex;
                    MatchInformation.instance.SetSelectedCharacter(selectedCharacterInfo, (int) joystickIndex);
                    
                    MatchInformation.instance.selectedMapQuantity++;
                    MatchManager.instance.CheckToStartMatchRoutine(MatchInformation.instance.characterInfo);
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
                    MatchInformation.instance.selectedCharacterQuantity--;
                    break;
                case (SelectCharacterStatus.Finish):
                    currentMaxIndex = characterSelectionMenu.characters.Length;
                    selectCharacterStatus = SelectCharacterStatus.SelectingCharacter;
                    characterBackground.color = Color.white;
                    mapBackground.color = Color.white;
                    MatchInformation.instance.selectedCharacterQuantity--;
                    MatchInformation.instance.selectedMapQuantity--;
                    break;
            }
        }

        public void OnLeft()
        {
            currentIndex = _menuUtils.ReturnBoundaryIndex(currentIndex, currentMaxIndex, MenuDirection.Left);
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
            currentIndex = _menuUtils.ReturnBoundaryIndex(currentIndex, currentMaxIndex, MenuDirection.Right);
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