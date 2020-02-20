using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Transitions : MonoBehaviour
{
    public string roomToLoad;
    public VectorValue playerStorage;
    public GameObject transitionInPanel;
    public GameObject transitionOutPanel;
    public float transitionWait;


    void Awake()
    {
        if (transitionInPanel != null)
        {
            GameObject panel = Instantiate(transitionInPanel, Vector3.zero, Quaternion.identity);
            Destroy(panel, 1);
        }
    }
}
