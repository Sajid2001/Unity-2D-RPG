using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BattleTransition : Transitions

{
    public string gameOverScreen;


    public IEnumerator backToOverworld()
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

    public IEnumerator gameOver()
    {
        if (transitionOutPanel != null)
        {
            Instantiate(transitionOutPanel, Vector3.zero, Quaternion.identity);
        }
        yield return new WaitForSeconds(transitionWait);
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(gameOverScreen);
        while (!asyncOperation.isDone)
        {
            yield return null;
        }

    }

}
