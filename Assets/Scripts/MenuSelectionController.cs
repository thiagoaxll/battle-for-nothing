using System;
using System.Collections;
using CustomSystem;
using UnityEngine;
using UnityEngine.UI;

public class MenuSelectionController : LegacyInputImplementation
{
    public static MenuSelectionController instance;

    public Button[] mainMenuButtons;
    public Button[] configButtons;
    public Button[] characterSelectionMenu;

    [SerializeField] private int currentButtonSelected;
    [SerializeField] private bool changedMenu;
    [SerializeField] private Button[] currentButtons;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        SelectMainMenu();
    }

    void Update()
    {
        if (changedMenu) return;
        if (MainMenuManager.currentMenu == MainMenuManager.CurrentMenu.MainMenu)
            NavigationMenu(ButtonDirection().y, mainMenuButtons.Length);

        else if (MainMenuManager.currentMenu == MainMenuManager.CurrentMenu.ConfigMenu)
            NavigationMenu(ButtonDirection().y, configButtons.Length);
    }

    private void LateUpdate()
    {
        if (currentButtons.Length < 1) return;
        currentButtons[currentButtonSelected].Select();
    }

    private void NavigationMenu(float direction, int currentMenuLength)
    {
        if ((Math.Abs(direction) < 0.5f)) return;
        if (direction > 0.5f)
        {
            if (currentButtonSelected < currentMenuLength - 1)
            {
                currentButtonSelected++;
            }
            else
            {
                currentButtonSelected = 0;
            }
        }
        else if (direction < -0.5f)
        {
            if (currentButtonSelected > 0)
            {
                currentButtonSelected--;
            }
            else
            {
                currentButtonSelected = currentMenuLength - 1;
            }
        }

        changedMenu = true;
        StartCoroutine(DelayToChangeMenu());
        SelectButton(currentButtonSelected);
    }

    private void SelectButton(int buttonToSelect)
    {
        currentButtons[buttonToSelect].Select();
    }

    public void SelectMainMenu()
    {
        currentButtons = mainMenuButtons;
        MainMenuManager.currentMenu = MainMenuManager.CurrentMenu.MainMenu;
        MainMenuManager.instance.ChangeMenu();
        currentButtonSelected = 0;
    }

    public void SelectCharacterMenu()
    {
        currentButtons = characterSelectionMenu;
        MainMenuManager.instance.RandomCharacters();
        currentButtonSelected = 0;
        MainMenuManager.currentMenu = MainMenuManager.CurrentMenu.CharacterSelect;
        MainMenuManager.instance.ChangeMenu();
    }

    public void SelectConfigMenu()
    {
        currentButtons = configButtons;
        MainMenuManager.currentMenu = MainMenuManager.CurrentMenu.ConfigMenu;
        MainMenuManager.instance.ChangeMenu();
        currentButtonSelected = 0;
    }

    private IEnumerator DelayToChangeMenu()
    {
        yield return new WaitForSeconds(0.2f);
        changedMenu = false;
    }
}