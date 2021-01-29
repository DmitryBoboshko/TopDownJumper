using UnityEngine;
using UnityEngine.UI;

public class GameMenuState : GameBaseState
{
    public override void EnterState(GameStatesController game)
    {
        Debug.Log("Entered to " + this);

        game.gameMenuUI.SetActive(true);
    }

}
