using CustomSystem;
using UnityEngine;

using System;
public class MatchInformation : MonoBehaviour
{
    public int selectedCharacterQuantity;
    public int selectedMapQuantity;
    
    public static MatchInformation instance;
    public SelectedCharacterInfo[] characterInfo = new SelectedCharacterInfo[4];

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
        DontDestroyOnLoad(gameObject);
    }

    public void SetSelectedCharacter(SelectedCharacterInfo selected, int index)
    {
        characterInfo[index] = selected;
    }
}


[Serializable]
public struct SelectedCharacterInfo
{
    public JoystickIndex joystick;
    public CharactersRegister character;
    public int selectedMap;
}