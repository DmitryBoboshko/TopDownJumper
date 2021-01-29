using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverState : GameBaseState
{
    public override void EnterState(GameStatesController game)
    {
        Debug.Log("Entered to " + this);

        // Activate UI with restart button
        game.gameOverUI.SetActive(true);

    }
}
