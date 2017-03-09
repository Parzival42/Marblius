using UnityEngine;

public delegate void WinHandler(WinArea failArea, GameObject player);

public class WinArea : MonoBehaviour
{
    public static event WinHandler OnWin;

    public static void ResetWinHandler()
    {
        OnWin = null;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && OnWin != null)
            OnWin(this, other.gameObject);
    }
}
