using UnityEngine;

public class HealthView : MonoBehaviour
{
    [SerializeField] private HealthInfo _healthInfo;

    private IOnDamage _onDamage;

    private int _currentHp;
    private int _maxHp;

    public void Initialize(IOnDamage onDamage, int maxHealth)
    {
        _maxHp = maxHealth;
        _currentHp = maxHealth;
        _onDamage = onDamage;

        UpdateHealthBar();

        _onDamage.OnDamage += Damage;
    }

    public void FollowTargetHealth() 
        => _healthInfo.SetPositon(_onDamage.PointHealth.transform);
    
    private void Damage(int damage)
    {
        _currentHp -= damage;

        _currentHp = Mathf.Clamp(_currentHp, 0, _maxHp);

        UpdateHealthBar();

        if (_currentHp <= 0)
            _onDamage.OnDamage -= Damage;
    }

    private void UpdateHealthBar()
        => _healthInfo.BarForeground.fillAmount = (float)_currentHp / _maxHp;
}
