using UnityEngine;
using UnityEngine.UI;

public class TextFade : MonoBehaviour
{
    [SerializeField]
    private float speed = 0.1f;

    private Text text;
    float alpha = 0f;

	private void Start ()
    {
        text = GetComponent<Text>();
	}
	
	private void Update ()
    {
        text.color = new Color(text.color.r, text.color.g, text.color.b, alpha);
        alpha += speed * Time.deltaTime;

        alpha = Mathf.Clamp(alpha, 0f, 1f);
	}
}
