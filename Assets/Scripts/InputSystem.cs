using UnityEngine;

public class InputSystem : MonoBehaviour
{
    [Header("Input settings")]
    [SerializeField]
    [Tooltip("Speed of the rotation.")]
    private float rotationSpeed = 1f;

    [SerializeField]
    [Tooltip("Specifies if the horizontal input is inverted.")]
    private bool invertHorizontal = false;

    [SerializeField]
    [Tooltip("Specifies if the vertical input is inverted.")]
    private bool invertVertical = false;

	private void Update()
    {
        HandleInput();
	}

    /// <summary>
    /// Handles the input which controlls the rotation of the Transform.
    /// </summary>
    private void HandleInput()
    {
        // Get input values
        float horizontal = Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime * (invertHorizontal ? -1f : 1f);
        float vertical = Input.GetAxis("Vertical") * rotationSpeed * Time.deltaTime * (invertVertical ? -1f : 1f);

        // Rotate the GameObject in world space
        transform.Rotate(vertical, 0f, horizontal, Space.World);
    }
}