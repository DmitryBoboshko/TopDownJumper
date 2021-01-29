using UnityEngine;

public class GameStatesController : MonoBehaviour
{
    #region Cached references
    // UI
    [SerializeField] public GameObject gameMenuUI;
    [SerializeField] public GameObject gameInstructionUI;
    [SerializeField] public GameObject gamePlayingUI;
    [SerializeField] public GameObject gameOverUI;

    // This field will hold a reference to an instance of the  
    // GameBaseState a concrete state as the context's current state.
    private GameBaseState currentGameState;

    // Game Concrete States
    public readonly GameMenuState gameMenuState = new GameMenuState();
    public readonly GameInstructionState gameInstructionState = new GameInstructionState();
    public readonly GamePlayingState gamePlayingState = new GamePlayingState();
    public readonly GameOverState gameOverState = new GameOverState();

    #endregion

    private void Awake()
    {
        // On game awake turned off all UI
        //gameMenuUI.SetActive(false);
        //gameInstructionUI.SetActive(false);
        //gamePlayingUI.SetActive(false);
        //gameOverUI.SetActive(false);
    }

    void Start()
    {
        //SwitchToMenuState();
    }

    public void TransitionToState(GameBaseState state)
    {
        currentGameState = state;
        currentGameState.EnterState(this);
    }

    public void SwitchToMenuState()
    {
        TransitionToState(gameMenuState);
    }

    public void SwitchToInstructionState()
    {
        TransitionToState(gameInstructionState);
    }

    public void SwitchToPlayingState()
    {
        TransitionToState(gamePlayingState);
    }

    public void SwitchToOverState()
    {
        TransitionToState(gameOverState);
    }

}
