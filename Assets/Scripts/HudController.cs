using System;
using System.Collections;
using CustomSystem;
using TMPro;
using UnityEngine;

public class HudController : LegacyInputImplementation
{
    public static HudController instance;
    public TextMeshProUGUI[] playerScores;
    public TextMeshProUGUI textTime;


    public GameObject endMatchBg;
    public GameObject buttonsEndMatch;
    public GameObject winnerHolder;
    public GameObject[] winnerObject;
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
            Destroy(this.gameObject);
        }
    }

    private void Start()
    {
        InstantiatePortraits();
    }

    private void InstantiatePortraits()
    {
        for (int i = 0; i < portraits.Length; i++)
        {
            var temp = Instantiate(portraits[(int) MatchInformation.instance.characterInfo[i].joystick], transform.position,
                Quaternion.identity);
            temp.transform.SetParent(portraitsHolder[i].transform);
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

    public void ShowWinner(int winner)
    {
        endMatchBg.SetActive(true);
        var tempObject = Instantiate(winnerObject[winner], winnerHolder.transform.position, Quaternion.identity);
        tempObject.transform.SetParent(winnerHolder.transform);
        tempObject.transform.localPosition = Vector2.zero;
        StartCoroutine(DelayToShowRestartMenu());
    }

    private IEnumerator DelayToShowRestartMenu()
    {
        yield return new WaitForSeconds(2f);
        buttonsEndMatch.SetActive(true);
        menuSelect.Enable = true;
        menuSelect.SelectButton(0);
    }
}