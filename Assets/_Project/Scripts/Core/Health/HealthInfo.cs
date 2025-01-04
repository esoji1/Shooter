using UnityEngine;
using UnityEngine.UI;

public class HealthInfo : MonoBehaviour
{
    [SerializeField] private GameObject _healthBarPrefab;

    private Canvas _healthUi;

    private GameObject _instantiatedHealthBar;
    private HealthInfo _healthInfo;
    private Image _barBackground;
    private Image _barForeground;

    public Image BarBackground => _barBackground;
    public Image BarForeground => _barForeground;
    public GameObject InstantiatedHealthBar => _instantiatedHealthBar;
    public HealthInfo GetHealthInfo => _healthInfo;

    public void Initialize(Canvas healthUi)
    {
        _healthInfo = this;
        _healthUi = healthUi;

        _instantiatedHealthBar = Instantiate(_healthBarPrefab, _healthUi.transform);

        _barBackground = _instantiatedHealthBar.GetComponentInChildren<BarBackground>()
            .GetComponent<Image>();
        _barForeground = _instantiatedHealthBar.GetComponentInChildren<BarForeground>()
            .GetComponent<Image>();
    }

    public void SetPositon(Transform transform)
    {
        Vector3 targetPosition = transform.position;

        _instantiatedHealthBar.transform.position = targetPosition;
    }
}
