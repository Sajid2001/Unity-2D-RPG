using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RoomTransition : Transitions
{
    public Vector2 playerPosition;

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") & !other.isTrigger)
        {
            playerStorage.initialValue = playerPosition;
            StartCoroutine(fadeCo());
        }
    }

    public IEnumerator fadeCo()
    {
        if (transitionOutPanel != null)
        {
            Instantiate(transitionOutPanel, Vector3.zero, Quaternion.identity);
        }
        yield return new WaitForSeconds(transitionWait);
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(roomToLoad);
        while (!asyncOperation.isDone)
        {
            yield return null;
        }
        
    }
}
