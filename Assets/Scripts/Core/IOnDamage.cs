using System;

public interface IOnDamage
{
    event Action<int> OnDamage;
    PointHealth PointHealth { get; }
}
