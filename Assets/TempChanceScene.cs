using UnityEngine;
using UnityEngine.SceneManagement;

public class TempChanceScene : MonoBehaviour
{


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            SceneManager.LoadScene("Menu");
        }
    }
}
