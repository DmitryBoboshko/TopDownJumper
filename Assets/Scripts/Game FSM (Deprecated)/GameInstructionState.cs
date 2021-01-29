using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInstructionState : GameBaseState
{
    public override void EnterState(GameStatesController game)
    {
        Debug.Log("Entered to " + this);

        // Turn of MenuUI
        game.gameMenuUI.SetActive(false);

        // Activate scores and instruction
        game.gamePlayingUI.SetActive(true);
        game.gameInstructionUI.SetActive(true);
    }

}
