using CustomSystem;
using TMPro;
using UnityEngine;

public class HudController : LegacyInputImplementation
{
    public static HudController instance;
    public TextMeshProUGUI[] playerScores;
    public TextMeshProUGUI textTime;


    public GameObject endMatchBg;
    public GameObject winnerHolder;
    public GameObject[] winnerObject;

    public MenuSelect menuSelect;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
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

    public void ShowWinner(int winner)
    {
        endMatchBg.SetActive(true);
        var tempObject = Instantiate(winnerObject[winner], winnerHolder.transform.position, Quaternion.identity);
        tempObject.transform.SetParent(winnerHolder.transform);
        tempObject.transform.localPosition = Vector2.zero;
        menuSelect.Enable = true;
        menuSelect.SelectButton(0);
    }
}