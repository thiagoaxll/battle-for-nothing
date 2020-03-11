using System;
using CustomSystem;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Menu
{
    public class NavigationManager : LegacyInputImplementation
    {
        private NavigationCoordinates navigationCoordinates;
        public INavigationCommands command;
        public MenuSelected currentMenu = MenuSelected.MainMenu;
        public int currentOptionSelected = 0;
        
        
        private void Awake()
        {
            navigationCoordinates = new NavigationCoordinates();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                currentOptionSelected++;
                CheckForMaxNumber();
            }

            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                currentOptionSelected--;
                CheckForMaxNumber();
            }
            
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SelectedMenu();
            }
        }

        private void SelectedMenu()
        {
            Vector2 teste = new Vector2();
            teste.x = currentOptionSelected;
            switch (currentMenu)
            {
                case MenuSelected.MainMenu:
                    MainMenuNavigation.instance.mainNavigationCommands.Execute(teste);
                    break;
            }
        }

        private void CheckForMaxNumber()
        {
            switch (currentMenu)
            {
                case MenuSelected.MainMenu:
                    if (currentOptionSelected == MainMenuNavigation.instance.optionsQuantity + 1 || currentOptionSelected <= 0)
                    {
                        currentOptionSelected = 0;
                    }
                    break;
            }
        }
    }

    class NavigationCoordinates
    {
        public  MenuSelected currentMenuSelected = MenuSelected.MainMenu;
        public Vector2 currentItemSelect = new Vector2(0, 0);
    }

    public enum MenuSelected
    {
        MainMenu,
        Settings,
        Credits,
        ChampionSelect,
        MapSelect
    }
}
