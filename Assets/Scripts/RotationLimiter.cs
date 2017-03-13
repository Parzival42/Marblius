using UnityEngine;

public class RotationLimiter : MonoBehaviour
{
    [SerializeField]
    [Tooltip("Positive and negative limit on the X-Axis.")]
    private float limitX = 20.0f;

    [SerializeField]
    [Tooltip("Positive and negative limit on the Z-Axis.")]
    private float limitZ = 20.0f;

    [SerializeField]
    private bool disableYRotation = true;

	private void Update ()
    {
        DoAngleCheck();
	}

    private void DoAngleCheck()
    {
        Vector3 angles = transform.localRotation.eulerAngles;
        float positiveLimitX = Mathf.Abs(limitX);
        float positiveLimitZ = Mathf.Abs(limitZ);

        transform.eulerAngles = new Vector3(
            ClampAngle(angles.x, -positiveLimitX, positiveLimitX),
            disableYRotation ? 0f : angles.y,
            ClampAngle(angles.z, -positiveLimitZ, positiveLimitZ));
    }

    private float ClampAngle(float angle, float min, float max) {
        if (angle < 90 || angle > 270) {       // if angle in the critic region...
            if (angle > 180)
                angle -= 360;  // convert all angles to -180..+180
            if (max > 180)
                max -= 360;
            if (min > 180)
                min -= 360;
        }

        angle = Mathf.Clamp(angle, min, max);
        if (angle < 0)
            angle += 360;  // if angle negative, convert to 0..360

        return angle;
    }
}
