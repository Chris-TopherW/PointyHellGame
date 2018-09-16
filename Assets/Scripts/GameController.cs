using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    public GameObject playText;

    public PlayerController playerController1;
    public PlayerController playerController2;

    public GameObject gameUI;
    public GameObject p1Win;
    public GameObject p2Win;

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
            p1Win.gameObject.SetActive(false);
            p2Win.gameObject.SetActive(false);

            playerController1.gameObject.SetActive(false);
            playerController2.gameObject.SetActive(false);

            gameUI.SetActive(false);
        }
        else if (state == IN_GAME)
        {
            playText.gameObject.SetActive(false);
            p1Win.gameObject.SetActive(false);
            p2Win.gameObject.SetActive(false);

            playerController1.Reset();
            playerController2.Reset();

            playerController1.gameObject.SetActive(true);
            playerController2.gameObject.SetActive(true);

            gameUI.SetActive(true);
        }
        else if (state == GAME_OVER)
        {
            playerController1.gameObject.SetActive(false);
            playerController2.gameObject.SetActive(false);

            if (winner == "Player 1")
            {
                p1Win.gameObject.SetActive(true);
                p2Win.gameObject.SetActive(false);
            }
            else {
                p1Win.gameObject.SetActive(false);
                p2Win.gameObject.SetActive(true);
            }

            playText.gameObject.SetActive(false);

            gameUI.SetActive(false);
        }
    }

    void Update()
    {
        if (state == SPLASH_SCREEN || state == GAME_OVER)
        {
            if (Input.GetButtonDown("Jump") || Input.GetButtonDown("Player 1 Jump") || Input.GetButtonDown("Player 2 Jump"))
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
