using UnityEngine;

public delegate void SpawnHandler(GameObject spawned);

/// <summary>
/// Handles spawning and general game logic.
/// </summary>
public class GameManager : MonoBehaviour
{
    [SerializeField]
    [Tooltip("The player GameObject (Use prefab!)")]
    private GameObject player;

    private GameObject spawnPoint;

    public static SpawnHandler OnSpawn;

	private void Start()
    {
        WinArea.OnWin += HandleWin;
        FailArea.OnFail += HandleFail;
        BallDropChecker.OnBallDropped += HandleBallDrop;

        spawnPoint = GameObject.FindGameObjectWithTag("Spawn");
        if (spawnPoint == null)
            Debug.LogError("No spawn point found! Insert spawn point from <b>Assets/Prefabs/Utilies/SpawnPoint</b> into the scene!");
        else
            SpawnPlayer();
	}
	
	private void Update()
    {
	    
	}

    protected void HandleFail(FailArea failArea, GameObject player)
    {
        Debug.Log("Player failed! Respawn at spawnpoint.");
        Destroy(player);
        SpawnPlayer();
    }

    protected void HandleWin(WinArea failArea, GameObject player)
    {
        // TODO
        Debug.Log("Win Handle");
    }

    protected void HandleBallDrop(GameObject player)
    {
        Destroy(player);
        SpawnPlayer();
        Debug.Log("Ball Drop");
    }

    protected void SpawnPlayer()
    {
        if (player != null && spawnPoint != null)
        {
            GameObject g = Instantiate(player, spawnPoint.transform) as GameObject;
            g.transform.SetParent(null);
            OnPlayerSpawn(g);
        }
    }

    private void OnPlayerSpawn(GameObject p)
    {
        if (OnSpawn != null)
            OnSpawn(p);
    }

    protected void RestartGame()
    {
        FailArea.ResetFailHandler();
        WinArea.ResetWinHandler();
        BallDropChecker.ResetBallDropHandler();
        OnSpawn = null;

        // TODO: Reset stuff and restart level
    }
}