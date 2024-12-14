using UnityEngine;

[RequireComponent(typeof(Animator), typeof(SpriteRenderer))]
public class WeaponView : MonoBehaviour
{
    private const string IsIdle = "IsIdle";
    private const string IsRecoil = "IsRecoil";

    private Animator _animator;
    private SpriteRenderer _spriteRenderer;

    public SpriteRenderer GetWeaponView => _spriteRenderer;

    public void Initialize()
    {
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void StartIdle() => _animator.SetBool(IsIdle, true);
    public void StopIdle() => _animator.SetBool(IsIdle, false);

    public void StartRecoil() => _animator.SetBool(IsRecoil, true);
    public void StopRecoil() => _animator.SetBool(IsRecoil, false);
}