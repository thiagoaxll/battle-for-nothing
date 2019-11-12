using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class GameController : MonoBehaviour
{
    public static GameController instance;
    public Transform[] spawnPositions;
    public GameObject[] players;
    public float matchDuration;

    public int[] playerScore;
    public int[] playerIndex;

    private float auxMatchDuration;

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
        auxMatchDuration = matchDuration;

        for (int i = 0; i < players.Length; i++)
        {
            var position = spawnPositions[i].position;
            var temp = Instantiate(players[i], position, Quaternion.identity);
        }
    }



    private void Update()
    {
        auxMatchDuration -= Time.deltaTime;
        HudController.instance.UpdateTime(auxMatchDuration);
        if (auxMatchDuration <= 0)
        {
            SceneManager.LoadScene("Area");
        }
    }

    public void SetPlayerScore(int player)
    {
        playerScore[player]++;
        HudController.instance.UpdateScore(player, playerScore[player]);
    }

    public void SpawnPlayer(int player)
    {
        var position = spawnPositions[Random.Range(0, spawnPositions.Length - 1)].position;
        var temp = Instantiate(players[player], position, Quaternion.identity);
    }
}