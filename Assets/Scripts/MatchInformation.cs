using UnityEngine;
using System;

public class MatchInformation : MonoBehaviour
{
    public static MatchInformation instance;
    public CharacterInfo[] characterInfo;


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
        DontDestroyOnLoad(this.gameObject);
    }

    public void SetSelectedCharacter(CharacterInfo[] selected)
    {
        characterInfo = selected;
    }

    [Serializable]
    public struct CharacterInfo
    {
        public int whoControl;
        public int myId;
    }
}