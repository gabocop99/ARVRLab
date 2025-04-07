using UnityEngine;

public class ThumbstickUIGizmo : MonoBehaviour
{
    public RectTransform dot;
    public float range = 16f;

    public void SetValue(Vector2 value)
    {
        dot.anchoredPosition = value * range;
    }
}
