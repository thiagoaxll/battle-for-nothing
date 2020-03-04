using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class MainMenuManager : MonoBehaviour
{
    public GameObject[] characters;
    public GameObject[] charactersSelected;
    public GameObject[] charactersHolder;
    public GameObject[] pressWarning;

    public bool[] alreadySelected;

    public GameObject[] menus;

    public static CurrentMenu currentMenu;
    public static MainMenuManager instance;
    public bool canSelectCharacter;

    private List<int> ramdomizedCharacters = new List<int>();

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
        for (int i = 0; i < 4; i++)
        {
            ramdomizedCharacters.Add(i);
        }
    }

    public void CheckForAllSelection()
    {
        bool allSelected = true;
        for (int i = 0; i < alreadySelected.Length; i++)
        {
            allSelected = alreadySelected[i];
            if (!allSelected) break;
        }

        if (allSelected)
        {
            int map = Random.Range(0, 2);
            if (map == 0)
            {
                ChanceScene("Arena_0");
            }
            else
            {
                ChanceScene("Arena_1");
            }
        }
    }

    public void ChanceScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }

    public void RandomCharacters()
    {
        var shuffled = ramdomizedCharacters.OrderBy(x => Guid.NewGuid()).ToList();
        ramdomizedCharacters = shuffled;

        for (int i = 0; i < ramdomizedCharacters.Count; i++)
        {
            MatchInformation.instance.characterInfo[i].whoControl = ramdomizedCharacters[i];
        }
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void ResetCharacterSelection()
    {
        for (int i = 0; i < 4; i++)
        {
            Destroy(charactersSelected[i]);
            pressWarning[i].SetActive(true);
            alreadySelected[i] = false;
        }

        canSelectCharacter = false;
    }

    public void ShowMyCharacter(int whereToShow)
    {
        if (alreadySelected[whereToShow] == false && canSelectCharacter)
        {
            alreadySelected[whereToShow] = true;
            pressWarning[whereToShow].SetActive(false);
            charactersSelected[whereToShow] = Instantiate(characters[ramdomizedCharacters[whereToShow]],
                transform.position, Quaternion.identity);
            charactersSelected[whereToShow].transform.SetParent(charactersHolder[whereToShow].transform);
            charactersSelected[whereToShow].transform.localPosition = Vector2.zero;
            MatchInformation.instance.characterInfo[whereToShow].whoControl = ramdomizedCharacters[whereToShow];
            CheckForAllSelection();
        }
    }

    public void ChangeMenu()
    {
        foreach (var temp in menus)
        {
            temp.SetActive(false);
        }

        menus[(int) currentMenu].SetActive(true);

        if (currentMenu == CurrentMenu.CharacterSelect)
        {
            StartCoroutine(DelayEnableSelection());
        }
    }

    private IEnumerator DelayEnableSelection()
    {
        yield return new WaitForSeconds(0.5f);
        canSelectCharacter = true;
    }

    public void ShowCredits()
    {
        print("Show Credits");
    }

    public enum CurrentMenu
    {
        MainMenu,
        ConfigMenu,
        CharacterSelect
    }
}