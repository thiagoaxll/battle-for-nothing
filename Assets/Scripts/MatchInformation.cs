using UnityEngine;
using CustomSystem;
using System;

public class MatchInformation : MonoBehaviour
{
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
    public Characters character;
}