using UnityEngine;
using UnityEngine.SceneManagement;

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

    private GameObject[] allSpawnPoints;

    public static SpawnHandler OnSpawn;

	private void Start()
    {
        WinArea.OnWin += HandleWin;
        FailArea.OnFail += HandleFail;
        BallDropChecker.OnBallDropped += HandleBallDrop;

        allSpawnPoints = GetAllSpawnpoints();
        spawnPoint = ChooseRandomSpawn(allSpawnPoints);
        SpawnPlayer();
	}
	
    protected void HandleFail(FailArea failArea, GameObject player)
    {
        Debug.Log("Player failed! Respawn at spawnpoint.");

        spawnPoint = ChooseRandomSpawn(allSpawnPoints);
        Destroy(player);
        SpawnPlayer();
    }

    protected void HandleWin(WinArea failArea, GameObject player)
    {
        ResetStaticReferences();
        SceneManager.LoadScene(1, LoadSceneMode.Single);

        Debug.Log("Win Handle");
    }

    protected void HandleBallDrop(GameObject player)
    {
        spawnPoint = ChooseRandomSpawn(allSpawnPoints);
        Destroy(player);
        SpawnPlayer();
        Debug.Log("Ball Drop");
    }

    protected void SpawnPlayer()
    {
        if (player != null && spawnPoint != null)
        {
            GameObject g = Instantiate(player, spawnPoint.transform.position, Quaternion.identity) as GameObject;
            OnPlayerSpawn(g);
        }
    }

    private void OnPlayerSpawn(GameObject p)
    {
        if (OnSpawn != null)
            OnSpawn(p);
    }

    private GameObject[] GetAllSpawnpoints()
    {
        GameObject[] spawns = GameObject.FindGameObjectsWithTag("Spawn");

        if (spawns == null)
            Debug.LogError("No spawn point found! Insert one or more spawn points from <b>Assets/Prefabs/Utilies/SpawnPoint</b> into the scene!");
        return spawns;
    }

    private GameObject ChooseRandomSpawn(GameObject[] spawns)
    {
        int index = Random.Range(0, spawns.Length);
        return spawns[index];
    }

    protected void ResetStaticReferences()
    {
        FailArea.ResetFailHandler();
        WinArea.ResetWinHandler();
        BallDropChecker.ResetBallDropHandler();
        OnSpawn = null;

        // TODO: Reset stuff and restart level
    }
}