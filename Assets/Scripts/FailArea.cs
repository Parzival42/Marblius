using UnityEngine;

public delegate void FailHandler(FailArea failArea, GameObject player);

public class FailArea : MonoBehaviour
{
    public static event FailHandler OnFail;

    public static void ResetFailHandler()
    {
        OnFail = null;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && OnFail != null)
            OnFail(this, other.gameObject);
    }
}