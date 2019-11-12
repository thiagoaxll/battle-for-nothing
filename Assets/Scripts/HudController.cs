using TMPro;
using UnityEngine;

public class HudController : MonoBehaviour
{
    public static HudController instance;
    public TextMeshProUGUI[] playerScores;
    public TextMeshProUGUI textTime;

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
        textTime.SetText(time.ToString("F0"));
    }
}