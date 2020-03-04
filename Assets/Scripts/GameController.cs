using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class GameController : MonoBehaviour
{
    public static GameController instance;
    public bool gameRunning = true;
    public Transform[] spawnPositions;
    public Transform powerUpSpawnPosition;
    public GameObject[] players;
    public GameObject[] powerUps;
    public float matchDuration;

    public int[] playerScore;
    public int[] playerIndex;

    private float auxMatchDuration;
    private int currentPowerUpToSpawn;

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
        Time.timeScale = 1;
        auxMatchDuration = matchDuration;

        for (int i = 0; i < players.Length; i++)
        {
            var position = spawnPositions[i].position;
            var temp = Instantiate(players[MatchInformation.instance.characterInfo[i].whoControl], position, Quaternion.identity);
            temp.GetComponent<CharacterController>().whoControlMe = i;
        }

        StartCoroutine(DelaySpawnPowerUp());
    }

    private IEnumerator DelaySpawnPowerUp()
    {
        while (currentPowerUpToSpawn < powerUps.Length)
        {
            yield return new WaitForSeconds((matchDuration / 2) / powerUps.Length);
            InstantiatePowerUp();
            currentPowerUpToSpawn++;
        }
    }

    private void InstantiatePowerUp()
    {
        Instantiate(powerUps[currentPowerUpToSpawn], powerUpSpawnPosition.transform.position, Quaternion.identity);
    }


    private void Update()
    {
        if (!gameRunning) return;
        auxMatchDuration -= Time.deltaTime;
        HudController.instance.UpdateTime(auxMatchDuration);
        if (auxMatchDuration <= 0)
        {
            CheckWinner();
        }
    }

    private void CheckWinner()
    {
        gameRunning = false;
        var winner = 0;
        var winnerScore = playerScore[0];
        for (int i = 0; i < playerScore.Length; i++)
        {
            if (playerScore[i] > winnerScore)
            {
                winnerScore = playerScore[i];
                winner = i;
            }
        }

        HudController.instance.ShowWinner(MatchInformation.instance.characterInfo[winner].whoControl);
    }

    public void SetPlayerScore(int player)
    {
        playerScore[player]++;
        HudController.instance.UpdateScore(player, playerScore[player]);
    }

    public void SpawnPlayer(int player, int whoControlMe)
    {
        var position = spawnPositions[Random.Range(0, spawnPositions.Length - 1)].position;
        var temp = Instantiate(players[player], position, Quaternion.identity);
        temp.GetComponent<CharacterController>().whoControlMe = whoControlMe;
    }

    public void ChangeScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }
}