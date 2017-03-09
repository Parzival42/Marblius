using UnityEngine;

public delegate void BallDropHandler(GameObject player);

public class BallDropChecker : MonoBehaviour
{
    [SerializeField]
    [Tooltip("At this height, the ball is marked as dropped.")]
    private float ballDropHeight = -5f;

    public static event BallDropHandler OnBallDropped;

    public static void ResetBallDropHandler()
    {
        OnBallDropped = null;
    }

	private void Update ()
    {
        if (transform.position.y <= ballDropHeight)
        {
            // Quick hack :/
            transform.position = new Vector3(transform.position.x, 1000f, transform.position.z);

            if (OnBallDropped != null)
                OnBallDropped(gameObject);
        }
	}
}
