using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    public Text playText;
    public Text winnerText;

    public PlayerController playerController1;
    public PlayerController playerController2;

    private const string SPLASH_SCREEN = "SPLASH_SCREEN";
    private const string IN_GAME = "IN_GAME";
    private const string GAME_OVER = "GAME_OVER";

    private string state;

    private string winner;

    void Start () {
        state = SPLASH_SCREEN;
        UpdateGameState();
    }
	
    void UpdateGameState()
    {
        if (state == SPLASH_SCREEN)
        {
            playText.gameObject.SetActive(true);
            winnerText.gameObject.SetActive(false);

            playerController1.gameObject.SetActive(false);
            playerController2.gameObject.SetActive(false);
        }
        else if (state == IN_GAME)
        {
            playText.gameObject.SetActive(false);
            winnerText.gameObject.SetActive(false);

            playerController1.Reset();
            playerController2.Reset();

            playerController1.gameObject.SetActive(true);
            playerController2.gameObject.SetActive(true);
        }
        else if (state == GAME_OVER)
        {
            playerController1.gameObject.SetActive(false);
            playerController2.gameObject.SetActive(false);

            winnerText.text = winner + " WINS!";
            winnerText.color = winner == "Player 1" ? Color.blue : Color.red;

            playText.gameObject.SetActive(true);
            winnerText.gameObject.SetActive(true);
        }
    }

    void Update()
    {
        if (state == SPLASH_SCREEN || state == GAME_OVER)
        {
            if (Input.GetButtonDown("Jump"))
            {
                state = IN_GAME;

                UpdateGameState();
            }
        }
        else if (state == IN_GAME)
        {
            GameLoop();
        }
    }

    void GameLoop()
    {
        if (playerController1.IsDead() || playerController2.IsDead())
        {
            winner = playerController1.IsDead() ? "Player 2" : "Player 1";
            state = GAME_OVER;
            UpdateGameState();
        }
    }
}
