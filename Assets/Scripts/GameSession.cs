using System;
using UnityEngine;
using UnityEngine.UI;

public class GameSession : MonoBehaviour
{
    #region State variables
    [SerializeField] int currentScore;
    [SerializeField] int bestScore;
    [SerializeField] int totalCoins;
    [SerializeField] int currentCoins;
    #endregion

    #region UI
    [SerializeField] Text scoreUI = null;
    [SerializeField] Text bestScoreUI = null;
    [SerializeField] Text bestScoreInMenuUI = null;
    [SerializeField] Text coinsUI = null;
    [SerializeField] Text coinsTotalUI = null;
    #endregion

    #region Cached references
    [SerializeField] private UIManager UIManager = null;

    #endregion

    private void OnEnable()
    {
        PlatformTrigger.DoIncrementScore += IncrementScore;
    }

    private void Awake()
    {
        // Initialize state variables
        bestScore = 0;
        currentScore = 0;
        totalCoins = 0;
        currentCoins = 0;

    }

    private void Start()
    {
        bestScoreInMenuUI.text = bestScore.ToString();
    }

    private void OnDisable()
    {
        PlatformTrigger.DoIncrementScore -= IncrementScore;
    }

    public void StartGame()
    {
        scoreUI.text = currentScore.ToString();
        bestScoreUI.text = bestScore.ToString();
        coinsUI.text = currentCoins.ToString();
        coinsTotalUI.text = totalCoins.ToString();

        GameStarted();
    }

    private void IncrementScore()
    {
        currentScore++;
        scoreUI.text = currentScore.ToString();

        if (GameObject.Find("GameInstructionUI") != null)
        {
            UIManager.HideUI(GameObject.Find("GameInstructionUI"));
        }
    }

    public event Action GameStarted;
    //public int GetBestScore()
    //{
    //    return bestScore;
    //}
    //public int GetTotalCoins()
    //{
    //    return totalCoins;
    //}
    //public int GetCurrentScore()
    //{
    //    return currentScore;
    //}
    //public int GetCurrentCoins()
    //{
    //    return currentCoins;
    //}
}
