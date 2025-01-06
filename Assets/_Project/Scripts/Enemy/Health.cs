using System;

public class Health
{
    public event Action OnDie;
    private int _health;

    public Health(int health)
    {
        if (health < 0)
            throw new ArgumentException(nameof(health));

        _health = health;
    }

    public int HealthValue => _health;

    public void TakeDamage(int damage)
    {
        _health -= damage;

        if (_health <= 0)
            OnDie?.Invoke();
    }

    public void AddHealth(int value)
    {
        if (value < 0)
            throw new ArgumentException(nameof(value));

        _health += value;
    }
}
