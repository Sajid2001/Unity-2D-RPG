using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum GameState
{
    overworld,
    battle,
    gameOver,
}

public class MyGameManager : MonoBehaviour
{
    public PlayerMovement player;
    public GameState gameState;
    public string battleScene;
    public Interactable randomEncounterArea;
    public bool gotAttacked;
    public VectorValue playerStorage;


    void Update()
    {
        switch (gameState)
        {
            case (GameState.overworld):
                if(player.currentState == PlayerState.walk)
                {
                    RandomEncounter();
                }
                if (gotAttacked)
                {
                    playerStorage.initialValue = player.transform.position;
                    gameState = GameState.battle;
                }
                break;

            case (GameState.battle):

                LoadBattleScene();
                gotAttacked = false;
                break;

        }
    }

    void RandomEncounter()
    {
        if(randomEncounterArea != null)
        {
            if ((randomEncounterArea.playerInRange) && (player.currentState == PlayerState.walk))
            {
                if (Random.Range(1, 1000) <= 2)
                {
                    gotAttacked = true;
                }
            }
        }
       
    }

    void LoadBattleScene()
    {
        SceneManager.LoadScene(battleScene);    
    }


}
