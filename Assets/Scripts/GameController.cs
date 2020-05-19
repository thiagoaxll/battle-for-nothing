using System.Collections;
using CustomSystem;
using CustomSystem.MenuScripts;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;
using CharacterController = Characters.CharacterController;

public class GameController : MonoBehaviour
{
    public static GameController instance;
    
    [SerializeField] private PauseMenu pauseMenu;
    public bool gameRunning = true;
    public bool gamePaused;
    public Transform[] spawnPositions;
    public Transform powerUpSpawnPosition;
    public GameObject[] players;
    public GameObject[] powerUps;
    public float matchDuration;

    public int[] playerScore;
   
    private float _auxMatchDuration;
    private int _currentPowerUpToSpawn;

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
        Time.timeScale = 1;
        _auxMatchDuration = matchDuration;

        for (int i = 0; i < players.Length; i++)
        {
            var position = spawnPositions[i].position;
            var temp = Instantiate(players[(int) MatchInformation.instance.characterInfo[i].character], position, Quaternion.identity);
            temp.GetComponent<CharacterController>().whoControlMe = (int) MatchInformation.instance.characterInfo[i].joystick;
        }

        StartCoroutine(DelaySpawnPowerUp());
    }

    public void PauseGame(JoystickIndex joystickIndex)
    {
        gamePaused = true;
        Time.timeScale = 0;
        HudController.instance.SetPauseMenuVisibility(true);
        pauseMenu.SetJoystick(joystickIndex);
    }

    public void ResumeGame()
    {
        gamePaused = false;
        Time.timeScale = 1;
        HudController.instance.SetPauseMenuVisibility(false);
    }

    private IEnumerator DelaySpawnPowerUp()
    {
        while (_currentPowerUpToSpawn < powerUps.Length)
        {
            yield return new WaitForSeconds((matchDuration / 2) / powerUps.Length);
            InstantiatePowerUp();
            _currentPowerUpToSpawn++;
        }
    }

    private void InstantiatePowerUp()
    {
        Instantiate(powerUps[_currentPowerUpToSpawn], powerUpSpawnPosition.transform.position, Quaternion.identity);
    }


    private void Update()
    {
        if (!gameRunning) return;
        _auxMatchDuration -= Time.deltaTime;
        HudController.instance.UpdateTime(_auxMatchDuration);
        if (_auxMatchDuration <= 0)
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
        
        HudController.instance.SetEndMatchVisibility((int) MatchInformation.instance.characterInfo[winner].character);
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