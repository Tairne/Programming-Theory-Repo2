using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Image fillImage; // обычный Image, Type = Simple

    public void SetHealth(float current, float max)
    {
        float ratio = Mathf.Clamp01(current / max);
        fillImage.rectTransform.localScale = new Vector3(ratio, 1f, 1f);
    }
}
