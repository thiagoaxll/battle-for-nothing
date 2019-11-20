using CustomSystem;


public class JoystickManager : LegacyInputImplementation
{

  public int joystickId;
  private void Update()
  {
    if (MainMenuManager.currentMenu == MainMenuManager.CurrentMenu.CharacterSelect)
    {
      if (ButtonA())
      {
        MainMenuManager.instance.ShowMyCharacter(joystickId);
      }
      
      if (ButtonB())
      {
        MainMenuManager.instance.ShowMyCharacter(joystickId);
        MainMenuManager.instance.ResetCharacterSelection();
        MenuSelectionController.instance.SelectMainMenu();
      }
    }
  }
  
  
  
}
