using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthInfo : MonoBehaviour
{
    [field: SerializeField] public Image BarBackground { get; private set; }
    [field: SerializeField] public Image BarForeground { get; private set; }

    public void SetPositon(Transform transform)
    {
        Vector3 targetPosition = transform.position;

        BarBackground.rectTransform.position = targetPosition;
        BarForeground.rectTransform.position = targetPosition;
    }
}
