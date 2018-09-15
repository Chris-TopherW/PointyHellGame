using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    public PlayerController playerController1;
    public PlayerController playerController2;

    private const string SPLASH_SCREEN = "SPLASH_SCREEN";
    private const string IN_GAME = "IN_GAME";
    private const string GAME_OVER = "GAME_OVER";

    private string state;

    private string winner;

    void Start () {
        state = IN_GAME;
        UpdateGameState();
    }
	
    void UpdateGameState()
    {
        if (state == SPLASH_SCREEN)
        {

        }
        else if (state == IN_GAME)
        {
            playerController1.Reset();
            playerController2.Reset();
        }
        else if (state == GAME_OVER)
        {
            print(winner + " WINS!!!");
        }
    }

    void Update()
    {
        if (state == SPLASH_SCREEN || state == GAME_OVER)
        {
            // TODO
        }
        else if (state == IN_GAME)
        {
            GameLoop();
        }
    }

    void GameLoop()
    {
        if (playerController1.Dead() || playerController2.Dead())
        {
            winner = playerController1.Dead() ? "Player 2" : "Player 1";
            state = GAME_OVER;
            UpdateGameState();
        }
    }
}
