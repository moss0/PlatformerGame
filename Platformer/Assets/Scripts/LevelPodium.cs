using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelPodium : MonoBehaviour
{
    public int Scene = 0;
    private void OnTriggerEnter(Collider other)
    {
        switch (Scene)
        {
            case 0:
                SceneManager.LoadScene("LevelSelect");
                break;
            
            case 1:
                SceneManager.LoadScene("Level_1");
                break;

            case 2:
                SceneManager.LoadScene("Level_2");
                break;

            case 3:
                SceneManager.LoadScene("Level_3");
                break;

            case 4:
                SceneManager.LoadScene("Level_4");
                break;

            default:
                Debug.LogWarning("Scene not found");
                break;
        }
        
    }
}
