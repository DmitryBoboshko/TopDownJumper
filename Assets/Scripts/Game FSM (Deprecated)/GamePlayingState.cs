using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayingState : GameBaseState
{
    public override void EnterState(GameStatesController game)
    {
        Debug.Log("Entered to " + this);

        // Turn off instruction
        game.gameInstructionUI.SetActive(false);
    }
}
