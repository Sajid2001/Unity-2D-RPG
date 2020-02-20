using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackGroundMusicScript : MonoBehaviour
{
    public Scene scene;

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
    void Update()
    {
        scene = SceneManager.GetActiveScene();
        if (scene.buildIndex == 6)
        {
            this.gameObject.SetActive(false);
        }
        else
        {
            this.gameObject.SetActive(true);
        }
    }

 
}
