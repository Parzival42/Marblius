using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class StartLevel : MonoBehaviour
{
    [SerializeField]
    private float startLevelTime = 4f;

	private void Start ()
    {
        StartCoroutine(StartLevelAfter(0, startLevelTime));  
	}

    private IEnumerator StartLevelAfter(int index, float seconds)
    {
        yield return new WaitForSeconds(seconds);
        SceneManager.LoadScene(0, LoadSceneMode.Single);
    }
}