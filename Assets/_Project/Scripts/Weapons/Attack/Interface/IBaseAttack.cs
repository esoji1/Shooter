namespace Assets.Scripts.Weapon
{
    public interface IBaseAttack
    {
        void Attack();
        BaseWeapon BaseWeapon { get; }
    }
}