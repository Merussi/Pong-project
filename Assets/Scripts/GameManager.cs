using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("Paddles")]
    public Transform playerPaddle;
    public Transform enemyPaddle;
    public Vector3 playerpos = new (7f, 0f, 0f);
    public Vector3 enemypos = new (-7f, 0f, 0f);

    [Header("Ball")]
    public BallController ballController;

    [Header("Score")]
    public int playerScore = 0;
    public int enemyScore = 0;

    public TextMeshProUGUI textPointsPlayer;
    public TextMeshProUGUI textPointsEnemy;

    public int winPoints = 2;

    public GameObject screenEndGame;

    public TextMeshProUGUI textEndGame;

    [SerializeField] GameObject powerUp;

    [SerializeField] GameObject boostText;

    void Start()
    {
        ResetGame();
        
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            ResetGame();
        }
    }


    public void ResetGame()
    {
        playerPaddle.position = playerpos;
        enemyPaddle.position = enemypos;

        ballController.ResetBall();

        playerScore = 0;
        enemyScore = 0;

        textPointsEnemy.text = enemyScore.ToString();
        textPointsPlayer.text = playerScore.ToString();


        DesactivePower();
        screenEndGame.SetActive(false);
        
    }

    public void ScorePlayer()
    {
        playerScore++;
        textPointsPlayer.text = playerScore.ToString();
        CheckWin();
    }
    public void EnemyScore()
    {
        enemyScore++;
        textPointsEnemy.text = enemyScore.ToString();
        CheckWin();
    }
    public void CheckWin()
    {
        if (enemyScore >= winPoints || playerScore >= winPoints)
        {
            EndGame();
            //ResetGame() ;
        }
    }
    public void EndGame()
    {
        screenEndGame.SetActive(true);
        string winner = SavedController.Instance.GetName(playerScore > enemyScore);
        textEndGame.text = "Vitória " + winner;
        SavedController.Instance.SaveWinner(winner);
        Invoke("LoadMenu", 2f);
        
    }

    private void LoadMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void ActivePower()
    {
        powerUp.SetActive(true);
        boostText.SetActive(true);
    }

    public void DesactivePower()
    { 
        powerUp.SetActive(false);
        boostText.SetActive(false);
    }

}
