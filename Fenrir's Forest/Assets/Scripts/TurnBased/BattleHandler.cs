using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using EZCameraShake;
using UnityEngine.SceneManagement;

public enum BattleState
{
    Start,
    PlayerTurn,
    EnemyTurn,
    Won,
    Lost
}
public class BattleHandler : MonoBehaviour
{

    [SerializeField]
    private GameObject player;

    [SerializeField]
    private GameObject enemy;

    public Transform playerPosition;

    public Transform enemyPosition;

    public Text dialogText;

    public UserHud userHud;

    public EnemyHud enemyHud;

    Stats playerStats;
    Stats enemyStats;

    public BattleState state;

    public GameObject playerTurnArrow;

    public GameObject enemyTurnArrow;

    public BattleTransition battleTransition;


    private void Start()
    {
        state = BattleState.Start;
        StartCoroutine(SetupBattle());
    }

    IEnumerator SetupBattle()
    {
        dialogText.text = "A wolf approaches it's prey";

        GameObject playerGameObject = Instantiate(player, playerPosition.position, playerPosition.rotation);

        playerStats = playerGameObject.GetComponent<Stats>();

        GameObject enemyGameObject = Instantiate(enemy, enemyPosition.position, enemyPosition.rotation);

        enemyStats = enemyGameObject.GetComponent<Stats>();

        userHud.SetHud(playerStats);

        enemyHud.SetHud(enemyStats);

        userHud.actionBox.SetActive(false);
        yield return new WaitForSeconds(2f);

        state = BattleState.PlayerTurn;
        PlayerTurn();

    }
    void PlayerTurn()
    {
        playerTurnArrow.SetActive(true);
        userHud.actionBox.SetActive(true);
        dialogText.text = "Make your move";
    }

    public void OnAttackButton()
    {
        if (state != BattleState.PlayerTurn)
            return;
        StartCoroutine(PlayerAttack());
        userHud.actionBox.SetActive(false);
    }

    public void OnHealButton()
    {
        if (state != BattleState.PlayerTurn)
            return;
        StartCoroutine(PlayerHeal());
        userHud.actionBox.SetActive(false);
    }


    IEnumerator PlayerAttack()
    {
        playerTurnArrow.SetActive(false);

        Slide(playerStats, enemyPosition.position, playerPosition.position);

        playerStats.animator.SetBool("isAttacking", true);

        CameraShaker.Instance.ShakeOnce(3f, 3f, .1f, .1f);

        bool isDead = enemyStats.TakeDamage(playerStats.damage);

        yield return new WaitForSeconds(1f);

        SlideBack(playerStats, enemyPosition.position, playerPosition.position);

        enemyHud.SetHP(enemyStats.health.runtimeValue);

        playerStats.animator.SetBool("isAttacking", false);

        if (isDead)
        {
            state = BattleState.Won;
            StartCoroutine(EndBattle());
        }
        else
        {
            yield return new WaitForSeconds(1f);
            state = BattleState.EnemyTurn;
            StartCoroutine(EnemyTurn());
        }
    }

    IEnumerator PlayerHeal()
    {
        playerStats.Heal(50);
        if (playerStats.totalHeals.runtimeValue > 0)
        {
            dialogText.text = "You regained some needed health";
        }
        else if (playerStats.totalHeals.runtimeValue == 0)
        {
            dialogText.text = "You are out of heals";
        }
        userHud.SetHP(playerStats.health.runtimeValue);

        userHud.UpdateHealsLeft(playerStats);

        playerTurnArrow.SetActive(false);

        yield return new WaitForSeconds(2f);

        state = BattleState.EnemyTurn;
        StartCoroutine(EnemyTurn());
    }

    IEnumerator EnemyTurn()
    {
        enemyTurnArrow.SetActive(true);

        dialogText.text = "The " + enemyStats.unitName + " will attack";

        yield return new WaitForSeconds(1f);

        enemyTurnArrow.SetActive(false);

        Slide(enemyStats, playerPosition.position, enemyPosition.position);

        enemyStats.animator.SetBool("isAttacking", true);

        CameraShaker.Instance.ShakeOnce(3f, 3f, .1f, .1f);

        bool isDead = playerStats.TakeDamage(enemyStats.damage);

        yield return new WaitForSeconds(1f);

        userHud.SetHP(playerStats.health.runtimeValue);

        SlideBack(enemyStats, playerPosition.position, enemyPosition.position);

        enemyStats.animator.SetBool("isAttacking", false);

        if (isDead)
        {
            state = BattleState.Lost;
            StartCoroutine(EndBattle());
        }
        else
        {
            state = BattleState.PlayerTurn;
            PlayerTurn();
        }
    }

    IEnumerator EndBattle()
    {
        if (state == BattleState.Won)
        {
            playerTurnArrow.SetActive(false);
            dialogText.text = "You win";
            enemyStats.animator.SetBool("isDead", true);
            yield return new WaitForSeconds(1f);
            StartCoroutine(battleTransition.backToOverworld());
        }
        else if (state == BattleState.Lost)
        {
            enemyTurnArrow.SetActive(false);
            dialogText.text = "You lose";
            playerStats.animator.SetBool("isDead", true);
            yield return new WaitForSeconds(1f);
            StartCoroutine(battleTransition.gameOver());
        }
    }

    void Slide(Stats unit, Vector3 startingPosition, Vector3 endingPosition)
    {
        unit.transform.position = Vector3.Lerp(endingPosition, startingPosition, 1);
    }


    void SlideBack(Stats unit, Vector3 startingPosition, Vector3 endingPosition)
    {
        unit.transform.position = Vector3.Lerp(startingPosition, endingPosition, 1);
    }

}
