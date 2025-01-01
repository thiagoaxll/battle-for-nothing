using CustomSystem.MenuScripts;
using CustomSystem;
using UnityEngine;
using TMPro;

public class HudController : LegacyInputImplementation
{
    public static HudController instance;
    public TextMeshProUGUI[] playerScores;
    public TextMeshProUGUI textTime;
    
    public GameObject endMatchMenu;
    public GameObject pauseMenu;
    public GameObject[] portraits;
    public GameObject[] portraitsHolder;

    public MenuSelect menuSelect;

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
        if(!GameController.instance.devMode)
            InstantiatePortraits();
    }

    public void SetPauseMenuVisibility(bool show)
    {
        pauseMenu.SetActive(show);
    }

    private void InstantiatePortraits()
    {
        for (int i = 0; i < portraitsHolder.Length; i++)
        {
            var temp = Instantiate(portraits[(int) MatchInformation.instance.characterInfo[i].character], transform.position,
                Quaternion.identity);
            temp.transform.SetParent(portraitsHolder[i].transform.GetChild(0).Find("PortraitFrame"));
            temp.transform.localPosition = Vector2.zero;
        }
    }

    public void UpdateScore(int index, int quantity)
    {
        playerScores[index].SetText(quantity.ToString());
    }

    public void UpdateTime(float time)
    {
        textTime.SetText(ShowMinutesSeconds.ConvertSecondsToMinutes(time));
    }
    
    public void SetEndMatchVisibility(int winnerIndex)
    {
        endMatchMenu.SetActive(true);
        endMatchMenu.GetComponent<EndMatchMenu>().ShowWinnerObject(winnerIndex);
    }
}