using UnityEngine;
using System.Collections;

public class TargetFollow : MonoBehaviour
{
    [SerializeField]
    private GameObject targetToFollow;

    [SerializeField]
    protected float cameraDamping = 1f;

    [SerializeField]
    protected float maxSpeed = 1f;

    #region Internal members
    private Vector3 velocity = Vector3.zero;
    #endregion

    public GameObject TargetToFollow
    {
        get { return targetToFollow; }
        set { targetToFollow = value; }
    }

    private void Start()
    {
        GameManager.OnSpawn += HandlePlayerSpawn;
    }

	private void Update ()
    {
        if (TargetToFollow != null)
            MoveToTarget();
	}

    private void HandlePlayerSpawn(GameObject spawned)
    {
        TargetToFollow = spawned;
    }

    private void MoveToTarget()
    {
        transform.position = Vector3.SmoothDamp(transform.position, TargetToFollow.transform.position, ref velocity, cameraDamping, maxSpeed, Time.deltaTime);
        transform.position = new Vector3(transform.position.x, 0f, transform.position.z);
    }
}
