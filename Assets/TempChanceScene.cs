using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TempChanceScene : MonoBehaviour
{


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            SceneManager.LoadScene("Area");
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            SceneManager.LoadScene("scene1");
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            SceneManager.LoadScene("scene2");
        }
    }
}
