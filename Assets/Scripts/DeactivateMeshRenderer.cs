using UnityEngine;

/// <summary>
/// Deactivates the mesh renderer on start.
/// </summary>
public class DeactivateMeshRenderer : MonoBehaviour
{
	private void Start ()
    {
        GetComponent<MeshRenderer>().enabled = false;
	}
}