using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class MatchManager : MonoBehaviour
{
    public static MatchManager instance;
    public List<string> maps = new List<string>()
    {
        $"Arena_0",
        $"Arena_1",
        $"Arena_2"
    };
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }

    public void CheckToStartMatchRoutine(SelectedCharacterInfo[] selectedOptions)
    {
        if(MatchInformation.instance.selectedCharacterQuantity < 4) return;
        if(MatchInformation.instance.selectedMapQuantity < 4) return;
        
        int randMap = selectedOptions[Random.Range(0, 4)].selectedMap;

        SceneManager.LoadScene(maps[randMap]);
    }
}