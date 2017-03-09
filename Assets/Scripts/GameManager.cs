using UnityEngine;

/// <summary>
/// Handles spawning and general game logic.
/// </summary>
public class GameManager : MonoBehaviour
{
	private void Start()
    {
        WinArea.OnWin += HandleWin;
        FailArea.OnFail += HandleFail;
        BallDropChecker.OnBallDropped += HandleBallDrop;
	}
	
	private void Update()
    {
	    
	}

    protected void HandleFail(FailArea failArea, GameObject player)
    {
        // TODO
        Debug.Log("Fail Handle");
    }

    protected void HandleWin(WinArea failArea, GameObject player)
    {
        // TODO
        Debug.Log("Win Handle");
    }

    protected void HandleBallDrop(GameObject player)
    {
        Debug.Log("Ball Drop");
    }

    protected void RestartGame()
    {
        FailArea.ResetFailHandler();
        WinArea.ResetWinHandler();
        BallDropChecker.ResetBallDropHandler();

        // TODO: Reset stuff and restart level
    }
}